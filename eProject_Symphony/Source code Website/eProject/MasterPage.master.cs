using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DAO data = new DAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] != null)
        {
            lblLogin.Text = "Hi, " + Session["userID"].ToString() + ",";
            lnkbtnLogOut.Visible = true;
            lblError.Visible = false;
            panelLogin.Visible = false;
        }
    }
    public Boolean login(String ID, String Pass)
    {
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "Select count(*) from tblAdmin where adminID=@ID and adminPass=@Pass";
        DAO.sqlCom.Parameters.AddWithValue("@ID", ID);
        DAO.sqlCom.Parameters.AddWithValue("@Pass", Pass);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        if (DAO.sqlCon.State == ConnectionState.Open)
            DAO.sqlCon.Close();
        DAO.sqlCon.Open();
        DAO.sqlCom = new SqlCommand();
        DAO.sqlCom.CommandText = "Select count(*) from tblUser where userID=@ID and userPass=@Pass";
        DAO.sqlCom.Parameters.AddWithValue("@ID", ID);
        DAO.sqlCom.Parameters.AddWithValue("@Pass", Pass);
        DAO.sqlCom.Connection = DAO.sqlCon;
        int sql1 = (int)DAO.sqlCom.ExecuteScalar();
        DAO.sqlCon.Close();
        if (sql == 1 || sql1 == 1)
            return true;
        else return false;
    }
    protected void btnSubmitLogin_Click1(object sender, EventArgs e)
    {
        Boolean loged = login(txtloginID.Text.Trim(), txtloginPass.Text.Trim());
        if (loged)
        {
            Session["userID"] = txtloginID.Text.Trim();
            lblLogin.Text = "Hi, " + Session["userID"].ToString() + ",";
            lnkbtnLogOut.Visible = true;
            lblError.Visible = false;
            panelLogin.Visible = false;
        }
        else
        {
            lblError.Visible = true;
            return;
        }
    }
    protected void lnkbtnLogOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Home.aspx");
    }
    protected void imgbtnsearchCourse_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Course.aspx?searchkey=" + txtSearchCourse.Text.Trim());
    }
    protected void lnkuserResult_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_Result.aspx?userID=" + Session["UserID"]);
    }
    protected void lnkuserClass_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_Class.aspx?userID=" + Session["UserID"]);
    }
    protected void lnkuserPayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_Payment.aspx?userID=" + Session["UserID"]);
    }
    protected void lnkuserRegExam_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_RegExam.aspx?userID=" + Session["UserID"]);
    }
    protected void lnkuserPactical_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_Practical.aspx?userID=" + Session["UserID"]);
    }
}
