using Microsoft.Extensions.Configuration;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Text;
using GuideFinder.DataAccess;
using GuideFinder.API.Model;
using Newtonsoft.Json;

namespace GuideFinder.API.Worker
{

    public interface IBackgroundTaskQueue<T>
    {
        ValueTask AddQueue(T workItem);

        ValueTask<T> deQueue(CancellationToken cancellationToken);
    }


    public class NamesQueue : IBackgroundTaskQueue<string>
    {
        private readonly Channel<string> queue;

        public NamesQueue(IConfiguration configuration)
        {
            int.TryParse(configuration["QueueCapacity"], out int capacity);

            var options = new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };

            queue = Channel.CreateBounded<string>(options);
        }

        public async ValueTask AddQueue(string workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException("myObject cannot be null");
            }
            await queue.Writer.WriteAsync(workItem);
        }

        public ValueTask<string> deQueue(CancellationToken cancellationToken)
        {
            var workItem = queue.Reader.ReadAsync(cancellationToken);
            return workItem;
        }
    }
}
