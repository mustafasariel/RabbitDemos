using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace RabbitConsumer
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread.Sleep(2000);
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://yelfgfvk:YeJbM5bbqm-4T0Q8GCLgv06TspxeHymi@jaguar.rmq.cloudamqp.com/yelfgfvk");

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);



                    var consumer = new EventingBasicConsumer(channel);

                    channel.BasicConsume("hello", true, consumer);// silinmemesi için false yapmak gerekir.

                    consumer.Received += Consumer_Received;

                    
                }
            }
            Console.WriteLine("Çıkmak için tıklayınız");
            Console.ReadLine();
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            
            var message = Encoding.UTF8.GetString(e.Body);
            Console.WriteLine(message) ;
        }
    }
}
