using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace pos_software.Data
{
    public class Databaseconfig
    {
        public static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        // public static SqlConnection con = new SqlConnection("Server=MATHU\\MSSQLSERVERMATHU;Database=pos_db;User Id=sa;Password=1998");
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Award_Management2ConnectionString1"].ConnectionString);

        public Databaseconfig()
        {
           
        }

    }
}
