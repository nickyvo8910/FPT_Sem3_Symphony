using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    public static String UserID = "";
	public User()
	{
	}
    public Boolean login(String ID, String Pass)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "Select count(*) from tblAdmin where adminID=@ID and adminPass=@Pass";
        DAO.sqlCom.Parameters.AddWithValue("@adminID", ID);
        DAO.sqlCom.Parameters.AddWithValue("@Pass", Pass);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        if (sql == 1) return true;
        else return false;
    }
}