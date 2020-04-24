using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Practical : System.Web.UI.Page
{
    user_PracticalDAO DAO = new user_PracticalDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["UserID"].ToString() == "admin")
        {
            Response.Redirect("Home.aspx");
        }
        if (Request.QueryString["userID"] != null)
        {
            if (DAO.chkPrac(Request.QueryString["userID"].ToString()))
            {
                lblConfrmStt.Text = "Activated";
                lblConfrmStt.Visible = true;
            }
            else
            {
                if (DAO.chkRegPrac(Request.QueryString["userID"].ToString()))
                {
                    lblConfrmStt.Text = "Signed";
                    lblConfrmStt.Visible = true;
                }
                else
                {
                    lblConfrmStt.Text = "Not available yet";
                    lblConfrmStt.Visible = true;
                }
            }
        }
        else
        {
            Response.Write("Invalid User");
        }
    }
    protected void btnComfirm_Click(object sender, EventArgs e)
    {
        Boolean sql = DAO.regPrac(Request.QueryString["userID"].ToString());
        if (sql) Response.Redirect("user_Practical.aspx?userID=" + Session["userID"]);
        else
        {
            Response.Write("Invalid Action");
            return;
        }
    }
}