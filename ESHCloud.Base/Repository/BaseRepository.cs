using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ESHCloud.Base.Repository
{
    public class BaseRepository
    {
        private string _LegalConnectionString;
        private string _ESHCloudsAuthorizationConnectionString;
        private string _LawKingConnectionString;
        private string _ESHCloudsCoreConnectionString;

        public string LegalConnectionString
        {
            get { return _LegalConnectionString; }
            set { _LegalConnectionString = value; }
        }


        public string ESHCloudsAuthorizationConnectionString
        {
            get { return _ESHCloudsAuthorizationConnectionString; }
            set { _ESHCloudsAuthorizationConnectionString = value; }
        }

        public string LawKingConnectionString
        {
            get { return _LawKingConnectionString; }
            set { _LawKingConnectionString = value; }
        }

        public string ESHCloudsCoreConnectionString
        {
            set { _ESHCloudsCoreConnectionString = value; }
            get { return _ESHCloudsCoreConnectionString; }
        }

        public BaseRepository()
        {
            this.ESHCloudsCoreConnectionString = ConfigurationManager.ConnectionStrings["ESHCloudsCore"].ConnectionString;
            this.LegalConnectionString = ConfigurationManager.ConnectionStrings["LegalDB"].ConnectionString;
            this.ESHCloudsAuthorizationConnectionString = ConfigurationManager.ConnectionStrings["ESHCloudsAuth"].ConnectionString;
            this._ESHCloudsCoreConnectionString = ConfigurationManager.ConnectionStrings["ESHCloudsCore"].ConnectionString;
//#if NETSTANDARD2_0
//            this.LegalConnectionString = DotNetCoreConnectionStringsConfig.ESHCloudsCore;
//            this.ESHCloudsAuthorizationConnectionString = DotNetCoreConnectionStringsConfig.ESHCloudsAuth;
//            this._ESHCloudsCoreConnectionString = DotNetCoreConnectionStringsConfig.ESHCloudsCore;
//#else
//            this.LegalConnectionString = ConfigurationManager.ConnectionStrings["esh_core"].ConnectionString;
//            this.ESHCloudsAuthorizationConnectionString = ConfigurationManager.ConnectionStrings["ESHCloudsAuth"].ConnectionString;
//            this._ESHCloudsCoreConnectionString = ConfigurationManager.ConnectionStrings["ESHCloudsCore"].ConnectionString;
//#endif
        }
    }
}
