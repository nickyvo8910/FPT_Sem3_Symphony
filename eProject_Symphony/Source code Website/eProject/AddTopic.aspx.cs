using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddTopic : System.Web.UI.Page
{
    adminTopic DAO = new adminTopic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] == null || Session["UserID"].ToString() != "admin")
            {
                Response.Redirect("Home.aspx");
            }
            foreach (DataRow dr in DAO.viewID().Rows)
            {
            DropDownList1.Items.Add(new ListItem(dr[0].ToString(), dr[1].ToString()));
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.ToString() != "" && DropDownList1.Items.Count >= 1)
        {
            Boolean sqlChkID = DAO.chkTopic(txtTopicID.Text.Trim());
            if (!sqlChkID)
            {
                Boolean sql = DAO.add(txtTopicID.Text, DropDownList1.SelectedItem.Text, txtName.Text, txtDes.Text);
                if (sql)
                {
                    Response.Redirect("admin_Topic.aspx");
                }
                else
                {
                    Response.Write("Add Failed");
                    return;
                }
            }
            else
            {
                CustomValidator errUser = new CustomValidator();
                errUser.IsValid = false;
                errUser.ErrorMessage = "This TopicID is not available. Please Choose Another One.";
                Page.Validators.Add(errUser);
                errUser.ValidationGroup = "1";
                txtTopicID.BackColor = System.Drawing.Color.Red;
                return;
            }
        }
        else
        {
            CustomValidator errUser = new CustomValidator();
            errUser.IsValid = false;
            errUser.ErrorMessage = "Please Select A Valid Course ID";
            Page.Validators.Add(errUser);
            errUser.ValidationGroup = "1";
            DropDownList1.BackColor = System.Drawing.Color.Red;
            return;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtTopicID.Text = "";
        txtName.Text = "";
        txtDes.Text = "";
    }
}