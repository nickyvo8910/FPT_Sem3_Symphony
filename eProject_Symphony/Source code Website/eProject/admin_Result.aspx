<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin_Result.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Control Result Details</h1>
    <p>Search By UserName :
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
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
   <td style="text-align:left; width: 145px;"> <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox></td>
  </tr>
        <tr>
   <td style="width: 150px;text-align:right">  <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="13pt" Text="User Full Name: "></asp:Label></td>
   <td style="text-align:left; width: 145px;">   <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox></td>
             </tr>
        <tr>
   <td style="width: 150px;text-align:right">  <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="13pt" Text="User DOB: "></asp:Label></td>
   <td style="text-align:left; width: 145px;">   <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
            </td>
             </tr>
        <tr>
   <td style="width: 150px;text-align:right">  <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="13pt" Text="User Sex : "></asp:Label></td>
   <td style="text-align:left; width: 145px;">   <asp:TextBox ID="TextBox4" runat="server" Enabled="False"></asp:TextBox>
            </td>
             </tr>
        <tr>
   <td style="width: 150px;text-align:right">  <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="13pt" Text="Entrance Mark : "></asp:Label></td>
   <td style="text-align:left; width: 145px;">   <asp:TextBox ID="txtEnMark" runat="server" Enabled="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEnMark" Display="Dynamic" ErrorMessage="Entrance Mark not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEnMark" Display="Dynamic" ErrorMessage="Entrance Mark invalid" ForeColor="Red" ValidationExpression="^[0-9]{1,2}0?$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
            </td>
             </tr>
        
         <tr>
            <td style="width: 150px">&nbsp;</td>
            <td style="width: 145px">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Edit" ValidationGroup="1" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete" />
                </td>
             </tr>
 </table>
</asp:Content>

