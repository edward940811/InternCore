﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawKing.DAL
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
            this.LegalConnectionString = ConfigurationManager.ConnectionStrings["LegalConnectionString"].ConnectionString;
            this.ESHCloudsAuthorizationConnectionString = ConfigurationManager.ConnectionStrings["ESHCloudsAuthorizationConnectionString"].ConnectionString;
            this.LawKingConnectionString = ConfigurationManager.ConnectionStrings["LawKingConnectionString"].ConnectionString;
        }
    }
}