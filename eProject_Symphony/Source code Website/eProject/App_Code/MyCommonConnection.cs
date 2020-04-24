using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace eProject
{
    public class MyCommonConnection
    {
        public static SqlConnection sqlCon;
        public static String stringCNN;
        public static DataSet dtSet = new DataSet();

        public MyCommonConnection()
        {
        }
        public MyCommonConnection(String dbName, String id, String pass)
        {
            stringCNN = "Data Source = .; Initial Catalog =" + dbName + "; User Id = " + id + "; Password =" + pass;
            sqlCon = new SqlConnection(stringCNN);
            sqlCon.Open();
        }
    }
}
