<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <li><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li class="active"><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="article">
        <h2><span>Feedback</span></h2>
        <div class="clr"></div>
        <p id="FeedbackNote"><strong>Please Note : </strong>Sending us your contact details means we can respond to your enquiry. We will use your contact details only for the purpose for which you provided it. We will not give your contact details to anyone else without your consent. We will not add it to a mailing list. </p>
        
            <asp:DataList ID="DataList1" runat="server" CellPadding="4" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" Width="479px" ForeColor="#333333">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" Text="FeedBack ID: " Font-Size="15pt"></asp:Label>
                <asp:Label ID="Label3" runat="server" Font-Size="12pt" Text='<%# Eval("faqID") %>'></asp:Label>
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" CausesValidation="false">Show Details</asp:LinkButton>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SelectedItemTemplate>
                <asp:Label ID="Label12" runat="server" Font-Size="15pt" Text="FeedBack ID: "></asp:Label>
                <asp:Label ID="Label13" runat="server" Font-Size="12pt" ForeColor="Black" Text='<%# Eval("faqID") %>'></asp:Label>
                <br />
                <asp:Label ID="Label10" runat="server" Font-Size="15pt" Text="Sender :"></asp:Label>
                <asp:Label ID="Label11" runat="server" Font-Size="12pt" ForeColor="Black" Text='<%# Eval("faqEmail") %>'></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="15pt" Text="Question :"></asp:Label>
                <asp:Label ID="Label6" runat="server" Font-Size="12pt" Text='<%# Eval("faqQuestion") %>' ForeColor="Black"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="15pt" Text="Answer :"></asp:Label>
                <asp:Label ID="Label7" runat="server" Font-Size="12pt" Text='<%# Eval("faqAnswer") %>' ForeColor="Black"></asp:Label>
            </SelectedItemTemplate>
        </asp:DataList>
        
         <h2><asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            
          <ol> 
            <li>
              <label for="email">Email Address :</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Field Must Not Be Null." ForeColor="Red">(*)</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">(*)</asp:RegularExpressionValidator>
            </li>
                <li>
              <label for="message">Your Message:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMess" Display="Dynamic" ErrorMessage="Field Must Not Be Null." ForeColor="Red">(*)</asp:RequiredFieldValidator>
                </label>
               &nbsp;<asp:TextBox ID="txtMess" runat="server" Columns="15" Rows="8" TextMode="MultiLine"></asp:TextBox>
            </li>
            <li style="text-align:center">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/submit.gif" CssClass="send" OnClick="ImageButton1_Click" />
              
            </li>
          </ol>
      </div>
</asp:Content>

