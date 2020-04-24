<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Course.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <li><a href="Home.aspx">Home</a></li>
        <li class="active"><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="article">
        <h2><span>Our Available Course</span></h2>
        <div class="clr"></div>
        
        <img src="images/images_1.jpg" width="613" height="193" alt="" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:DataList ID="DataList1" runat="server" CellPadding="4" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" ForeColor="#333333" Width="519px">
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <ItemTemplate>
                    <asp:Label ID="lblCoursename" runat="server" Text="Course Name: " Font-Bold="True" Font-Size="15pt"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("courseName") %>' Font-Size="15pt"></asp:Label><br />
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Select">Show Details</asp:LinkButton>
                    <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SelectedItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text="Course ID: " Font-Bold="True" Font-Size="15pt"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("CourseID") %>' Font-Size="15pt"></asp:Label>
                    <br />
                    <asp:Label ID="lblCoursename" runat="server" Font-Bold="True" Font-Size="15pt" Text="Course Name: "></asp:Label>
                    <asp:Label ID="Label2" runat="server" Font-Size="15pt" Text='<%# Eval("courseName") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="Course Fee: " Font-Bold="True" Font-Size="15pt"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("CourseFee") %>' Font-Size="15pt"></asp:Label>
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "Entrance.aspx?courseid="+ Eval("CourseID") %>'>Show Entrances</asp:HyperLink>
                    <br />

                </SelectedItemTemplate>
            </asp:DataList>
     
        <br />
        
     
        <div class="clr"></div>
      </div>
</asp:Content>

