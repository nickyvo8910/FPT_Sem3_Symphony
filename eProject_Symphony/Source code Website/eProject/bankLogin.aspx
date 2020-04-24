<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="bankLogin.aspx.cs" Inherits="bankLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">    
    <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>eBanking Login Form        </h1>
    
    <h2 style="text-align:center">Please Login To Confirm Payment</h2>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <h2 style="text-align:center"><asp:Label ID="lblErr" runat="server" ForeColor="#0066CC"></asp:Label></h2>
    <br />
    <table style="width:50%;margin:auto">
        <tr>
            <td style="width:150px">Bank Account :</td>
            <td>
                <asp:TextBox ID="txtAcc" runat="server" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="Field Must Not Be Null" ForeColor="Red" ControlToValidate="txtAcc">(*)</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ErrorMessage="Invalid Format" ForeColor="Red" ControlToValidate="txtAcc" ValidationExpression="^[0-9]{1,20}">(*)</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width:150px">Account PIN :</td>
            <td>
                <asp:TextBox ID="txtPIN" runat="server" TextMode="Password" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="Field Must Not Be Null" ForeColor="Red" ControlToValidate="txtPIN">(*)</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ErrorMessage="Invalid Format" ForeColor="Red" ControlToValidate="txtPIN" ValidationExpression="^[0-9]{1,20}">(*)</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center"><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>

