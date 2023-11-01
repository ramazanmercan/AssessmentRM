using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using GuideFinder.API.Model;
using Newtonsoft.Json;
using GuideFinder.DataAccess;

namespace MyWorkerService
{
    public class WorkerC : BackgroundService
    {
        private readonly ILogger<WorkerC> _logger;

        public WorkerC(ILogger<WorkerC> logger)
        {
            _logger = logger;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                StartReadingRabbitMQ();
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken);
            }
        }
        private void StartReadingRabbitMQ()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";

            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            channel.QueueDeclare("ReportQ", false, false, false);
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("ReportQ", false, consumer);
            consumer.Received += (sender, e) =>
            {
                var bodyArray = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(bodyArray);
                using (var GuideDbContext = new GuideDbContext())
                {
                    ReportType report = JsonConvert.DeserializeObject<ReportType>(message);
                    if (report.Location != null)
                    {
                        report.Status = true;// Rapor tamamlandı.
                        GuideDbContext.ReportTypes.Add(report);
                        GuideDbContext.SaveChanges();
                        Console.WriteLine(message);
                        channel.BasicAck(e.DeliveryTag, true);
                    }
                }
            };
        }


    }
}
