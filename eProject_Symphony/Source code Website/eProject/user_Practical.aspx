<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="user_Practical.aspx.cs" Inherits="user_Practical" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Practical Session : <asp:Label ID="lblConfrmStt" runat="server" Visible="False">Unchecked</asp:Label></h1>
    <%if (lblConfrmStt.Text != "Activated" && lblConfrmStt.Text !="Signed")
      { %>
    <hr />
    <h2 style="text-align:center">Activate a Practical Session ? 
        <br />
        <asp:Button ID="btnComfirm" runat="server" Text="Register" OnClick="btnComfirm_Click" /></h2>
    <%} %>
    <p>&nbsp;</p>
</asp:Content>

