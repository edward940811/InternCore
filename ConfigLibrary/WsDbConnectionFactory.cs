using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using ConfigLibrary.Models;

namespace ConfigLibrary
{
    public static class WsDbConnectionFactory
    {
        static WsDbConnectionFactory()
        {
#if NETCOREAPP2_1
             GetNetCoreConfig();
#elif NET461
            GetNetFrameworkConfig();
#elif NETSTANDARD2_0
            GetStandardConfig();
#endif
        }

        private static void GetNetCoreConfig()
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

        private static void GetNetFrameworkConfig()
        {
            LegalConn = ConfigurationManager.ConnectionStrings["LegalConn"].ToString();
            LegalAuthConn = ConfigurationManager.ConnectionStrings["LegalConn"].ToString();
            ChemConn = ConfigurationManager.ConnectionStrings["LegalConn"].ToString();
            ESHCloudAuthConn = ConfigurationManager.ConnectionStrings["LegalConn"].ToString();
            ESHCloudCoreConn = ConfigurationManager.ConnectionStrings["LegalConn"].ToString();
        }

        private static void GetStandardConfig()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("local.settings.json")
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
