<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddClass.aspx.cs" Inherits="AddClass" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">    
     <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Add Class Details</h1>
    
    <h1><asp:Label ID="lblConfrmStt" runat="server" ForeColor="#0066CC"></asp:Label></h1>
           <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#FF3300" ValidationGroup="1" />
           <br />
           <table style="width: 50%; margin:auto">
        <tr>
            <td style="width: 150px;text-align:right" >
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="13pt" Text="Class ID :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="txtClassID" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtClassID" Display="Dynamic" ErrorMessage="ClassID invalid" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtClassID" Display="Dynamic" ErrorMessage="ClassID not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
   
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="13pt" Text="Entrance ID :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:DropDownList ID="dpnEntranceID" runat="server" AutoPostBack="True" Width="155px">
          </asp:DropDownList>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
  
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="13pt" Text="Start Date :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="txtStartDate" runat="server" OnTextChanged="txtStartDate_TextChanged"></asp:TextBox>
   

                <asp:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtStartDate">
                </asp:CalendarExtender>
   

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStartDate" ErrorMessage="Start date not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
   

            </td>
        </tr>

        <tr>
            <td style="width: 150px">&nbsp;</td>
            <td><asp:Button ID="Button1" runat="server" Text="Add" Width="52px" OnClick="Button1_Click" ValidationGroup="1" />
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Reset" />
   

            </td>
        </tr>
    </table>
</asp:Content>

