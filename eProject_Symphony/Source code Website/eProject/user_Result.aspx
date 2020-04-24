<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="user_Result.aspx.cs" Inherits="user_Result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>This is Your Lastest Exam Results</h1>
    <asp:DetailsView ID="DetailsView1" runat="server" CellPadding="4" Font-Size="Medium" ForeColor="#333333" GridLines="None" Height="50px" style="margin-left: 155px" Width="310px">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>    
    <hr />
    <h1 style="text-align:center"><asp:Label ID="lblConfrmStt" runat="server" Text=""></asp:Label></h1>
    <h1 style="text-align:center"><asp:Label ID="lblPrac" runat="server" Text=""></asp:Label></h1>
    
    <%if (lblConfrmStt.Text != "Confirmed" && lblConfrmStt.Text != "Not available")
      {%>    
        <hr /><%if (lblPrac.Text != "Activated" && lblPrac.Text != "Signed")
      { %>
    <h2 style="text-align:center">Register a Practical Session ? 
        <asp:DropDownList ID="dropPractical" runat="server">
        <asp:ListItem Value="1">Yes</asp:ListItem>
        <asp:ListItem Value="0">No</asp:ListItem>
        </asp:DropDownList><br /></h2>
    <%} %>
        <h2 style="text-align:center"><asp:Button ID="btnComfirm" runat="server" Text="Confirm" OnClick="btnComfirm_Click" /></h2>
    <% }%>
    <br />
    </asp:Content>

