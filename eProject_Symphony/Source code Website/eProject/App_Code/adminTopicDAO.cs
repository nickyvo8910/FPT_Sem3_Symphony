using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for adminTopic
/// </summary>
public class adminTopic
{
	public adminTopic()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Boolean chkTopic(String userID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "chkPKTopic";
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
        DAO.sqlCom.CommandText = "getAdminTopic";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "adminTopic";
        return dtTab;
    }
    public DataTable view(String key)
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "searchAdminTopic";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@course", key);
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "adminTopic";
        return dtTab;
    }
    public DataTable viewID()
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getCourseID";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "CourseID";
        return dtTab;
    }

    public Boolean update(string id, string cid,string name,string des)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "UpdateAdminTopic";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@topicID", id);
        DAO.sqlCom.Parameters.AddWithValue("@topicDes",des);
        DAO.sqlCom.Parameters.AddWithValue("@courseID", cid);
        DAO.sqlCom.Parameters.AddWithValue("@topicName", name);
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
        DAO.sqlCom.CommandText = "delTopic";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;

        DAO.sqlCom.Parameters.AddWithValue("@delTopic", id);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = DAO.sqlCom.ExecuteNonQuery();
        if (sql == 1)

            return true;
        else
            return false;
    }
    public Boolean add(string id, string cid, string name, string des)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "Select * from tblTopic where topicID='" + id + "'";
        DAO.sqlCom.CommandType = CommandType.Text;
        DAO.sqlCom.Connection = DAO.sqlCon;
         DAO.sqlAdap.SelectCommand = DAO.sqlCom;
        DataSet dataset = new DataSet();
        DAO.sqlAdap.Fill(dataset, "table");
        DAO.sqlCom.ExecuteNonQuery();
        if (dataset.Tables["table"].Rows.Count<1)
        {
            DAO.sqlCom.CommandText = "AddAdminTopic";
            DAO.sqlCom.CommandType = CommandType.StoredProcedure;
            DAO.sqlCom.Parameters.AddWithValue("@topicID", id);
            DAO.sqlCom.Parameters.AddWithValue("@topicDes", des);
            DAO.sqlCom.Parameters.AddWithValue("@courseID", cid);
            DAO.sqlCom.Parameters.AddWithValue("@topicName", name);
            DAO.sqlCom.Connection = DAO.sqlCon;
            DAO.sqlAdap.InsertCommand = DAO.sqlCom;
            DAO.sqlCom.ExecuteNonQuery(); 
            return true;
        }
        else
            return false;
    }
}