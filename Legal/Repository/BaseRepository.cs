using ConfigLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legal.Repository
{
    public class BaseRepository
    {
        private string _LegalConn;
        private string _ESHCloudAuthConn;

        public string LegalConn
        {
            get { return _LegalConn; }
            set { _LegalConn = value; }
        }


        public string ESHCloudAuthConn
        {
            get { return _ESHCloudAuthConn; }
            set { _ESHCloudAuthConn = value; }
        }

        public BaseRepository()
        {
            this.LegalConn = WsDbConnectionFactory.LegalConn;
            this.ESHCloudAuthConn = WsDbConnectionFactory.ESHCloudAuthConn;
        }
    }
}
