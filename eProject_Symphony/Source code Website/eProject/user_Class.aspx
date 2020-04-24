<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="user_Class.aspx.cs" Inherits="user_Class" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h1>This is Your Class Details</h1>
     <br />
    <h1><asp:Label ID="lblConfrmStt" runat="server" Text=""></asp:Label>&nbsp;</h1>
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="608px">
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
</asp:Content>

