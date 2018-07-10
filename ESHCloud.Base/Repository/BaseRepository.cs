using ConfigLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ESHCloud.Base.Repository
{
    public class BaseRepository
    {
        private string _LegalConn;
        private string _LegalAuthConn;
        private string _ESHCloudCoreConn;

        public string LegalConn
        {
            get { return _LegalConn; }
            set { _LegalConn = value; }
        }

        public string LegalAuthConn
        {
            get { return _LegalAuthConn; }
            set { _LegalAuthConn = value; }
        }

        public string ESHCloudCoreConn
        {
            set { _ESHCloudCoreConn = value; }
            get { return _ESHCloudCoreConn; }
        }

        public BaseRepository()
        {
            this.LegalConn = WsDbConnectionFactory.LegalConn;
            this.LegalAuthConn = WsDbConnectionFactory.LegalAuthConn;
            this.ESHCloudCoreConn = WsDbConnectionFactory.ESHCloudCoreConn;
        }
    }
}
