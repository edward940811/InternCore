using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigLibrary
{
    public static class WsDbConnectionFactory
    {
        static WsDbConnectionFactory()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            LegalConn = config["ConnectionStrings:LegalConn"];
            LegalAuthConn = config["ConnectionStrings:LegalAuthConn"];
            ChemConn = config["ConnectionStrings:ChemConn"];
            ESHCloudAuthConn = config["ConnectionStrings:ESHCloudAuthConn"];
            ESHCloudCoreConn = config["ConnectionStrings:ESHCloudCoreConn"];
        }

        public static string LegalConn { get; set; }
        public static string LegalAuthConn { get; set; }
        public static string ChemConn { get; set; }
        public static string ESHCloudAuthConn { get; set; }
        public static string ESHCloudCoreConn { get; set; }
    }
   
}
