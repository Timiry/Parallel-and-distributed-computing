using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace MyProgram
{
    public class HelloClient
    {
        public static void Main(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpClientChannel());
            Hello obj = (Hello)Activator.GetObject(typeof(Hello), "tcp://localhost:8086/Hi");
            if(obj == null){
                Console.WriteLine("Объект не создан");
                return;
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(obj.Greeting("Иван"));
            }
            System.Console.ReadLine();
        }
    }
}
