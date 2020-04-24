<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="user_RegExam.aspx.cs" Inherits="user_RegExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2></h2>
    <h1><asp:Label ID="lblConfrmStt" runat="server" Text=""></asp:Label></h1>
    <%if(lblConfrmStt.Text.Equals("OK")){ %>
    <h2>Please Choose a Course : <asp:DropDownList ID="dropCourse" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropCourse_SelectedIndexChanged">
        <asp:ListItem Value="0">&lt;Select&gt;</asp:ListItem>
        </asp:DropDownList></h2>
    <hr />
    <h2>Please Choose an Entrance Exam : <asp:DropDownList ID="dropEntrance" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropEntrance_SelectedIndexChanged">
        <asp:ListItem Value="0">&lt;Select&gt;</asp:ListItem>
        </asp:DropDownList></h2>
        
    <hr />
    <h2>Here Is Your Entrance Exam Details:</h2>
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
    <br />
    <h2 style="text-align:center"><asp:Button ID="btnReg" runat="server" Text="Register" OnClick="btnReg_Click" />&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Reload" CausesValidation="False" OnClick="btnCancel_Click" />
    </h2>
    <%} %>
</asp:Content>

