using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for regUserDAO
/// </summary>
public class regUserDAO
{
	public regUserDAO()
	{
	}
    public Boolean regUser(String userID,String Pass,String Name,DateTime DOB,String Mail,String Sex)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "regUser";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@id", userID);
        DAO.sqlCom.Parameters.AddWithValue("@pass", Pass);
        DAO.sqlCom.Parameters.AddWithValue("@name", Name);
        DAO.sqlCom.Parameters.AddWithValue("@dob", DOB);
        DAO.sqlCom.Parameters.AddWithValue("@mail", Mail);
        DAO.sqlCom.Parameters.AddWithValue("@sex", Sex);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = DAO.sqlCom.ExecuteNonQuery();
        if (sql == 1) return true;
        else return false;
    }
    public Boolean chkUser(String userID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "chkRegUser";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@id", userID);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        if (sql >= 1) return true;
        else return false;
    }
}