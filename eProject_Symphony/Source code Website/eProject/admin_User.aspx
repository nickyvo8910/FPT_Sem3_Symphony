<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin_User.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Control User Details</h1>
    <p>Search By UserName :
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click1" />
    </p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="610px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" width="610px" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
     </asp:GridView>
<table style="width: 50%; margin:auto">
        <tr>
   <td style="width: 150px;text-align:right"><asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="13pt" Text="Username ID: "></asp:Label></td> 
   <td style="text-align:left"> <asp:TextBox ID="txtID" runat="server" Enabled="False"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtID" Display="Dynamic" ErrorMessage="ID not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtID" Display="Dynamic" ErrorMessage="ID invalid" ForeColor="#FF3300" ValidationExpression="^[a-zA-Z0-9]{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
            </td>
  </tr>
        <tr>
   <td style="width: 150px;text-align:right; height: 51px;">  <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="13pt" Text="User Full Name: "></asp:Label></td>
   <td style="text-align:left; height: 51px;">   <asp:TextBox ID="txtName" runat="server" Enabled="False"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Full name not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Full name invalid" ForeColor="#FF3300" ValidationExpression="^[a-zA-Z0-9\s]{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
            </td>
             </tr>
        <tr>
   <td style="width: 150px;text-align:right">  <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="13pt" Text="User DOB: "></asp:Label></td>
   <td style="text-align:left">   <asp:TextBox ID="txtDOB" runat="server" Enabled="False"></asp:TextBox>
       <asp:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDOB">
       </asp:CalendarExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtID" Display="Dynamic" ErrorMessage="ID invalid" ForeColor="#FF3300" ValidationExpression="^[a-zA-Z0-9]{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
            </td>
             </tr>
        <tr>
   <td style="width: 150px;text-align:right">  <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="13pt" Text="User Email : "></asp:Label></td>
   <td style="text-align:left">   <asp:TextBox ID="txtEmail" runat="server" Enabled="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
            </td>
             </tr>
        <tr>
   <td style="width: 150px;text-align:right">  <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="13pt" Text="User Sex : "></asp:Label></td>
   <td style="text-align:left">   <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="91px" Enabled="False">
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:DropDownList>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownList1" Display="Dynamic" ErrorMessage="User sex not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
            </td>
             </tr>
         <tr>
            <td style="width: 150px">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" Enabled="False" OnClick="Button1_Click" Text="Edit" CausesValidation="False" ValidationGroup="1" />
                <asp:Button ID="Button2" runat="server" Enabled="False" OnClick="Button2_Click" Text="Delete" />
                </td>
             </tr>
 </table>
</asp:Content>

