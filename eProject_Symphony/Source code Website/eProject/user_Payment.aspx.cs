using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_Payment : System.Web.UI.Page
{
    userPaymentDAO DAO = new userPaymentDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["UserID"].ToString() == "admin")
        {
            Response.Redirect("Home.aspx");
        }
        if (Request.QueryString["userID"] != null)
        {
            if (DAO.view(Request.QueryString["userID"].ToString()).Rows.Count > 0)
            {
                GridView1.DataSource = DAO.view(Request.QueryString["userID"].ToString());
                GridView1.DataBind();
                if (DAO.view(Request.QueryString["userID"].ToString()).Rows[0][3].ToString() == "")
                {
                    lblConfrmStt.Text = "Not available";
                    lblConfrmStt.Visible = true;
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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        if (row != null && row.Cells[6].Text.ToLower()!="paid")
        {
            TextBox1.Text = row.Cells[1].Text;
            Button1.Enabled = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("bankLogin.aspx?payID=" + TextBox1.Text.Trim());
    }
}