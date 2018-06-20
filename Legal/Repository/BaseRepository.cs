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
        private string _LegalConnectionString;
        private string _ESHCloudsAuthorizationConnectionString;
        private string _LawKingConnectionString;

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

        public BaseRepository()
        {
            this.LegalConnectionString = ConfigurationManager.ConnectionStrings["LegalDB"].ConnectionString;
            this.ESHCloudsAuthorizationConnectionString = ConfigurationManager.ConnectionStrings["ESHCloudsAuth"].ConnectionString;
            //this.LawKingConnectionString = ConfigurationManager.ConnectionStrings["LawKingConnectionString"].ConnectionString;
        }
    }
}
