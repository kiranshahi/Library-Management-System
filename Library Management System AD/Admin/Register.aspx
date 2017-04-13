<%@ Page Title="Create User" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Library_Management_System_AD.Admin.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Add New User <small>Enter User's Details here</small>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <div class = "panel panel-warning">
        <div class = "panel-heading">
            <h3 class = "panel-title"><%: Title %> </h3> <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>
       <div class = "panel-body" >
           <table class="table" style="width:100%">
               <tr>
                   <td>Full Name</td>
                   <td>
                       <asp:TextBox ID="txtFUllName" CssClass="form-control" placeHolder="Enter Name" runat="server" Width="364px"  required="required"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Username</td>
                   <td>
                       <asp:TextBox ID="txtUsername" CssClass="form-control" placeHolder="Enter Username" runat="server" Width="364px" required="required"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Email Id:</td>
                   <td>
                       <asp:TextBox ID="txtEmailID" CssClass="form-control" placeHolder="Enter EMail Id" runat="server" Width="364px" TextMode="Email" required="required"></asp:TextBox>
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
                       <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
                       <asp:Button ID="btnSingup" runat="server" Text="Register" CssClass="btn btn-success" OnClick="btnSingup_Click" />
                   </td>
               </tr>
           </table>
       </div>
    </div>
</asp:Content>