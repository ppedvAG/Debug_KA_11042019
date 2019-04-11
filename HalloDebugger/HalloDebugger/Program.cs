using log4net.Appender;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalloDebugger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Debugger");
            var log = log4net.LogManager.GetLogger("HALLO");

            var app = new RollingFileAppender() { File = "log.txt", AppendToFile = true, ImmediateFlush = true };

            ((log4net.Repository.Hierarchy.Logger)log.Logger).AddAppender(app);
            app.ActivateOptions();

            BasicConfigurator.Configure();


            log.Warn("HALOOOOOOOO");

            Debug.Assert(DateTime.Now.DayOfWeek == DayOfWeek.Friday);

            Console.WriteLine("go?");
            Console.ReadLine();

            Trace.Listeners.Add(new EventLogTraceListener("Application"));
            Trace.AutoFlush = true;
            Trace.WriteLine("Hallo Trace");
            Debug.WriteLine("Hallo DEBUG");

#if DEBUG
            System.Console.WriteLine("DEBUG");
#endif
#if WURST
            System.Console.WriteLine("WRUST");
#endif

            List<int> daten = new List<int>();
            var ran = new Random();

            NewMethod(daten, ran);

            try
            {

                new DataManager().ReadData();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fehler: {e.Message}");
                Debugger.Break();
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }

        private static void NewMethod(List<int> daten, Random ran)
        {
            for (int i = 0; i < 100000; i++)
            {
                daten.Add(ran.Next());
                Thread.Sleep(10);
                log4net.LogManager.GetLogger($"HALLO {i}");
            }
        }
    }

    internal class DataManager
    {
        public DataManager()
        {
        }

        internal void ReadData()
        {
            GetNumber();
        }

        private int GetNumber()
        {
            return 78342 / int.Parse("0");
        }
    }
}
