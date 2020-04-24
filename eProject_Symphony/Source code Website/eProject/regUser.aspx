<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="regUser.aspx.cs" Inherits="regUser" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">  
    <h1 style="text-align:center">Registration Form     
    </h1>
        <table style="font-size:medium;color:black;text-align:center;width:100%">
        <tr><td colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td></tr>
        <tr><td colspan="2"></td></tr>
        <tr style="width:100%">
            <td style="text-align:right;width:50%">User ID : </td>
            <td style="text-align:left;width:50%"><asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtID" Display="Dynamic" ErrorMessage="ID Field Must Not Be Null" ForeColor="Red">(*)</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="width:100%">
            <td style="text-align:right;width:50%">Password : </td>
            <td style="text-align:left;width:50%"><asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" Display="Dynamic" ErrorMessage="Password Field Must Not Be Null" ForeColor="Red">(*)</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="width:100%">
            <td style="text-align:right;width:50%">Full Name : </td>
            <td style="text-align:left;width:50%"><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr style="width:100%">
            <td style="text-align:right;vertical-align:top;width:50%">Date Of Birth : </td>
            <td style="text-align:left;width:50%"><asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDOB" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDOB" Display="Dynamic" ErrorMessage="DOB Field Must Not Be Null" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr style="width:100%">
            <td style="text-align:right;width:50%">Email : </td>
            <td style="text-align:left;width:50%"><asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMail" Display="Dynamic" ErrorMessage="Email Field Must Not Be Null" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" Display="Dynamic" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">(*)</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr style="width:100%">
            <td style="text-align:right;width:50%">Sex : </td>
            <td style="text-align:left;width:50%">
                <asp:DropDownList ID="cmbSex" runat="server">
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
             <tr style="width:100%">
            <td style="text-align:right;width:50%">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
            <td style="text-align:left;width:50%">
                <asp:Button ID="btnReset" runat="server" Text="Reset" CausesValidation="False" OnClick="btnReset_Click" /></td>
        </tr>
    </table>
</asp:Content>

