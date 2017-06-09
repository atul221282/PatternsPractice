using ConsoleApp.Contract;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using ConcoleApp.Contract;

namespace ConsoleApp1
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


        public void SendRegisterOrderCommand(IRegisterOrderCommand command)
        {
            channel.ExchangeDeclare(exchange: RabbitMqConstants.RegisterSpeciallExchange,
                type: ExchangeType.Direct);

            channel.QueueDeclare(queue: RabbitMqConstants.RegisterSpeciallQueue, durable: false,
                exclusive: false, autoDelete: false, arguments: null);

            channel.QueueBind(queue: RabbitMqConstants.RegisterSpeciallQueue,
                exchange: RabbitMqConstants.RegisterSpeciallExchange, routingKey: "");

            var serializedCommand = JsonConvert.SerializeObject(command);

            var messageProperties = channel.CreateBasicProperties();

            messageProperties.ContentType = RabbitMqConstants.JsonMimeType;

            channel.BasicPublish(exchange: RabbitMqConstants.RegisterSpeciallExchange,
                routingKey: "",
                basicProperties: messageProperties,
                body: Encoding.UTF8.GetBytes(serializedCommand));
        }

        public void Dispose()
        {
            if (this.channel.IsOpen)
                this.channel.Close();
        }
    }
}
