using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Entrance : System.Web.UI.Page
{
    EntranceDAO DAO = new EntranceDAO(); 
    protected  void  Page_Load(object  sender, EventArgs  e)
    {
        if (Request.QueryString["courseid"] != null)
        {
            DataList1.DataSource = DAO.view(Request.QueryString["courseid"].ToString());
            DataList1.DataBind();
        }

        else
        {
            Response.Write("Invalid Course");
        }
    }
   
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataList1.DataBind();
    }
    
}