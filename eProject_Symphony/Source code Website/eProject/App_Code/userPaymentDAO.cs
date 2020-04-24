using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for userPaymentDAO
/// </summary>
public class userPaymentDAO
{
	public userPaymentDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable view(String id)
    {
        DataTable dtTab = new DataTable();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getUserPayment";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@userid", id);
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "userPayment";
        return dtTab;
    }
}