using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    FeedbackDAO DAO = new FeedbackDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataList1.DataSource = DAO.view();
        DataList1.DataBind();
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataList1.DataBind();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            Boolean sql = DAO.insFB(txtEmail.Text.Trim(), txtMess.Text.Trim());
            if (sql) Response.Redirect("Feedback.aspx");
            else
            {
                Response.Write("Invalid");
                return;
            }
        }
    }
}