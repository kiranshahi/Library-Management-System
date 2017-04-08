<%@ Page Title="Create User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Library_Management_System_AD.Admin.Register" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class = "panel panel-warning">
       <div class = "panel-heading">
          <h3 class = "panel-title">Create User </h3> <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
       </div>
       <div class = "panel-body" >
           <table class="table" style="width:100%">
               <tr>
                   <td>Full Name</td>
                   <td>
                       <asp:TextBox ID="txtFUllName" CssClass="form-control" placeHolder="Enter Name" runat="server" Width="364px" ></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Username</td>
                   <td>
                       <asp:TextBox ID="txtUsername" CssClass="form-control" placeHolder="Enter Username" runat="server" Width="364px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Email Id:</td>
                   <td>
                       <asp:TextBox ID="txtEmailID" CssClass="form-control" placeHolder="Enter EMail Id" runat="server" Width="364px" TextMode="Email"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Mobile No:</td>
                   <td>
                       <asp:TextBox ID="txtMobileNo" CssClass="form-control" placeHolder="Enter Mobile no" runat="server" Width="364px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Joined Date:</td>
                   <td>
                       <asp:TextBox ID="txtJoinedDate" CssClass="form-control" placeHolder="Joined Date" runat="server" Width="364px" TextMode="DateTime"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>&nbsp;</td>
                   <td>
                       <asp:Button ID="btnSingup" runat="server" Text="Register" CssClass="btn btn-warning" OnClick="btnSingup_Click" />
                   </td>
               </tr>
           </table>
       </div>
    </div>
</asp:Content>