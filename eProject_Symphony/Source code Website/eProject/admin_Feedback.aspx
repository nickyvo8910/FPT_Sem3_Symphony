<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin_Feedback.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Control Feedback Details</h1>
    <p>Search By ID  :
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
    </p>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="610px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
    <table style="width: 54%; margin:auto">
        <tr>
            <td style="width: 150px;text-align:right" >
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="13pt" Text="FAQ ID :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
   
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="13pt" Text="FAQ Quesion :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="TextBox2" runat="server" Enabled="False" TextMode="MultiLine"></asp:TextBox>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
  
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="13pt" Text="FAQ Answer :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="txtAnswer" runat="server" Enabled="False" TextMode="MultiLine"></asp:TextBox>
   

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAnswer" Display="Dynamic" ErrorMessage="FAQ answer not null" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAnswer" Display="Dynamic" ErrorMessage="FAQ Answer invalid" ForeColor="#FF3300" ValidationExpression="^[a-zA-Z0-9]\s{1,500}$" ValidationGroup="1"></asp:RegularExpressionValidator>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Edit" ValidationGroup="1" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete" />

   </td>
        </tr>
    </table>
</asp:Content>

