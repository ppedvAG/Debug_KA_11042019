using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCF.Model;

namespace WCF.SelfHost
{
    public class Program
    {
        static ServiceHost sh = new ServiceHost(typeof(GeburtstagsService));

        static Program()
        {
            //basic (BasicHttpBinding): Einfaches Soap /.asmx 

            //tcp (NetTcpBinding): Lokales Netzwerk (nur WCF)
            var tcp = new NetTcpBinding();
            //icmp (NamedPipes): Nur lokal
            var icmp = new NetNamedPipeBinding();
            //WS-* (WsHttpBinding): Voller WebService
            var wsHttp = new WSHttpBinding();

            //RESTful 
            var webHttp = new WebHttpBinding();

            sh.AddServiceEndpoint(typeof(IGeburtstagsService), tcp, "net.tcp://localhost:1");
            sh.AddServiceEndpoint(typeof(IGeburtstagsService), icmp, "net.pipe://localhost/Geb");
            sh.AddServiceEndpoint(typeof(IGeburtstagsService), wsHttp, "http://localhost.fiddler:2/");
            var se = sh.AddServiceEndpoint(typeof(IGeburtstagsService), webHttp, "http://localhost.fiddler:3/");
            se.EndpointBehaviors.Add(new WebHttpBehavior() { AutomaticFormatSelectionEnabled = true });
        }

        public static void StartWcfService() => sh.Open();
        public static void StopWcfService() => sh.Close();

        public static void Main(string[] args)
        {
            Console.WriteLine("*** WCF Host ***");

            StartWcfService();
            Console.WriteLine("Service gestartet..");
            Console.ReadLine();
            StopWcfService();

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
