<%@ Page Title="Create Authors" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Authors.aspx.cs" Inherits="Library_Management_System_AD.Admin.Authors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Add New Author <small>Enter Author's Details here</small>
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
                   <td>Author's Address</td>
                   <td>
                       <asp:TextBox ID="txtAddress" CssClass="form-control" placeHolder="Author's Address" runat="server" Width="364px"  required="required"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>&nbsp;</td>
                   <td>
                       <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
                       <asp:Button ID="btnSingup" runat="server" Text="Add Author" CssClass="btn btn-success" OnClick="btnAddAuthor_Click" />
                   </td>
               </tr>
           </table>
       </div>
    </div>
</asp:Content>