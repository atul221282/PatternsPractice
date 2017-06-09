using ConcoleApp.Contract;
using ConsoleApp.Contract;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace ConsoleApp.Consumer
{
    public class RegisteredOrderCommandConsumer : DefaultBasicConsumer
    {
        private readonly RabbitMqManager rabbitMqManager;

        public RegisteredOrderCommandConsumer(RabbitMqManager rabbitMqManager)
        {
            this.rabbitMqManager = rabbitMqManager;
        }

        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag,
            bool redelivered, string exchange, string routingKey,
            IBasicProperties properties, byte[] body)
        {
            if (properties.ContentType != RabbitMqConstants.JsonMimeType)
            {
                throw new ArgumentException(
                    $"Can't handle content type {properties.ContentType}"
                    );
            }
            var message = Encoding.UTF8.GetString(body);

            var commandObj = JsonConvert.DeserializeObject<RegisterOrderCommand>(message);

            Consume(commandObj);

            rabbitMqManager.SendAck(deliveryTag);
        }

        public void Consume(RegisterOrderCommand commandObj)
        {
            var id = 12;
            Console.WriteLine($"Order with id ${id} registered");
            Console.WriteLine($"Publishing order registered event");

            Console.WriteLine(commandObj.PickupName);

            //notify subscribers that a order is registered
            //var orderRegisteredEvent = new OrderRegisteredEvent(command, id);
            ////publish event
            //rabbitMqManager.SendOrderRegisteredEvent(orderRegisteredEvent);
        }
    }

}