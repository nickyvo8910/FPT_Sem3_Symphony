using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eBank;

public partial class admin_Class : System.Web.UI.Page
{
    adminClassDAO DAO = new adminClassDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] == null || Session["UserID"].ToString() != "admin")
            {
                Response.Redirect("Home.aspx");
            }
            fillData();
        }
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (btnEdit.Text == "Edit")
        {
            txtDate.Enabled= true;
            btnEdit.Text = "Update";
            btnDelete.Text = "Cancel";
        }
        else if (btnEdit.Text == "Update")
        {
            try
            {
                Boolean sql = DAO.update(txtClassID.Text, Convert.ToDateTime(txtDate.Text));
                if (sql)
                {
                    Response.Redirect("admin_Class.aspx");
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
                err.ValidationGroup = "1";
                err.ErrorMessage = "The Date is invalid, Please Choose a day from calendar.";
                Page.Validators.Add(err);
                
                txtDate.BackColor = System.Drawing.Color.Red;
                return;
            }
        }
        else if (btnEdit.Text == "Cancel")
        {
            Response.Redirect("admin_Class.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (btnDelete.Text == "Cancel")
        {
            Response.Redirect("admin_Class.aspx");
        }
        else if (btnDelete.Text == "Delete")
        {
            btnDelete.Text = "Remove";
            btnEdit.Text = "Cancel";
        }
        else if (btnDelete.Text == "Remove")
        {
            Boolean sql = DAO.delete(txtClassID.Text);
            if (sql)
            {
                Response.Redirect("admin_Class.aspx");
                GridView1.EditIndex = -1;
                fillData();
                btnDelete.Text = "Delete";
            }
            else
            {
                Response.Write("Delete Failed");
                return;
            }
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtClassID.Text = GridView1.SelectedRow.Cells[1].Text;
        txtName.Text = GridView1.SelectedRow.Cells[2].Text;
        txtDate.Text = Convert.ToDateTime(GridView1.SelectedRow.Cells[3].Text).ToString("dd/MM/yyyy");
        btnEdit.Enabled = true;
        btnDelete.Enabled = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddClass.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin_Class.aspx?searchkey=" + txtSearch.Text.Trim());
    }
    protected void txtName_TextChanged(object sender, EventArgs e)
    {

    }
}