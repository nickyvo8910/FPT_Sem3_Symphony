using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for bankLoginDAO
/// </summary>
public class bankLoginDAO
{
	public bankLoginDAO()
	{
		
	}
    public Decimal getAmount(int id)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "getPaymentAmount";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@paymentID", id);
        DAO.sqlCom.Connection = DAO.sqlCon;
        Decimal sql = (Decimal)DAO.sqlCom.ExecuteScalar();
        return sql;
    }
    public Boolean payPayment(int payID, int payAcc)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "[BankPayPayment]";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@payID", payID);
        DAO.sqlCom.Parameters.AddWithValue("@payAcc", payAcc);
        DAO.sqlCom.Parameters.AddWithValue("@payDate", DateTime.ParseExact(DateTime.Now.ToShortDateString(), "MM/dd/yyyy", null));
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = DAO.sqlCom.ExecuteNonQuery();
        if (sql >= 1) return true;
        else return false;
    }
}