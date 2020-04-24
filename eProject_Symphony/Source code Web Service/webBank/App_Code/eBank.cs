using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Windows.Forms;

/// <summary>
/// Summary description for eBank
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class eBank : System.Web.Services.WebService {
    SqlConnection sqlCon;
    SqlCommand sqlCom;
    SqlDataAdapter sqlAdap;
    DataSet dtSet = new DataSet();
    public eBank()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
        sqlCon = new SqlConnection("Data Source =.;Initial Catalog =SymphonyLtd; User Id =sa; Password =12345678");
    }

    [WebMethod]
    public Boolean chkLogin(String ID, String Pass)
    {
        if (sqlCon.State == ConnectionState.Open)
            sqlCon.Close();
        sqlCon.Open();
        sqlCom = new SqlCommand("Select count(*) from [tblBank] where [AccountID] = @ID and [PinCode] = @Pass", sqlCon);
        sqlCom.Parameters.Clear();
        sqlCom.Parameters.AddWithValue("@ID", ID);
        sqlCom.Parameters.AddWithValue("@Pass", Pass);
        int sql = (int)sqlCom.ExecuteScalar();
        sqlCon.Close();

        if (sql == 1)
        {
            return true;
        }
        else
        {
            return false;
        }

        
    }
    //[WebMethod]
    //public DataTable getTransaction(String ID)
    //{
    //    DataTable dt = new DataTable();
    //    if (sqlCon.State == ConnectionState.Open)
    //        sqlCon.Close();
    //    sqlCon.Open();
    //    sqlCom = new SqlCommand();
    //    sqlCom.Connection = sqlCon;
    //    sqlCom.CommandText = "getLog";
    //    sqlCom.CommandType = CommandType.StoredProcedure;
    //    sqlCom.Parameters.Clear();
    //    sqlCom.Parameters.AddWithValue("@accID", ID);
    //    sqlAdap = new SqlDataAdapter(sqlCom);
    //    sqlAdap.Fill(dt);
    //    dt.TableName = "Log";
    //    sqlCon.Close();

    //    return dt;
    //}
    //[WebMethod]
    //public String chkTransfer(String id)
    //    {
    //        if (sqlCon.State == ConnectionState.Open)
    //        sqlCon.Close();
    //    sqlCon.Open();
    //        try
    //        {

    //            sqlCom = new SqlCommand("Select accName from tblAccount where accID = @ID", sqlCon);
    //            sqlCom.Parameters.AddWithValue("@ID", id);



    //            object objBalance = sqlCom.ExecuteScalar();

    //            if (objBalance != null)
    //            {
    //                String msg = "AccID : " + id + ".\n AccName : " + objBalance.ToString() + ".\n Is this the right information ?";
    //                return msg;
    //            }
    //            else
    //            {
    //                return "Invalid Receiver";
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return "Invalid Receiver";
    //        }
    //    }
    //[WebMethod]
    //public Boolean transfer(String sender, Decimal amount, String receiver)
    //    {
    //        //Connection must be in opened state before declare a transaction
    //        if (sqlCon.State == ConnectionState.Open)
    //            sqlCon.Close();
    //        sqlCon.Open();

    //        SqlTransaction transaction = sqlCon.BeginTransaction();//Begin Transaction
    //        try
    //        {
    //            Decimal bBalance = 0;
    //            Object objBalance = null;
    //            Boolean finalcheck = true;

    //            //update Sender Data
    //            sqlCom = new SqlCommand();
    //            sqlCom.CommandText="withdraw";
    //            sqlCom.Connection =sqlCon;
    //            sqlCom.CommandType = CommandType.StoredProcedure;
    //            sqlCom.Transaction = transaction;
    //            sqlCom.Parameters.Clear();
    //            sqlCom.Parameters.AddWithValue("@accFrom", sender);
    //            sqlCom.Parameters.AddWithValue("@Amount",Convert.ToDouble(amount));
    //            sqlCom.ExecuteNonQuery();

    //            //Insert Trace to database
    //            sqlCom.CommandText = "logTransaction";
    //            sqlCom.Connection = sqlCon;
    //            sqlCom.Parameters.Clear();
    //            sqlCom.Parameters.AddWithValue("@accFrom", sender);
    //            sqlCom.Parameters.AddWithValue("@accTo",receiver);               
    //            sqlCom.Parameters.AddWithValue("@Amount", amount);                              
    //            sqlCom.Parameters.AddWithValue("@Type",3);
    //            sqlCom.Parameters.AddWithValue("@Date", DateTime.Now);
    //            sqlCom.ExecuteNonQuery();

    //            //get Receiver Data
    //            sqlCom.CommandText = "chkBalance";
    //            sqlCom.Connection = sqlCon;
    //            sqlCom.Parameters.Clear();
    //            sqlCom.Parameters.AddWithValue("@accID", receiver);

    //            objBalance = sqlCom.ExecuteScalar();

    //            if ((objBalance == null) || ((int)objBalance < 0))
    //            {
    //                finalcheck = false;
    //            }
    //            else
    //            {
    //                bBalance = Convert.ToDecimal(objBalance.ToString().Trim());
    //            }

    //            //update Receiver Data             

    //            sqlCom.CommandText = "deposit";
    //            sqlCom.Connection = sqlCon;
    //            sqlCom.Parameters.Clear();
    //            sqlCom.Parameters.AddWithValue("@accTo", receiver);
    //            sqlCom.Parameters.AddWithValue("@Amount", Convert.ToDouble(amount));
    //            sqlCom.ExecuteNonQuery();

    //            ////Insert Trace to database

    //            //sqlCom.CommandText = "Insert into History(AccID,TransDate,TransType,Amount,Description) values(@Acc,@Date,@Type,@Amount,@Des)";
    //            //sqlCom.Parameters.Clear();
    //            //sqlCom.Connection = sqlCon;
    //            //sqlCom.Parameters.AddWithValue("@Acc", receiver);
    //            //sqlCom.Parameters.AddWithValue("@Date", DateTime.Now);
    //            //sqlCom.Parameters.AddWithValue("@Type", 4);// --1 withdraw --2 deposit --3 transfer --4 income
    //            //sqlCom.Parameters.AddWithValue("@Amount", amount);
    //            //sqlCom.Parameters.AddWithValue("@Des", "Income");
    //            //sqlCom.ExecuteNonQuery();

    //            //Sender Check
    //            sqlCom.CommandText = "chkBalance";
    //            sqlCom.Connection = sqlCon;
    //            sqlCom.Parameters.Clear();
    //            sqlCom.Parameters.AddWithValue("@accID", sender);

    //            objBalance = sqlCom.ExecuteScalar();

    //            if ((objBalance == null) || ((Decimal)objBalance <= 0))
    //            {
    //                finalcheck = false;
    //            }

    //            //check Reciever Data
    //            sqlCom.CommandText = "chkBalance";
    //            sqlCom.Connection = sqlCon;
    //            sqlCom.Parameters.Clear();
    //            sqlCom.Parameters.AddWithValue("@accID", receiver);

    //            objBalance = sqlCom.ExecuteScalar();


    //            if (Convert.ToDecimal(objBalance.ToString().Trim()) < (bBalance + amount))
    //            {
    //                finalcheck = false;
    //            }

    //            if (finalcheck == false)
    //            {
    //                transaction.Rollback();
    //                if (sqlCon.State == ConnectionState.Open)
    //                    sqlCon.Close();
    //                return false;
    //            }
    //            else
    //            {
    //                transaction.Commit();
    //                if (sqlCon.State == ConnectionState.Open)
    //                    sqlCon.Close();
    //                return true;
    //            }

    //        }
    //        catch (SqlException ex)
    //        {
    //            MessageBox.Show(ex.Message);
    //            transaction.Rollback();
    //            sqlCon.Close();
    //            return false;
    //        }
    //    }
    [WebMethod]
    public Boolean deposit(String ID, decimal amount)
    {
        //Connection must be in opened state before declare a transaction
        if (sqlCon.State == ConnectionState.Open)
            sqlCon.Close();
        sqlCon.Open();

        SqlTransaction transaction = sqlCon.BeginTransaction();//Begin Transaction
        try
        {
            sqlCom = new SqlCommand();
            sqlCom.Transaction = transaction;
            sqlCom.Connection = sqlCon;
            sqlCom.CommandText = "[Bankdeposit]";
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.Parameters.AddWithValue("@accTo", ID);
            sqlCom.Parameters.AddWithValue("@Amount", Convert.ToDouble(amount));
            sqlCom.ExecuteNonQuery();

            ////Insert Trace to database
            //sqlCom.CommandText = "logTransaction";
            //sqlCom.Connection = sqlCon;
            //sqlCom.Parameters.Clear();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.Parameters.AddWithValue("@accFrom", "null");
            //sqlCom.Parameters.AddWithValue("@accTo", ID);
            //sqlCom.Parameters.AddWithValue("@Amount", amount);
            //sqlCom.Parameters.AddWithValue("@Type", 2);
            //sqlCom.Parameters.AddWithValue("@Date", DateTime.Now);
            //sqlCom.ExecuteNonQuery();

            transaction.Commit();
            sqlCon.Close();
            return true;

        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.Message);
            transaction.Rollback();
            sqlCon.Close();
            return false;
        }
    }
    [WebMethod]
    public Boolean withdraw(String ID, decimal amount)
    {
        //Connection must be in opened state before declare a transaction
        if (sqlCon.State == ConnectionState.Open)
            sqlCon.Close();
        sqlCon.Open();

        SqlTransaction transaction = sqlCon.BeginTransaction();//Begin Transaction
        try
        {
            sqlCom = new SqlCommand();
            sqlCom.CommandText = "[Bankwithdraw]";
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.Transaction = transaction;
            sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@accFrom", ID);
            sqlCom.Parameters.AddWithValue("@Amount", amount);
            sqlCom.ExecuteNonQuery();

            ////Insert Trace to database
            //sqlCom.CommandText = "logTransaction";
            //sqlCom.Connection = sqlCon;
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.Parameters.Clear();
            //sqlCom.Parameters.AddWithValue("@accFrom", ID);
            //sqlCom.Parameters.AddWithValue("@accTo", "null");
            //sqlCom.Parameters.AddWithValue("@Amount", Convert.ToDouble(amount));
            //sqlCom.Parameters.AddWithValue("@Type", 1);
            //sqlCom.Parameters.AddWithValue("@Date", DateTime.Now);
            //sqlCom.ExecuteNonQuery();

            //Final Check
            sqlCom.Connection = sqlCon;
            sqlCom.CommandText = "[BankchkBalance]";
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@accID", ID);

            Decimal objBalance = (Decimal)sqlCom.ExecuteScalar();

            if ((objBalance != null) && (objBalance > 0))
            {
                transaction.Commit();
                sqlCon.Close();
                return true;
            }
            else
            {                
                transaction.Rollback();
                sqlCon.Close();
                return false;
            }

        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.StackTrace);
            transaction.Rollback();
            sqlCon.Close();
            return false;
        }
    }
    [WebMethod]
    public Decimal getBalance(String ID)
    {
        if (sqlCon.State == ConnectionState.Open)
            sqlCon.Close();
        sqlCon.Open();
        sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandText = "[BankchkBalance]";
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.Parameters.Clear();
        sqlCom.Parameters.AddWithValue("@accID", ID);
        Decimal sql = (Decimal)sqlCom.ExecuteScalar();
        sqlCon.Close();

        return sql;
    }
    
}
