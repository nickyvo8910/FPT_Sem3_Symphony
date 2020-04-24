using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for FeedbackDAO
/// </summary>
public class FeedbackDAO
{
	public FeedbackDAO()
	{
	}

    public DataTable view()
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getansweredFB";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "FB";
        return dtTab;
    }

    public Boolean insFB(String Mail, String Mess)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "addFeedback";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@mail", Mail);
        DAO.sqlCom.Parameters.AddWithValue("@mess", Mess);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = DAO.sqlCom.ExecuteNonQuery();
        if (sql == 1) return true;
        else return false;
    }
}