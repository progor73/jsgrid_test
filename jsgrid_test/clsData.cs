using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace jsgrid_test
{
    public class clsData
    {
        public static string strconWH = WebConfigurationManager.ConnectionStrings["conW"].ConnectionString;
        public static string strconN = WebConfigurationManager.ConnectionStrings["conN"].ConnectionString;

        public static DataTable InvLocList_Get() {
            DataTable dtret = new DataTable();
            try
            {
                using (MySqlConnection conw = new MySqlConnection(strconWH)) {
                    if (conw.State != ConnectionState.Open) conw.Open();
                    MySqlCommand comw = new MySqlCommand("sp_popis_history", conw);
                    comw.CommandType = CommandType.StoredProcedure;
                    MySqlDataAdapter sdaw = new MySqlDataAdapter(comw);
                    sdaw.Fill(dtret);
                    return dtret;
                }
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }

    }
}