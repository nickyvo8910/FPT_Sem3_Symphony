using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class user_RegExam : System.Web.UI.Page
{
    user_RegExamDAO DAO = new user_RegExamDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserID"] == null || Session["UserID"].ToString() == "admin")
            {
                Response.Redirect("Home.aspx");
            }
            if (Request.QueryString["userID"] != null)
            {
                if (!DAO.chkClass(Request.QueryString["userID"].ToString()))
                {
                    lblConfrmStt.Text = "OK";
                    lblConfrmStt.Visible = false;
                    foreach (DataRow dr in DAO.getCourse().Rows)
                    {
                        dropCourse.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
                    }
                }
                else
                {
                    lblConfrmStt.Text = "You've already been divided into classes.For any problem, contacts our center agent";
                    lblConfrmStt.Visible = true;
                }
            }
            else
            {
                Response.Write("Invalid User");
            }
        }
    }
    protected void dropCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        dropEntrance.Items.Clear();
	dropEntrance.Items.Add(new ListItem("<Select>"));
        DetailsView1.DataSource = null;
        DetailsView1.DataBind();
        if (dropCourse.SelectedIndex > 0)
        {
            for (int i = 1; i < dropEntrance.Items.Count; i++)
            {
                if (dropEntrance.Items[i] != null)
                {
                    dropEntrance.Items.RemoveAt(i);
                }
            }
            DataTable dtTab = new DataTable();
            dtTab= DAO.getEntrance(dropCourse.SelectedValue.ToString());
            foreach (DataRow dr in dtTab.Rows)
            {
                dropEntrance.Items.Add(dr[0].ToString());
            }
        }
    }
    protected void dropEntrance_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropEntrance.SelectedIndex > 0)
        {
            DataTable dtTab = new DataTable();
            dtTab = DAO.getEntranceDetail(dropEntrance.SelectedItem.ToString());

            DetailsView1.DataSource = dtTab;
            DetailsView1.DataBind();
        }
    }
    protected void btnReg_Click(object sender, EventArgs e)
    {
        if (dropCourse.SelectedIndex > 0 && dropEntrance.SelectedIndex > 0)
        {
            DataTable dtTab = new DataTable();
            dtTab = DAO.getEntranceDetail(dropEntrance.SelectedItem.ToString());
            Boolean sql = DAO.regExam(Session["userID"].ToString(), Convert.ToDecimal(dtTab.Rows[0][3].ToString()),dropEntrance.SelectedItem.ToString());
            if (sql) Response.Redirect("Home.aspx");
            else
            {
                Response.Write("False");
                return;
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("user_RegExam.aspx");
    }
}