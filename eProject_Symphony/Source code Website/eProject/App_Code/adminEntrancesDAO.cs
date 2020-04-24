using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for adminEntrances
/// </summary>
public class adminEntrancesDAO
{
	public adminEntrancesDAO()
	{
	}
    public Boolean chkStartDoEnd(DateTime sDay, DateTime enDay, DateTime eDay)
    {
        Boolean Valid = true;
        if (DateTime.Compare(sDay, eDay) < 0)
        {
            Valid = true;
            if (DateTime.Compare(eDay, enDay) > 0)
            {
                Valid = true;
            }
            else
            {
                Valid = false;
            }
        }
        return Valid;
    }
    public Boolean chkEntrance(String userID)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "chkPKEntrances";
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
        DAO.sqlCom.CommandText = "getAdminEntrances";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "adminEntrances";
        return dtTab;
    }

    public DataTable view(String key)
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "searchAdminEntrances";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@course", key);
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "adminEntrances";
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

    public Boolean update(string id, string name, float amount,string cid,DateTime eDate,DateTime sDate,DateTime endDate)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "UpdateAdminEntrances";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@entranceID", id);
        DAO.sqlCom.Parameters.AddWithValue("@entranceFee", amount);
        DAO.sqlCom.Parameters.AddWithValue("@courseID", cid);
        DAO.sqlCom.Parameters.AddWithValue("@entranceTitle", name);
        DAO.sqlCom.Parameters.AddWithValue("@entranceDate", eDate);
        DAO.sqlCom.Parameters.AddWithValue("@startDate", sDate);
        DAO.sqlCom.Parameters.AddWithValue("@endDate", endDate);
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
        DAO.sqlCom.CommandText = "delEntrance";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;

        DAO.sqlCom.Parameters.AddWithValue("@delEntrance", id);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = DAO.sqlCom.ExecuteNonQuery();
        if (sql >= 1)

            return true;
        else
            return false;
    }
    public Boolean add(string id, string name,float amount, string cid, DateTime eDate, DateTime sDate, DateTime endDate)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "Select * from tblEntrance where entranceID='" + id + "'";
        DAO.sqlCom.CommandType = CommandType.Text;
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap.SelectCommand = DAO.sqlCom;
        DataSet dataset = new DataSet();
        DAO.sqlAdap.Fill(dataset, "Entrance");
        DAO.sqlCom.ExecuteNonQuery(); 
       // int sql = DAO.sqlCom.ExecuteNonQuery();
        if (dataset.Tables["Entrance"].Rows.Count < 1)
        {
            DAO.sqlCom.CommandText = "AddAdminEntrances";
            DAO.sqlCom.CommandType = CommandType.StoredProcedure;
            DAO.sqlCom.Parameters.AddWithValue("@entranceID", id);
            DAO.sqlCom.Parameters.AddWithValue("@entranceFee", amount);
            DAO.sqlCom.Parameters.AddWithValue("@courseID", cid);
            DAO.sqlCom.Parameters.AddWithValue("@entranceTitle", name);
            DAO.sqlCom.Parameters.AddWithValue("@entranceDate", eDate);
            DAO.sqlCom.Parameters.AddWithValue("@startDate", sDate);
            DAO.sqlCom.Parameters.AddWithValue("@endDate", endDate);
            DAO.sqlCom.Connection = DAO.sqlCon;
            DAO.sqlAdap.InsertCommand = DAO.sqlCom;
             DAO.sqlCom.ExecuteNonQuery(); 
            return true;
        }
        else
          return false;
    }
}