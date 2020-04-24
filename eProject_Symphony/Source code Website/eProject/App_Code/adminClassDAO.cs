using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for adminClassDAO
/// </summary>
public class adminClassDAO
{
	public adminClassDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Boolean chkClass(String userID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "chkPKClass";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@id", userID);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        if (sql >= 1) return true;
        else return false;
    }
    public DataTable view()
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getAdminClass";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "adminClass";
        return dtTab;
    }

    public DataTable view(String key)
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "searchAdminClass";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@course", key);
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "adminClass";
        return dtTab;
    }
    public DataTable viewID()
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getEntranceID";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "EntranceID";
        return dtTab;
    }
    public Boolean update(string id, DateTime sdate)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();

        DAO.sqlCom.CommandText = "UpdateAdminClass";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@startDate", sdate);
        DAO.sqlCom.Parameters.AddWithValue("@ClassID", id);
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
        DAO.sqlCom.CommandText = "delClass";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;

        DAO.sqlCom.Parameters.AddWithValue("@id", id);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = DAO.sqlCom.ExecuteNonQuery();
        
            return true;

    }
    public Boolean add(string id, string name, DateTime date)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "Select * from tblClass where classID='" + id + "'";
        DAO.sqlCom.CommandType = CommandType.Text;
        DAO.sqlCom.Connection = DAO.sqlCon;

        int sql = DAO.sqlCom.ExecuteNonQuery();
        if (sql == 0)
        {
            DAO.sqlCom.CommandText = "AddAdminClass";
            DAO.sqlCom.CommandType = CommandType.StoredProcedure;
            DAO.sqlCom.Parameters.AddWithValue("@classID", id);
            DAO.sqlCom.Parameters.AddWithValue("@entranceID", name);
            DAO.sqlCom.Parameters.AddWithValue("@startDate", date);
            DAO.sqlCom.Connection = DAO.sqlCon;
            DAO.sqlAdap.InsertCommand = DAO.sqlCom;
            DAO.sqlCom.ExecuteNonQuery();
            return true;
        }
        else
            return false;
    }

    public Boolean chkHasClass(string entranceID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "chkHasClass";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;

        DAO.sqlCom.Parameters.AddWithValue("@entranceID", entranceID);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        if (sql >= 1)
            return true;
        else
            return false;
        
    }

}