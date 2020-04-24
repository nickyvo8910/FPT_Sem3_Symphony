using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddClass : System.Web.UI.Page
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
            foreach (DataRow dr in DAO.viewID().Rows)
            {
                dpnEntranceID.Items.Add(new ListItem(dr[0].ToString(), dr[0].ToString()));
            }
            //lblConfrmStt.Text = "";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        txtClassID.Text = "";
        txtStartDate.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (dpnEntranceID.SelectedItem.ToString() != "" && dpnEntranceID.Items.Count >= 1)
        {
            Boolean sqlChk = DAO.chkHasClass(dpnEntranceID.SelectedItem.Text.Trim());
            if (!sqlChk)
            {
                try
                {
                    Boolean sqlChkID = DAO.chkClass(txtClassID.Text.Trim());
                    if (!sqlChkID)
                    {
                        Boolean sql = DAO.add(txtClassID.Text, dpnEntranceID.SelectedItem.Text, Convert.ToDateTime(txtStartDate.Text));
                        if (sql)
                        {
                            Response.Redirect("admin_Class.aspx");
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
                        errUser.ErrorMessage = "This ClassID is not available. Please Choose Another One.";
                        Page.Validators.Add(errUser);

                        txtClassID.BackColor = System.Drawing.Color.Red;
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

                    txtStartDate.BackColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                lblConfrmStt.Text = "This entrance has already have a class";
                return;
            }
        }
        else
        {
            CustomValidator errUser = new CustomValidator();
            errUser.IsValid = false;
            errUser.ValidationGroup = "1";
            errUser.ErrorMessage = "Please Select A Valid Entrance ID";
            Page.Validators.Add(errUser);
            dpnEntranceID.BackColor = System.Drawing.Color.Red;
            return;
        }
    }
    protected void txtStartDate_TextChanged(object sender, EventArgs e)
    {

    }
}