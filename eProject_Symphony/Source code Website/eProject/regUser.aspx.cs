using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class regUser : System.Web.UI.Page
{
    regUserDAO DAO = new regUserDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("regUser.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Boolean sqlChk = DAO.chkUser(txtID.Text.Trim());
            if (!sqlChk)
            {
                Boolean sql = DAO.regUser(txtID.Text.Trim(), txtPass.Text.Trim(), txtName.Text.Trim(), DateTime.ParseExact(txtDOB.Text.Trim(), "dd/MM/yyyy", null), txtMail.Text.Trim(), cmbSex.SelectedItem.ToString());
                if (sql) Response.Redirect("Home.aspx");
                else
                {
                    Response.Write("Invalid");
                    return;
                }
            }
            else
            {
                CustomValidator errUser = new CustomValidator();
                errUser.IsValid = false;
                errUser.ErrorMessage = "This UserID is not available. Please Choose Another One.";
                Page.Validators.Add(errUser);

                txtID.BackColor = System.Drawing.Color.Red;
                return;
            }
        }
        catch (FormatException fe)
        {
            CustomValidator err = new CustomValidator();
            err.IsValid = false;
            err.ErrorMessage = "The DOB is invalid, Please Choose a day from calendar.";
            Page.Validators.Add(err);

            txtDOB.BackColor = System.Drawing.Color.Red;
            return;
        }
    }
}