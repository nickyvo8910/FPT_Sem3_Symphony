<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin_Course.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">    
     <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Control Course Details</h1>
    <p>Search By Course Name :
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" Width="53px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#FF3300" ValidationGroup="1" />
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="610px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" Width="610px" />
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
   <td style="width: 150px;text-align:right"><asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="13pt" Text="Course ID: "></asp:Label></td> 
   <td style="text-align:left"> <asp:TextBox ID="txtCourseID" runat="server" Enabled="False"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCourseID" Display="Dynamic" ErrorMessage="Course ID not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCourseID" Display="Dynamic" ErrorMessage="CourseID invalid" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
            </td>
  </tr>
        <tr>
   <td style="width: 150px;text-align:right">  <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="13pt" Text="Course Name: "></asp:Label></td>
   <td style="text-align:left">   <asp:TextBox ID="txtCourseName" runat="server" Enabled="False"></asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCourseName" Display="Dynamic" ErrorMessage="Course name not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCourseName" Display="Dynamic" ErrorMessage="Course name invalid" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]\s{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
            </td>
             </tr>
        <tr>
   <td style="width: 150px;text-align:right">  <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="13pt" Text="Course Fee: "></asp:Label></td>
   <td style="text-align:left">   <asp:TextBox ID="txtCourseFee" runat="server" Enabled="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCourseFee" Display="Dynamic" ErrorMessage="Course fee not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Course fee invalid" ForeColor="Red" ValidationExpression="^[0-9]{1,50}$" ValidationGroup="1" ControlToValidate="txtCourseFee" Display="Dynamic">(*)</asp:RegularExpressionValidator>
            </td>
             </tr>
         <tr>
            <td style="width: 150px">&nbsp;</td>
            <td>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Edit" />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Delete" />
                </td>
             </tr>
 </table>
</asp:Content>

