using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace MyProgram
{
    public class HelloServer
    {
        public static void Main(string[] args)
        {
            TcpServerChannel channel = new TcpServerChannel(8086);
            ChannelServices.RegisterChannel(channel);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Hello), "Hi", WellKnownObjectMode.SingleCall);
            System.Console.ReadLine();
        }
    }
}
