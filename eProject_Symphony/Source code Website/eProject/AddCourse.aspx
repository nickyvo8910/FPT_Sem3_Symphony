<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AddCourse.aspx.cs" Inherits="AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
     <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Add Course Details</h1>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="1" />
    <br />
    <table style="width: 50%; margin:auto">
        <tr>
            <td style="width: 150px;text-align:right" >
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="13pt" Text="Course ID :"></asp:Label>
            </td>
             <td style="text-align:left; width: 143px;"><asp:TextBox ID="txtCourseID" runat="server" style="margin-left: 0px"></asp:TextBox>
   
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCourseID" Display="Dynamic" ErrorMessage="CourseID not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCourseID" Display="Dynamic" ErrorMessage="CourseID invalid" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
   
            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right; height: 26px;" >
   
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="13pt" Text="Course Name :"></asp:Label>
            </td>
             <td style="text-align:left; height: 26px; width: 143px;"><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
  
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Course Name not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="CourseI name invalid" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]\s{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
  
            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
  
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="13pt" Text="Course Fee :"></asp:Label>
            </td>
            <td style="text-align:left; width: 143px;"><asp:TextBox ID="txtFee" runat="server"></asp:TextBox>
   

                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFee" Display="Dynamic" ErrorMessage="Course fee not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFee" Display="Dynamic" ErrorMessage="Course fee must be numberic" ForeColor="Red" ValidationExpression="^[0-9]{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
   

            </td>
        </tr>
        <tr>
            <td style="width: 152px">&nbsp;</td>
            <td style="width: 143px"><asp:Button ID="btnAdd" runat="server" Text="Add" Width="52px" OnClick="Button1_Click" ValidationGroup="1" />
&nbsp;<asp:Button ID="btnReset" runat="server" OnClick="Button2_Click" Text="Reset" />
   

            </td>
        </tr>
    </table>
    </asp:Content>

