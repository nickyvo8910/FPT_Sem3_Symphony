using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for user_PracticalDAO
/// </summary>
public class user_PracticalDAO
{
	public user_PracticalDAO()
	{
		
	}
    public Boolean chkPrac(String userID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "[chkUserPrac]";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@id", userID);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        if (sql == 1) return true;
        else return false;
    }
    public Boolean chkRegPrac(String userID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "[chkUserRegPrac]";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@userID", userID);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        if (sql == 1) return true;
        else return false;
    }

    public Boolean regPrac(String userID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "regPrac";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@id", userID);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = DAO.sqlCom.ExecuteNonQuery();
        if (sql == 1) return true;
        else return false;
    }
}