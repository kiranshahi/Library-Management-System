<%@ Page Title="Add Books" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Library_Management_System_AD.Admin.Books" %>
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
                   <td>Title:</td>
                   <td>
                       <asp:TextBox ID="txtTitle" CssClass="form-control" placeHolder="Book's Title" runat="server" Width="364px"  required="required"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Book's Overview:</td>
                   <td>
                       <asp:TextBox ID="txtOverview" CssClass="form-control" placeHolder="Book's Overview" runat="server" Width="364px"  required="required"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>ISBN No:</td>
                   <td>
                       <asp:TextBox ID="txtIsbn" CssClass="form-control" placeHolder="ISBN No" runat="server" Width="364px"  required="required"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Publisher:</td>
                   <td>
                       <asp:TextBox ID="txtPublisher" CssClass="form-control" placeHolder="Publisher" runat="server" Width="364px"  required="required"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>Published Date:</td>
                   <td>
                       <asp:TextBox ID="txtPublishedDate" CssClass="form-control" placeHolder="Published Date" runat="server" Width="364px"  required="required" TextMode="Date"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>&nbsp;</td>
                   <td>
                       <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
                       <asp:Button ID="btnSingup" runat="server" Text="Add Author" CssClass="btn btn-success" OnClick="btnAddBooks" />
                   </td>
               </tr>
           </table>
       </div>
    </div>
</asp:Content>