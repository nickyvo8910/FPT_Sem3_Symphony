using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCourse : System.Web.UI.Page
{
    adminCourseDAO DAO = new adminCourseDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null || Session["UserID"].ToString() != "admin")
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtCourseID.Text = "";
        txtFee.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Boolean sqlChkID = DAO.chkCourse(txtCourseID.Text.Trim());
        if (!sqlChkID)
        {
            Boolean sql = DAO.add(txtCourseID.Text, txtName.Text, Convert.ToDecimal(txtFee.Text));
            if (sql)
            {
                Response.Redirect("admin_Course.aspx");
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
            errUser.ValidationGroup = "1";
            errUser.ErrorMessage = "This CourseID is not available. Please Choose Another One.";
            Page.Validators.Add(errUser);

            txtCourseID.BackColor = System.Drawing.Color.Red;
            return;
        }
    }
}