using System;

namespace ConsoleApp.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I am consumer");

            using (var manager = new RabbitMqManager())
            {
                Console.ReadKey();
                manager.ListenFormRegisterOrderCommand();
                Console.ReadKey();
            }
        }
    }
}