<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Library_Management_System_AD.Login" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
        <div class = "panel-body" >
      
       <table class="table" style="width:500px">
           <tr>
               <td class="auto-style2">Username</td>
               <td>
                   <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td class="auto-style2">Password</td>
               <td>
                   <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td class="auto-style2"></td>
               <td>
                   <asp:Button ID="btnLogin" CssClass="btn btn-warning"  runat="server" Text="Sign In" OnClick="btnLogin_Click" />
               &nbsp;</td>
           </tr>
           <tr>
               <td class="auto-style2">&nbsp;</td>
               <td>
                   <asp:Label ID="lblMessage" runat="server"></asp:Label>
               </td>
           </tr>
       </table>
      
   </div>
</asp:Content>