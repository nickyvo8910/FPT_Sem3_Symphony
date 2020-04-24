<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin_Entrances.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">    
     <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Control Entrances Details</h1>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <p>Search By Course  :
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" CausesValidation="False" />
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" Width="53px" CausesValidation="False" />
    </p>
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

    <br />
    <table style="width: 50%; margin:auto">
        <tr>
            <td style="width: 150px;text-align:right" >
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="12pt" Text="Entrance ID :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="TextBox1" runat="server" Enabled="False" Width="120px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="ID Field Must Not Be Null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Invalid ID" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]{1,50}" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
   
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="12pt" Text="Course ID :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="120px" Enabled="False">
          </asp:DropDownList>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
  
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="12pt" Text="Entrance Title :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="TextBox2" runat="server" Enabled="False" Width="120px"></asp:TextBox>
   

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Title Field Must Not Be Null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Invalid Title" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9][a-zA-Z0-9\s]{1,50}" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
  
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="12pt" Text="Entrance Fee :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="TextBox4" runat="server" Enabled="False" Width="120px"></asp:TextBox>
   

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="Fee Field Must Not Be Null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="Invalid Fee" ForeColor="Red" ValidationExpression="^[0-9]+.?[0-9]+" ValidationGroup="1">(*)</asp:RegularExpressionValidator>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
  
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="12pt" Text="Entrance Date:"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="TextBox5" runat="server" Enabled="False" Width="120px"></asp:TextBox>
   

                <asp:CalendarExtender ID="TextBox5_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBox5" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
   

                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="Date Field Must Not Be Null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
  
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="12pt" Text="Start Date :"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="TextBox6" runat="server" Enabled="False" Width="120px"></asp:TextBox>
   

                <asp:CalendarExtender ID="TextBox6_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBox6" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
   

                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox6" Display="Dynamic" ErrorMessage="Start Date Field Must Not Be Null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px;text-align:right" >
  
        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="12pt" Text="End Date:"></asp:Label>
            </td>
            <td style="text-align:left"><asp:TextBox ID="TextBox7" runat="server" Enabled="False" Width="120px"></asp:TextBox>
   

                <asp:CalendarExtender ID="TextBox7_CalendarExtender" runat="server" Enabled="True" TargetControlID="TextBox7" Format="dd/MM/yyyy">
                </asp:CalendarExtender>
   

                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7" Display="Dynamic" ErrorMessage="End Date Field Must Not Be Null" ForeColor="Red" ValidationGroup="1">(*)</asp:RequiredFieldValidator>
   

            </td>
        </tr>
        <tr>
            <td style="width: 150px">&nbsp;</td>
            <td>
               <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Edit" Width="62px" Enabled="False" ValidationGroup="1" />
&nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete" Enabled="False" />

   </td>
        </tr>
    </table>
   

    <br />


</asp:Content>

