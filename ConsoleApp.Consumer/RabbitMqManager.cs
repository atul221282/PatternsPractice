using ConsoleApp.Contract;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using ConcoleApp.Contract;

namespace ConsoleApp.Consumer
{
    public class RabbitMqManager : IDisposable
    {
        private readonly IModel channel;

        public RabbitMqManager()
        {
            var connectionFactory = new ConnectionFactory { Uri = RabbitMqConstants.RabbitMqUri };
            var connection = connectionFactory.CreateConnection();
            channel = connection.CreateModel();
            connection.AutoClose = true;
        }


        public void ListenFormRegisterOrderCommand()
        {
            channel.QueueDeclare(queue: RabbitMqConstants.RegisterSpeciallQueue,
                durable: false, exclusive: false,
                autoDelete: false, arguments: null);

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            var consumer = new RegisteredOrderCommandConsumer(this);

            channel.BasicConsume(queue: RabbitMqConstants.RegisterSpeciallQueue,
                noAck: false,
                consumer: consumer);
        }

        internal void SendAck(ulong deliveryTag)
        {
            channel.BasicAck(deliveryTag: deliveryTag, multiple: false);
        }

        public void Dispose()
        {
            if (this.channel.IsOpen)
                this.channel.Close();
        }
    }
}
