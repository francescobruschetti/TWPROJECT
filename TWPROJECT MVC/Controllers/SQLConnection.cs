using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// added to connect to SQL db
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TWPROJECT_MVC.Controllers
{
    public class SQLConnection
    {
        public SqlConnection connection { get; set; }

        public SQLConnection()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TWPROJECT"].ToString());
            //Get_Connection();
        }


        // codice di prova, per provare a collegarmi al db
        // functions that establish the connection 
        private void Get_Connection()
        {

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TWPROJECT"].ToString());


            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tasks", connection);
            connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();
            string tot = rdr[0].ToString();
            Console.Write(tot); //read a value

        }
    }
}