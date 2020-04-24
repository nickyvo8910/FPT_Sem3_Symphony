<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="user_Payment.aspx.cs" Inherits="user_Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>This is Your Payment Details</h1>
    <br /><h1><asp:Label ID="lblConfrmStt" runat="server" Text=""></asp:Label></h1>
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="608px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
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
    <br />
    <%if(lblConfrmStt.Text !="Not available"){ %>
    <table style="width: 50%; margin:auto">
        <tr>
   <td style="width: 150px;text-align:right"><asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="13pt" Text="Payment ID: "></asp:Label></td> 
   <td style="text-align:left"> <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox></td>
  </tr>
         <tr>
            <td colspan="2" style="text-align:center">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Pay" Enabled="False" />
                </td>
             </tr>
 </table>
    <%} %>
</asp:Content>

