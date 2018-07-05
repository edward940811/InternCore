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
            this.LegalConnectionString = DotNetCoreConnectionStringsConfig.ESHCloudsCore;
            this.ESHCloudsAuthorizationConnectionString = DotNetCoreConnectionStringsConfig.ESHCloudsAuth;
            this._ESHCloudsCoreConnectionString = DotNetCoreConnectionStringsConfig.ESHCloudsCore;
        }
    }
}
