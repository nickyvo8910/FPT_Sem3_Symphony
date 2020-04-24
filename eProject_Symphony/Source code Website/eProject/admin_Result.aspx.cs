using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    adminResultDAO DAO = new adminResultDAO();
   
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

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
        TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
        TextBox3.Text = Convert.ToDateTime(GridView1.SelectedRow.Cells[3].Text).ToString("dd/MM/yyyy");
        TextBox4.Text = GridView1.SelectedRow.Cells[4].Text;
        txtEnMark.Text = GridView1.SelectedRow.Cells[5].Text;
        Button1.Enabled = true;
        Button2.Enabled = true;
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Edit")
        {
            txtEnMark.Enabled = true;
            Button1.Text = "Update";
            Button2.Text = "Cancel";
        }
        else if (Button1.Text == "Update")
        {

            Boolean sql = DAO.update(TextBox1.Text, Convert.ToInt32(txtEnMark.Text));
            if (sql)
            {
                Response.Redirect("admin_Result.aspx");
                GridView1.EditIndex = -1;
                fillData();
            }
            else
            {
                Response.Write("Update Failed");
                return;
            }
        }
        else if (Button1.Text == "Cancel")
        {
            Response.Redirect("admin_Result.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Button2.Text == "Cancel")
        {
            Response.Redirect("admin_Result.aspx");
        }
        else if (Button2.Text == "Delete")
        {
            Button2.Text = "Remove";
            Button1.Text = "Cancel";
        }
        else if (Button2.Text == "Remove")
        {
            Boolean sql = DAO.delete(TextBox1.Text);
            if (sql)
            {
                Response.Redirect("admin_Result.aspx");
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin_Result.aspx?searchkey=" + txtSearch.Text.Trim());
    }
}