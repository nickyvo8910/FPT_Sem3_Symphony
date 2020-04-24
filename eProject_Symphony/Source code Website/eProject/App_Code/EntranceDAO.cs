using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for EntranceDAO
/// </summary>
public class EntranceDAO
{
	public EntranceDAO()
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
        DAO.sqlCom.CommandText = "getselectedEntrance";
        DAO.sqlCom.CommandType = CommandType.StoredProcedure;
        DAO.sqlCom.Parameters.AddWithValue("@course", id);
        DAO.sqlCom.Connection = DAO.sqlCon;
        DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
        DAO.sqlAdap.Fill(dtTab);
        DAO.sqlCon.Close();
        dtTab.TableName = "Entrance";
        return dtTab;
    }
}