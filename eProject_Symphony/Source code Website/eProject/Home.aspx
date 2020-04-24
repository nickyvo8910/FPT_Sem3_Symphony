<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <li class="active"><a href="Home.aspx">Home</a></li>
        <li><a href="Course.aspx">Course</a></li>
        <li><a href="Feedback.aspx">Feedback</a></li>
        <li><a href="ContactUs.aspx">Contact Us</a></li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="article">
        <h2><span>5 Reasons to Choose Us</span></h2>
        <div class="clr"></div>
        <%--<p class="post-data"><span class="date">March 16, 2018</span> &nbsp;|&nbsp; Posted by <a href="#">Owner</a> &nbsp;|&nbsp; Filed under <a href="#">templates</a>, <a href="#">internet</a></p>--%>
        <img src="images/images_1.jpg" width="613" height="193" alt="" />
          <ul>
              <li>Academic excellence</li>
              <li>Employability of our graduates</li>
              <li>A highly-rated university</li>
              <li>A focus on supporting every student</li>
              <li>Our Work Placements and Year Abroad programme </li>
            </ul>
        </p>
        <p class="spec"> <a href="#" class="rm fl">Read more</a></p>
        <div class="clr"></div>
      </div>
      <div class="article">
          <h2><span>We Do Focus On Students</span></h2>
        <table>
            <tr>
                <td><asp:Image ID="Image1" runat="server" Height="125" Width="125" ImageUrl="~/images/student/01.jpg" /></td>
                <td><asp:Image ID="Image2" runat="server" Height="125" Width="125" ImageUrl="~/images/student/02.jpg" /></td>
                <td><asp:Image ID="Image3" runat="server" Height="125" Width="125" ImageUrl="~/images/student/03.jpg" /></td>
                <td><asp:Image ID="Image4" runat="server" Height="125" Width="125" ImageUrl="~/images/student/04.jpg" /></td>
            </tr>
            <tr>
                <td><asp:Image ID="Image5" runat="server" Height="125" Width="125" ImageUrl="~/images/student/05.jpg" /></td>
                <td><asp:Image ID="Image6" runat="server" Height="125" Width="125" ImageUrl="~/images/student/06.jpg" /></td>
                <td><asp:Image ID="Image7" runat="server" Height="125" Width="125" ImageUrl="~/images/student/07.jpg" /></td>
                <td><asp:Image ID="Image8" runat="server" Height="125" Width="125" ImageUrl="~/images/student/08.jpg" /></td>
            </tr>
            <tr>
                <td><asp:Image ID="Image9" runat="server" Height="125" Width="125" ImageUrl="~/images/student/09.jpg" /></td>
                <td><asp:Image ID="Image10" runat="server" Height="125" Width="125" ImageUrl="~/images/student/10.jpg" /></td>
                <td><asp:Image ID="Image11" runat="server" Height="125" Width="125" ImageUrl="~/images/student/11.jpg" /></td>
                <td><asp:Image ID="Image12" runat="server" Height="125" Width="125" ImageUrl="~/images/student/12.jpg" /></td>
            </tr>
        </table>
      </div>
<%--      <div class="pagenavi"><span class="pages">Page 1 of 2</span><span class="current">1</span><a href="#">2</a><a href="#" >&raquo;</a></div>--%>
</asp:Content>

