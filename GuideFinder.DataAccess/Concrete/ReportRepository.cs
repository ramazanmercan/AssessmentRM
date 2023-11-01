using GuideFinder.API.Model;
using GuideFinder.DataAccess.Abstract;
using GuideFinder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IModel = RabbitMQ.Client.IModel;

namespace GuideFinder.DataAccess.Concrete
{
    public class ReportRepository : IReportRepository
    {
        private void SendReportToRabbitMQ(ReportType reportType)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ReportQ",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                string message = JsonConvert.SerializeObject(reportType);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "ReportQ",
                    basicProperties: null,
                    body: body);
            }
        }


        public ReportType CreateReport(ReportType reportType)
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                reportType.NumberOfContacts = GuideDbContext.GuideDetails
                    .Where(g => g.Location == reportType.Location)
                    .Select(g => g.Location)
                    .Count();

                reportType.NumberOfPhoneNumbers = GuideDbContext.GuideDetails
                    .Where(g => g.Location == reportType.Location)
                    .Select(g => g.Phone)
                    .Count();

                Guid newGuid = Guid.NewGuid();

                reportType.UUID = newGuid;
                reportType.RequestDate = DateTime.Now;
                reportType.Location = reportType.Location;
                reportType.Status = false;// hazırlanıyor

                SendReportToRabbitMQ(reportType);

                return reportType;
            }
        }

        public List<ReportType> GetAllReport()
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                return GuideDbContext.ReportTypes.ToList();
            }
        }

        public ReportType GetReportById(Guid UUID)
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                return GuideDbContext.ReportTypes.Where(x => x.UUID == UUID).FirstOrDefault();
            }
        }
    }
}
