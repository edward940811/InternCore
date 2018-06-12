using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
namespace ESHCloud.Test
{
    [TestClass]
    public class DbConnectionTest
    {
        //
        //        name="ESHCloudsDB" c
        //            name = "ESHCloudsAuth"
        //        name="LegalDB" conne
        //            name = "RiskDB" connec
        [TestMethod]
        public void TestESHCloudsDBDbConnection()
        {
             
            using (SqlConnection conn 
                = new SqlConnection(
                    ConfigurationManager
                    .ConnectionStrings["ESHCloudsDB"].ConnectionString))
            {
                conn.Open();
                Assert.AreEqual(true,(conn.State & ConnectionState.Open) != 0);
                conn.Close();
            }
        }
        [TestMethod]
        public void TestESHCloudsAuthDbConnection()
        {
            using (SqlConnection conn
                = new SqlConnection(
                    ConfigurationManager
                        .ConnectionStrings["ESHCloudsAuth"].ConnectionString))
            {
                conn.Open();
                Assert.AreEqual(true, (conn.State & ConnectionState.Open) != 0);
                conn.Close();
            }
        }
        [TestMethod]
        public void TestLegalDBDbConnection()
        {
            using (SqlConnection conn
                = new SqlConnection(
                    ConfigurationManager
                        .ConnectionStrings["LegalDB"].ConnectionString))
            {
                conn.Open();
                Assert.AreEqual(true, (conn.State & ConnectionState.Open) != 0);
                conn.Close();
            }
        }
        [TestMethod]
        public void TestRiskDBDbConnection()
        {
            using (SqlConnection conn
                = new SqlConnection(
                    ConfigurationManager
                        .ConnectionStrings["RiskDB"].ConnectionString))
            {
                conn.Open();
                Assert.AreEqual(true, (conn.State & ConnectionState.Open) != 0);
                conn.Close();
            }
        }
    }
}