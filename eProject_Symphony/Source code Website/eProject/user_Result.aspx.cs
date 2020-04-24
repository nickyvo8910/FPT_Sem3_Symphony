using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Result : System.Web.UI.Page
{
    userResultDAO DAO = new userResultDAO();
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
                lblPrac.Text = "Activated";
                lblPrac.Visible = false;
                dropPractical.SelectedIndex = 1;
            }
            else
            {
                if (DAO.chkRegPrac(Request.QueryString["userID"].ToString()))
                {
                    lblPrac.Text = "Signed";
                    lblPrac.Visible = false;
                    dropPractical.SelectedIndex = 1;
                }
                else
                {
                    lblPrac.Text = "Not available yet";
                    lblPrac.Visible = false;
                    dropPractical.SelectedIndex = 0;
                }
            }
            if (DAO.view(Request.QueryString["userID"].ToString()).Rows.Count > 0)
            {
                DetailsView1.DataSource = DAO.view(Request.QueryString["userID"].ToString());
                DetailsView1.DataBind();
                if (DAO.view(Request.QueryString["userID"].ToString()).Rows[0][4].ToString() == "")
                {
                    lblConfrmStt.Text = "Not available";
                    lblConfrmStt.Visible = true;
                }
                else
                {
                    if (DAO.chkClassConfirm(Request.QueryString["userID"].ToString()))
                    {
                        lblConfrmStt.Text = "Confirmed";
                    }
                    else
                    {
                        lblConfrmStt.Text = "Not Confirmed";
                    }
                }
            }
            else
            {
                lblConfrmStt.Text = "Not available";
                lblConfrmStt.Visible = true;
            }
        }
        else
        {
            lblConfrmStt.Visible = true;
            lblConfrmStt.Text = "Not available";
            Response.Write("Invalid User");
        }
    }
    protected void btnComfirm_Click(object sender, EventArgs e)
    {
        Boolean sql = DAO.confirmClass(DAO.view(Request.QueryString["userID"].ToString()).Rows[0][0].ToString(), DAO.view(Request.QueryString["userID"].ToString()).Rows[0][3].ToString(), Convert.ToInt32(DAO.view(Request.QueryString["userID"].ToString()).Rows[0][4].ToString()), Convert.ToInt32(dropPractical.SelectedValue));
        if (sql)
            Response.Redirect("user_Result.aspx?userID="+Session["UserID"].ToString());
        else
        {
            Response.Write("Invalid");
            return;
        }
    }
}