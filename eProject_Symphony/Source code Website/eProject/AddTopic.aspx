<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddTopic.aspx.cs" Inherits="AddTopic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
     <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Add Topic Details</h1>
           <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
           <br />
           <table style="width: 50%; margin:auto">
        <tr>
            <td style="width: 150px;text-align:right" >
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="13pt" Text="Topic ID :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="txtTopicID" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTopicID" Display="Dynamic" ErrorMessage="TopicID  invalid" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTopicID" Display="Dynamic" ErrorMessage="Topic ID not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
   
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="13pt" Text="Course ID :"></asp:Label>
            </td>
            <td style="text-align:left">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="126px">
                </asp:DropDownList>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
  
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="13pt" Text="Topic Name :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
   

                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Topic name  invalid" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]\s{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Topic name not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right; height: 26px;" >
  
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="13pt" Text="Topic Des:"></asp:Label>
            </td>
            <td style="text-align:left; height: 26px;"><asp:TextBox ID="txtDes" runat="server"></asp:TextBox>
   

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDes" Display="Dynamic" ErrorMessage="Topic description not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtDes" Display="Dynamic" ErrorMessage="Topic description  invalid" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]\s{1,500}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
   

            </td>
        </tr>
       
       
   
        <tr>
            <td style="width: 150px">&nbsp;</td>
            <td><asp:Button runat="server" Text="Add" Width="52px" OnClick="Button1_Click" ValidationGroup="1" />
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Reset" />
   

            </td>
        </tr>
    </table>
</asp:Content>

