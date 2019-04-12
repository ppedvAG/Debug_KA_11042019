using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Dienst
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Debugger.Launch();
            WCF.SelfHost.Program.StartWcfService();
        }

        protected override void OnStop()
        {
            WCF.SelfHost.Program.StopWcfService();
        }
    }
}
