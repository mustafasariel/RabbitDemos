using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitDemoPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            // yelfgfvk
            //YeJbM5bbqm-4T0Q8GCLgv06TspxeHymi
            //amqp://   	amqp://yelfgfvk:YeJbM5bbqm-4T0Q8GCLgv06TspxeHymi@jaguar.rmq.cloudamqp.com/yelfgfvk


            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://yelfgfvk:YeJbM5bbqm-4T0Q8GCLgv06TspxeHymi@jaguar.rmq.cloudamqp.com/yelfgfvk");

            using (var connection=factory.CreateConnection())
            {
                using (var channel=connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);
                    string messages = "2. mesaj";
                    var bodyByte = Encoding.UTF8.GetBytes(messages);

                    channel.BasicPublish("", routingKey: "hello", null, bodyByte);

                    Console.WriteLine("Mesaj gönderildi");
                }
            }
            Console.WriteLine("Çıkmak için tıklayınız");
            Console.ReadLine();
        }
    }
}
