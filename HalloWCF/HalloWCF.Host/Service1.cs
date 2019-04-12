using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HalloWCF.Host
{
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public IEnumerable<Kuchen> GetKuchen()
        {
            yield return new Kuchen()
            {
                Name = "Käsekuchen",
                Druchmesser = 27,
                ZuckerInKg = 1
            };
            yield return new Kuchen()
            {
                Name = "Apfelkuchen",
                Druchmesser = 12,
                ZuckerInKg = 2
            };
            yield return new Kuchen()
            {
                Name = "Donauwelle",
                Druchmesser = 4,
                ZuckerInKg = 3
            };
        }

        public string GetWochentag()
        {
            return DateTime.Now.ToString("dddd");
        }
    }
}
