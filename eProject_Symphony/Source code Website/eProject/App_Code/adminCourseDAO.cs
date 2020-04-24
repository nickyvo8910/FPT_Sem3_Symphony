using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class adminCourseDAO
{
	public adminCourseDAO()
	{
	}

    public Boolean chkCourse(String userID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "chkPKCourse";
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
        DAO.sqlCom.CommandText = "getAdminCourse";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "adminCourse";
        return dtTab;
    }

    public DataTable view(String key)
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "searchAdminCourse";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@course", key);
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "adminCourse";
        return dtTab;
    }
    public Boolean update(string id, string name, float amount)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
      
       DAO.sqlCom.CommandText = "UpdateAdminCourse";
     DAO.sqlCom.CommandType = CommandType.StoredProcedure;
       DAO.sqlCom.Parameters.AddWithValue("@courseName",name);
       DAO.sqlCom.Parameters.AddWithValue("@courseFee",amount);
      DAO.sqlCom.Parameters.AddWithValue("@courseID",id);
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
        DAO.sqlCom.CommandText = "DeleteAdminCourse";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
     
        DAO.sqlCom.Parameters.AddWithValue("@id", id);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = DAO.sqlCom.ExecuteNonQuery();
        if (sql>0)
            return true;
        else
            return false;
    }
    public Boolean add(string id, string name, decimal amount)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "Select * from tblCourse where courseID='"+id+"'";
        DAO.sqlCom.CommandType = CommandType.Text;
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap.SelectCommand = DAO.sqlCom;
        DataSet dataset = new DataSet();
        DAO.sqlAdap.Fill(dataset,"Course");
        DAO.sqlCom.ExecuteNonQuery();
        //DAO.sqlCom.Cancel();
        if (dataset.Tables["Course"].Rows.Count<1)
        {
            
            DAO.sqlCom.CommandText = "AddAdminCourse";
            DAO.sqlCom.CommandType = CommandType.StoredProcedure;
            DAO.sqlCom.Parameters.AddWithValue("@courseID", id);
            DAO.sqlCom.Parameters.AddWithValue("@courseName", name);
            DAO.sqlCom.Parameters.AddWithValue("@courseFee", amount);
            DAO.sqlCom.Connection = DAO.sqlCon;
            DAO.sqlAdap.InsertCommand = DAO.sqlCom;
            DAO.sqlCom.ExecuteNonQuery();
            return true;
        }
        else
           return false;
    }
}