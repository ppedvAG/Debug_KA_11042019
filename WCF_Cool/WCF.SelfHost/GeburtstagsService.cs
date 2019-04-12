using System;
using System.ServiceModel;
using WCF.Model;

namespace WCF.SelfHost
{
    public class GeburtstagsService : IGeburtstagsService
    {

        public Geschenk GetGeschenk()
        {
            var ü = new Random().Next();
            Console.WriteLine($"Ü: {ü}");
            return new Geschenk() { Überraschung = ü };
        }
    }



}
