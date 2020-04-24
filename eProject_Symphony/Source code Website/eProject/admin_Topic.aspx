<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin_Topic.aspx.cs" Inherits="admin_Topic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
     <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Control Topic Details</h1>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" Width="53px" />
    </p>
    <p>Search By Course :
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
    </p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#FF3300" ValidationGroup="1" />
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" Width="610px"   AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" width="610px"/>
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
           <table style="width: 50%; margin:auto">
        <tr>
            <td style="width: 150px;text-align:right" >
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="13pt" Text="Topic ID :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="txtTopicID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
   
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="13pt" Text="Course ID :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="155px">
          </asp:DropDownList>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
  
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="13pt" Text="Topic Name :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="txtTopicName" runat="server"></asp:TextBox>
   

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTopicName" Display="Dynamic" ErrorMessage="Topic name not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTopicName" Display="Dynamic" ErrorMessage="Topic name invalid" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]\s{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
  
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="13pt" Text="Topic Des:"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="txtTopicDes" runat="server"></asp:TextBox>
   

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTopicDes" Display="Dynamic" ErrorMessage="Topic description not null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTopicDes" Display="Dynamic" ErrorMessage="Topic description invalid" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]\s{1,50}$" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
   

            </td>
        </tr>
       
       
   
        <tr>
            <td style="width: 150px">&nbsp;</td>
            <td>
   
                 &nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Edit" Width="62px" ValidationGroup="1" />
&nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete" />
            </td>
        </tr>
    </table>
   
   

</asp:Content>

