using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eBank;
using System.Net.Sockets;
using System.Net;
using System.ServiceModel;

public partial class bankLogin : System.Web.UI.Page
{
    eBankSoapClient Client = new eBankSoapClient();
    bankLoginDAO DAO = new bankLoginDAO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["UserID"].ToString() == "admin")
        {
            Response.Redirect("Home.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["payID"] != null)
            {
                Boolean sqlLogin = Client.chkLogin(txtAcc.Text.Trim(), txtPIN.Text.Trim());
                if (sqlLogin)
                {
                    Boolean sqlPayment = Client.withdraw(txtAcc.Text.Trim(), DAO.getAmount(Convert.ToInt32(Request.QueryString["payID"].ToString())));
                    if (sqlPayment)
                    {
                        try
                        {
                            Boolean sqlDo = DAO.payPayment(Convert.ToInt32(Request.QueryString["PayID"].ToString()), Convert.ToInt32(txtAcc.Text.Trim()));
                            if (sqlDo)
                            {
                                Response.Redirect("user_Payment.aspx?userID=" + Session["UserID"].ToString());
                            }
                            else
                            {
                                lblErr.Text = "Invalid Action";
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex.Message);
                        }
                    }
                    else
                    {
                        lblErr.Text = "Invalid Payment";
                        return;
                    }
                }
                else
                {
                    lblErr.Text = "Invalid Login";
                    return;
                }
            }
            else
            {
                lblErr.Text = "Invalid PayID (Query String)";
                return;
            }
        }
        catch (SocketException se)
        {
            lblErr.Text = "Socket Error.Cannot Connect To Web Service. Please ReCheck Web Service Path";
            return;
        }
        catch (WebException we)
        {
            lblErr.Text = "Web Service Error.Cannot Connect To Web Service. Please ReCheck Web Service Path";
            return;
        }
        catch (EndpointNotFoundException epnfe)
        {
            lblErr.Text = "End Point Error.Cannot Connect To Web Service. Please ReCheck Web Service Path";
            return;
        }
    }
}