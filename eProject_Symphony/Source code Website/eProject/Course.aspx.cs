using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["searchkey"] != null)
            {
                if (DAO.dtSet.Tables["Course"] != null)
                    DAO.dtSet.Tables.Remove("Course");
                DAO.sqlCom.CommandText = "searchCourse";
                DAO.sqlCom.CommandType = CommandType.StoredProcedure;
                DAO.sqlCom.Parameters.Clear();
                DAO.sqlCom.Parameters.AddWithValue("@key", Request.QueryString["searchkey"].ToString());
                DAO.sqlCom.Connection = DAO.sqlCon;
                DAO.sqlAdap.SelectCommand = DAO.sqlCom;
                DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
                DAO.sqlAdap.Fill(DAO.dtSet, "Course");
                DataList1.DataSource = DAO.dtSet.Tables["Course"];
                DataList1.DataBind();
            }
            else
            {
                if (DAO.dtSet.Tables["Course"] != null)
                    DAO.dtSet.Tables.Remove("Course");
                DAO.sqlCom.CommandText = "getCourse";
                DAO.sqlCom.CommandType = CommandType.StoredProcedure;
                DAO.sqlCom.Connection = DAO.sqlCon;
                DAO.sqlAdap.SelectCommand = DAO.sqlCom;
                DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
                DAO.sqlAdap.Fill(DAO.dtSet, "Course");
                DataList1.DataSource = DAO.dtSet.Tables["Course"];
                DataList1.DataBind();
            }
        }
    }
 

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["searchkey"] != null)
        {
            if (DAO.dtSet.Tables["Course"] != null)
                DAO.dtSet.Tables.Remove("Course");
            DAO.sqlCom.CommandText = "searchCourse";
            DAO.sqlCom.CommandType = CommandType.StoredProcedure;
            DAO.sqlCom.Connection = DAO.sqlCon;
            DAO.sqlAdap.SelectCommand = DAO.sqlCom;
            DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
            DAO.sqlAdap.Fill(DAO.dtSet, "Course");
            DataList1.DataSource = DAO.dtSet.Tables["Course"];
            DataList1.DataBind();
        }
        else
        {

            if (DAO.dtSet.Tables["Course"] != null)
                DAO.dtSet.Tables.Remove("Course");
            DAO.sqlCom.CommandText = "getCourse";
            DAO.sqlCom.CommandType = CommandType.StoredProcedure;
            DAO.sqlCom.Connection = DAO.sqlCon;
            DAO.sqlAdap.SelectCommand = DAO.sqlCom;
            DAO.sqlAdap = new SqlDataAdapter(DAO.sqlCom);
            DAO.sqlAdap.Fill(DAO.dtSet, "Course");
            DataList1.DataSource = DAO.dtSet.Tables["Course"];
            DataList1.DataBind();
        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Entrance.aspx?courseid=");
    }
}