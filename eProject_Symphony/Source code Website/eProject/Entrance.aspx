<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Entrance.aspx.cs" Inherits="Entrance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <asp:Label ID="Label1" runat="server" Font-Size="16pt" ForeColor="#0066FF" Text="Recent and Upcoming Entrance Exams"></asp:Label><br />
        <asp:Label ID="Label10" runat="server" Font-Size="14pt" ForeColor="#0066FF" Text="...For your course..."></asp:Label>


</p>
    <p>
    <br />
        <asp:DataList ID="DataList1" runat="server" CellPadding="4" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" Width="381px" ForeColor="#333333">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text="Entrance Title: " Font-Size="15pt"></asp:Label>
                <asp:Label ID="Label3" runat="server" Font-Size="12pt" Text='<%# Eval("entranceTitle") %>'></asp:Label>
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select">Show Details</asp:LinkButton>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SelectedItemTemplate>
                <asp:Label ID="Label12" runat="server" Font-Size="15pt" Text="Entrance ID: "></asp:Label>
                <asp:Label ID="Label13" runat="server" Font-Size="12pt" ForeColor="Black" Text='<%# Eval("entranceID") %>'></asp:Label>
                <br />
                <asp:Label ID="Label10" runat="server" Font-Size="15pt" Text="Entrance Title: "></asp:Label>
                <asp:Label ID="Label11" runat="server" Font-Size="12pt" ForeColor="Black" Text='<%# Eval("entranceTitle") %>'></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15pt" Text="Entrance Fee: "></asp:Label>
                <asp:Label ID="Label6" runat="server" Font-Size="12pt" Text='<%# Eval("entranceFee") %>' ForeColor="Black"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="15pt" Text="Start Date: "></asp:Label>
                <asp:Label ID="Label7" runat="server" Font-Size="12pt" Text='<%# Eval("startDate") %>' ForeColor="Black"></asp:Label>
                <br />
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="15pt" Text="End Date: "></asp:Label>
                <asp:Label ID="Label8" runat="server" Font-Size="12pt" Text='<%# Eval("endDate") %>' ForeColor="Black"></asp:Label>
                <br />
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="15pt" Text="Entrance Date: "></asp:Label>
                <asp:Label ID="Label9" runat="server" Font-Size="12pt" Text='<%# Eval("entranceDate") %>' ForeColor="Black"></asp:Label>
            </SelectedItemTemplate>
        </asp:DataList>
</p>

<p>
</p>
</asp:Content>

