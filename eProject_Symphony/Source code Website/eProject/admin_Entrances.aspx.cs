using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{  
    adminEntrancesDAO DAO = new adminEntrancesDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Enabled = false;
        if (!IsPostBack)
        {
            if (Session["UserID"] == null || Session["UserID"].ToString() != "admin")
            {
                Response.Redirect("Home.aspx");
            }
            fillData();
            foreach (DataRow dr in DAO.viewID().Rows)
            {
                DropDownList1.Items.Add(new ListItem(dr[0].ToString(), dr[1].ToString()));
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddEntrance.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Button2.Text == "Cancel")
        {
            Response.Redirect("admin_Entrances.aspx");
        }
        else if (Button2.Text == "Delete")
        {
            Button2.Text = "Remove";
            Button3.Text = "Cancel";
        }
        else if (Button2.Text == "Remove")
        {
            Boolean sql = DAO.delete(TextBox1.Text);
            if(sql)
            {
                Response.Redirect("admin_Entrances.aspx");
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
    protected void Button3_Click(object sender, EventArgs e)
    {
          if (Button3.Text=="Edit")
        {           
            Button3.Text ="Update";
            Button2.Text = "Cancel";
            TextBox2.Enabled = true;
            DropDownList1.Enabled = true;
            TextBox4.Enabled = true; TextBox5.Enabled = true;
            TextBox6.Enabled = true;
            TextBox7.Enabled = true;

        }
          else if (Button3.Text == "Update")
          {
              try
              {
                  if (DropDownList1.SelectedItem.ToString() != "" && DropDownList1.Items.Count >= 1)
                  {
                      Boolean chkDate = DAO.chkStartDoEnd(DateTime.ParseExact(TextBox5.Text.Trim(), "dd/MM/yyyy", null), DateTime.ParseExact(TextBox6.Text.Trim(), "dd/MM/yyyy", null), DateTime.ParseExact(TextBox7.Text.Trim(), "dd/MM/yyyy", null));
                      if (chkDate)
                      {
                          Boolean sql = DAO.update(TextBox1.Text, TextBox2.Text, Convert.ToSingle(TextBox4.Text), DropDownList1.SelectedItem.ToString(), DateTime.ParseExact(TextBox5.Text.Trim(), "dd/MM/yyyy", null), DateTime.ParseExact(TextBox6.Text.Trim(), "dd/MM/yyyy", null), DateTime.ParseExact(TextBox7.Text.Trim(), "dd/MM/yyyy", null));
                          if (sql)
                          {
                              Response.Redirect("admin_Entrances.aspx");
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
          else if (Button3.Text == "Cancel")
          {
              Response.Redirect("admin_Entrances.aspx");
          }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
        TextBox2.Text = GridView1.SelectedRow.Cells[3].Text;
        TextBox4.Text = GridView1.SelectedRow.Cells[4].Text;
        TextBox5.Text = Convert.ToDateTime(GridView1.SelectedRow.Cells[5].Text).Date.ToString("dd/MM/yyyy");
        TextBox6.Text = Convert.ToDateTime(GridView1.SelectedRow.Cells[6].Text).Date.ToString("dd/MM/yyyy");
        TextBox7.Text = Convert.ToDateTime(GridView1.SelectedRow.Cells[7].Text).Date.ToString("dd/MM/yyyy");
        Button2.Enabled = true; Button3.Enabled = true;
        
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin_Entrances.aspx?searchkey=" + txtSearch.Text.Trim());
    }
}