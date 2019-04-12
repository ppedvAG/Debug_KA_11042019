using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using WCF.Model;

namespace WCF.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetGeschenk(object sender, RoutedEventArgs e)
        {
            #region tcp/ip
            //var tcp = new NetTcpBinding();
            //tcp.Security.Mode = SecurityMode.None;
            //var url = "net.tcp://localhost:1";
            //  cf.Credentials.Windows.ClientCredential.UserName = "Fred";
            //  cf.Credentials.Windows.ClientCredential.Password= "123456";
            #endregion

            #region namedPipes
            //var url = "net.pipe://localhost/Geb";
            //var icmp = new NetNamedPipeBinding();
            //var cf = new ChannelFactory<IGeburtstagsService>(icmp, new EndpointAddress(url));
            #endregion

            #region http
            var url = "http://localhost.fiddler:2";
            var cf = new ChannelFactory<IGeburtstagsService>(new WSHttpBinding(), new EndpointAddress(url));
            #endregion


            IGeburtstagsService gs = cf.CreateChannel();
            tb.Text = gs.GetGeschenk().Überraschung.ToString();
        }

        private void GetGeschenkREST(object sender, RoutedEventArgs e)
        {
            var wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add(HttpRequestHeader.Accept, "application/json");
            var json = wc.DownloadString("http://localhost:3/Geschenk");

            var geschenk = JsonConvert.DeserializeObject<Geschenk>(json);

            //  var xml = wc.DownloadString("http://localhost:3/Geschenk");
            //  var xmlSerial = new XmlSerializer(typeof(Geschenk), "http://schemas.datacontract.org/2004/07/WCF.Model");
            //  var geschenk = (Geschenk)xmlSerial.Deserialize(new StringReader(xml));

            tbRest.Text = geschenk.Überraschung.ToString();
        }

        private void GetBooks(object sender, RoutedEventArgs e)
        {
            var wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var json = wc.DownloadString($"https://www.googleapis.com/books/v1/volumes?q={sucheTb.Text}");

            BooksResult booksResults = JsonConvert.DeserializeObject<BooksResult>(json);

            myBooks.ItemsSource = booksResults.items.Select(x => x.volumeInfo);
        }
    }
}
