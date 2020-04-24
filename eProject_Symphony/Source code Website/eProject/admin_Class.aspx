<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin_Class.aspx.cs" Inherits="admin_Class" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
     <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h1>Control Class Details</h1>
    <p>Search By Course Name :
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
    </p>
      <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#FF3300" ValidationGroup="1" />
    <asp:Button ID="btnAddClass" runat="server" Text="Add Class" OnClick="Button3_Click" CausesValidation="False" />
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
   <td style="width: 150px;text-align:right"><asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="13pt" Text="Class ID: "></asp:Label></td> 
   <td style="text-align:left"> <asp:TextBox ID="txtClassID" runat="server" Enabled="False"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtClassID" ErrorMessage="ClassID not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtClassID" Display="Dynamic" ErrorMessage="ClassID invalid" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
            </td>
  </tr>
        <tr>
   <td style="width: 150px;text-align:right">  <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="13pt" Text="Entrance Name: "></asp:Label></td>
   <td style="text-align:left">   <asp:TextBox ID="txtName" runat="server" Enabled="False" OnTextChanged="txtName_TextChanged"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="Entrance Name not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Entrance name invalid" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]\s{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
            </td>
             </tr>
        <tr>
   <td style="width: 150px;text-align:right; height: 26px;">  <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="13pt" Text="Start Date: "></asp:Label></td>
   <td style="text-align:left; height: 26px;"><asp:TextBox ID="txtDate" runat="server" Enabled="False"></asp:TextBox>
            <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDate">
       </asp:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDate" ErrorMessage="Start date not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
            </td>
             </tr>
         <tr>
            <td style="width: 150px">&nbsp;</td>
            <td>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="Button1_Click" ValidationGroup="1" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="Button2_Click" />
                </td>
             </tr>
 </table>
</asp:Content>

