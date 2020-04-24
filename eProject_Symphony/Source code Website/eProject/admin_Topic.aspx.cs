using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Topic : System.Web.UI.Page
{
    adminTopic DAO = new adminTopic();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        txtTopicID.Enabled = false;
        txtTopicDes.Enabled = false;
        txtTopicName.Enabled = false;
        DropDownList1.Enabled = false;
        if (!IsPostBack)
        {
            if (Session["UserID"] == null || Session["UserID"].ToString() != "admin")
            {
                Response.Redirect("Home.aspx");
            }
            fillData();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddTopic.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtTopicID.Text = GridView1.SelectedRow.Cells[1].Text;
        txtTopicName.Text = GridView1.SelectedRow.Cells[3].Text;
        txtTopicDes.Text = GridView1.SelectedRow.Cells[4].Text;
        
        
        foreach (DataRow dr in DAO.viewID().Rows)
        {
            DropDownList1.Items.Add(new ListItem(dr[0].ToString(), dr[1].ToString()));
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        txtTopicID.Enabled = true;
        txtTopicName.Enabled = true;
        txtTopicDes.Enabled = true;
        DropDownList1.Enabled = true;

        if (Button3.Text == "Edit")
        {

            Button3.Text = "Update";
            Button2.Text = "Cancel";
        }
        else if (Button3.Text == "Update")
        {
            if (DropDownList1.SelectedItem.ToString() != "" && DropDownList1.Items.Count >= 1)
            {
                Boolean sql = DAO.update(txtTopicID.Text, DropDownList1.SelectedItem.ToString(), txtTopicName.Text, txtTopicDes.Text);
                if (sql)
                {
                    Response.Redirect("admin_Topic.aspx");
                    GridView1.EditIndex = -1;
                    fillData();
                    Button3.Text = "Edit";
                }
                else
                {
                    Response.Write("Update Failed");
                    return;
                }
            }
            else
            {
                CustomValidator errUser = new CustomValidator();
                errUser.IsValid = false;
                errUser.ErrorMessage = "Please Select A Valid Course ID";
                errUser.ValidationGroup = "1";
                Page.Validators.Add(errUser);
                DropDownList1.BackColor = System.Drawing.Color.Red;
                return;
            }
        }
        else if (Button3.Text == "Cancel")
        {
            Response.Redirect("admin_Topic.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Button2.Text == "Cancel")
        {
            Response.Redirect("admin_Topic.aspx");
        }
        else if (Button2.Text == "Delete")
        {
            Button2.Text = "Remove";
            Button3.Text = "Cancel";
        }
        else if (Button2.Text == "Remove")
        {
            Boolean sql = DAO.delete(txtTopicID.Text);
            if (sql)
            {
                Response.Redirect("admin_Topic.aspx");
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin_Topic.aspx?searchkey=" + txtSearch.Text.Trim());
    }
}