using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddEntrance : System.Web.UI.Page
{
    adminEntrancesDAO DAO = new adminEntrancesDAO(); 
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddEntrance.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedItem.ToString() != "" && DropDownList1.Items.Count >= 1)
            {
                Boolean sqlChkID = DAO.chkEntrance(TextBox1.Text.Trim());
                if (!sqlChkID)
                {
                    Boolean chkDate = DAO.chkStartDoEnd(DateTime.ParseExact(TextBox5.Text.Trim(), "dd/MM/yyyy", null), DateTime.ParseExact(TextBox6.Text.Trim(), "dd/MM/yyyy", null), DateTime.ParseExact(TextBox7.Text.Trim(), "dd/MM/yyyy", null));
                    if (chkDate)
                    {
                        Boolean sql = DAO.add(TextBox1.Text, TextBox2.Text, Convert.ToSingle(TextBox4.Text), DropDownList1.SelectedItem.Text, DateTime.ParseExact(TextBox5.Text.Trim(), "dd/MM/yyyy", null), DateTime.ParseExact(TextBox6.Text.Trim(), "dd/MM/yyyy", null), DateTime.ParseExact(TextBox7.Text.Trim(), "dd/MM/yyyy", null));
                        if (sql)
                        {
                            Response.Redirect("admin_Entrances.aspx");
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
                        errUser.ErrorMessage = "Date Fields are INVALID.End Date Must Be In Between Of Start Date and Entrance Date";
                        Page.Validators.Add(errUser);

                        TextBox5.BackColor = System.Drawing.Color.Red;
                        TextBox6.BackColor = System.Drawing.Color.Red;
                        TextBox7.BackColor = System.Drawing.Color.Red;
                        return;
                    }
                }
                else
                {
                    CustomValidator errUser = new CustomValidator();
                    errUser.IsValid = false;
                    errUser.ValidationGroup = "1";
                    errUser.ErrorMessage = "This EntranceID is not available. Please Choose Another One.";
                    Page.Validators.Add(errUser);

                    TextBox1.BackColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                CustomValidator errUser = new CustomValidator();
                errUser.IsValid = false;
                errUser.ValidationGroup = "1";
                errUser.ErrorMessage = "Please Select A Valid Course ID";
                Page.Validators.Add(errUser);
                DropDownList1.BackColor = System.Drawing.Color.Red;
                return;
            }
        }
        catch (FormatException fe)
        {
            CustomValidator errUser = new CustomValidator();
            errUser.IsValid = false;
            errUser.ValidationGroup = "1";
            errUser.ErrorMessage = "Date Fields are INVALID.Please Choose From Calendar.";
            Page.Validators.Add(errUser);

            TextBox5.BackColor = System.Drawing.Color.Red;
            TextBox6.BackColor = System.Drawing.Color.Red;
            TextBox7.BackColor = System.Drawing.Color.Red;
            return;
        }
    }
   
}