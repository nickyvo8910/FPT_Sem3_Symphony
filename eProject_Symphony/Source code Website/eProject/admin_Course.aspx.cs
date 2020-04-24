using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    adminCourseDAO DAO = new adminCourseDAO();
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
        Response.Redirect("AddCourse.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Button2.Text == "Edit")
        {
            txtCourseName.Enabled = true;
            txtCourseFee.Enabled = true;
            Button2.Text = "Update";
            Button3.Text = "Cancel";
        }
        else if (Button2.Text == "Update")
        {

            Boolean sql = DAO.update(txtCourseID.Text, txtCourseName.Text, Convert.ToSingle(txtCourseFee.Text));
            if (sql)
            {
                Response.Redirect("admin_Course.aspx");
                GridView1.EditIndex = -1;
                fillData();
            }
            else
            {
                Response.Write("Update Failed");
                return;
            }
        }
        else if (Button2.Text == "Cancel")
        {
            Response.Redirect("admin_Course.aspx");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Button3.Text == "Cancel")
        {
            Response.Redirect("admin_Course.aspx");
        }
        else if (Button3.Text == "Delete")
        {
            Button3.Text = "Remove";
            Button2.Text = "Cancel";
        }
        else if (Button3.Text == "Remove")
        {
            Boolean sql = DAO.delete(txtCourseID.Text);
            if (sql)
            {
                Response.Redirect("admin_Course.aspx");
                GridView1.EditIndex = -1;
                fillData();
                Button3.Text = "Delete";
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
        txtCourseID.Text = GridView1.SelectedRow.Cells[1].Text;
        txtCourseName.Text = GridView1.SelectedRow.Cells[2].Text;
        txtCourseFee.Text = GridView1.SelectedRow.Cells[3].Text;
        Button2.Enabled = true;
        Button3.Enabled = true;
      
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin_Course.aspx?searchkey=" + txtSearch.Text.Trim());
    }
}