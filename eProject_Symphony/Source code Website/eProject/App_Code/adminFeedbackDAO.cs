using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for adminFeedbackDAO
/// </summary>
public class adminFeedbackDAO
{
	public adminFeedbackDAO()
	{
	}
    public DataTable view()
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getAdminFeedback";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "adminFeedback";
        return dtTab;
    }

    public DataTable view(String key)
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "searchAdminFeedback";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@id", key);
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "adminFeedback";
        return dtTab;
    }
    public Boolean update(string id, string question)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "UpdateAdminFeedback";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
       
        DAO.sqlCom.Parameters.AddWithValue("@faqQuestion", question);
        DAO.sqlCom.Parameters.AddWithValue("@faqID", id);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = DAO.sqlCom.ExecuteNonQuery();
        if (sql == 1)

            return true;
        else
            return false;
    }
    public Boolean delete(string id)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "delFAQ";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;

        DAO.sqlCom.Parameters.AddWithValue("@delFAQ", id);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = DAO.sqlCom.ExecuteNonQuery();
        if (sql == 1)

            return true;
        else
            return false;
    }
   
}