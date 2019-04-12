using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF.Model
{
    [ServiceContract]
    public interface IGeburtstagsService
    {
        [OperationContract]
        [WebGet(UriTemplate ="/Geschenk")]
        Geschenk GetGeschenk();
    }
}
