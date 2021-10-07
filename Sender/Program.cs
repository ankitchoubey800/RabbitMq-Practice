using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
                using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Queue_Test", durable: false, exclusive: false,autoDelete:false,arguments:null);
                string message = "I came from Queue.";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "", routingKey: "Queue_Test", basicProperties: null, body: body);
                Console.WriteLine("Sent Message: {0}",message);
            }
            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }
    }
}
