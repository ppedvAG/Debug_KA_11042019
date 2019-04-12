using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HalloWCF.Host
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string GetWochentag();

        [OperationContract]
        IEnumerable<Kuchen> GetKuchen();
    }

    [DataContract]
    public class Kuchen
    {
        [DataMember]
        public string Name { get; set; }

        public int ZuckerInKg { get; set; }

        [DataMember]
        public int Druchmesser { get; set; }

        [DataMember]
        public int MyProperty { get; set; }
    }

}
