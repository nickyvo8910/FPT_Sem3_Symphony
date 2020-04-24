using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    adminUserDAO DAO = new adminUserDAO();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["UserID"].ToString() != "admin")
        {
            Response.Redirect("Home.aspx");
        }
        fillData();
    }

    public void fillData()
    {
        if (Request.QueryString["searchkey"] == null)
        {
            GridView1.DataSource = DAO.view();
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = DAO.view(Request.QueryString["searchkey"].ToString());
            GridView1.DataBind();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtID.Text = GridView1.SelectedRow.Cells[1].Text;
        txtName.Text = GridView1.SelectedRow.Cells[2].Text;
        txtDOB.Text = GridView1.SelectedRow.Cells[3].Text;
        txtEmail.Text = GridView1.SelectedRow.Cells[4].Text;
        if (GridView1.SelectedRow.Cells[5].Text.ToLower() == "male")
        {
            DropDownList1.SelectedIndex = 0;
        }
        else
        {
            DropDownList1.SelectedIndex = 1;
        }
        Button1.Enabled = true;
        Button2.Enabled = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Edit")
        {
            Button1.CausesValidation = true;
            txtID.Enabled = false;
            txtName.Enabled = true;
            txtDOB.Enabled = true;
            txtEmail.Enabled = true;
            DropDownList1.Enabled = true;
            Button1.Text = "Update";
            Button2.Text = "Cancel";
        }
        else if (Button1.Text == "Update")
        {
            try
            {
                Boolean sql = DAO.update(txtID.Text, txtName.Text, txtDOB.Text, txtEmail.Text, DropDownList1.Text);
                if (sql)
                {
                    Response.Redirect("admin_User.aspx");
                    GridView1.EditIndex = -1;
                    fillData();
                }
                else
                {
                    Response.Write("Update Failed");
                    return;
                }
            }
            catch (FormatException fe)
            {
                CustomValidator err = new CustomValidator();
                err.IsValid = false;
                err.ErrorMessage = "The Date is invalid, Please Choose a day from calendar.";
                Page.Validators.Add(err);
                err.ValidationGroup = "1";
                txtDOB.BackColor = System.Drawing.Color.Red;
                return;
            }
        }
        else if (Button1.Text == "Cancel")
        {
            Response.Redirect("admin_User.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Button2.Text == "Cancel")
        {
            Response.Redirect("admin_User.aspx");
        }
        else if (Button2.Text == "Delete")
        {
            Button2.Text = "Remove";
            Button1.Text = "Cancel";
        }
        else if (Button2.Text == "Remove")
        {
            Boolean sql = DAO.delete(txtID.Text);
            if (sql)
            {
                Response.Redirect("admin_User.aspx");
                GridView1.EditIndex = -1;
                fillData();
                Button2.Text = "Delete";
            }
            else
            {
                Response.Write("Delete Failed");
                return;
            }
        }
    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        Response.Redirect("admin_User.aspx?searchkey=" + txtSearch.Text.Trim());
    }
}