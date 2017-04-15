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
           <div class="form-group row">
               <label for="txtTitle" class="col-sm-2">Title:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtTitle" CssClass="form-control" placeHolder="Book's Title" runat="server" required="required"></asp:TextBox>
               </div>
           </div>
           <div class="form-group row">
               <label for="txtOverview" class="col-sm-2">Book's Overview:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtOverview" CssClass="form-control" placeHolder="Book's Overview" runat="server" required="required" TextMode="MultiLine"></asp:TextBox>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtIsbn" class="col-sm-2">ISBN No:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtIsbn" CssClass="form-control" placeHolder="ISBN No" runat="server" required="required"></asp:TextBox>
               </div>
           </div>
               <div class="form-group row">
               <label for="txtPublisher" class="col-sm-2">Publisher:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtPublisher" CssClass="form-control" placeHolder="Publisher" runat="server" required="required"></asp:TextBox>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtPublishedDate" class="col-sm-2">Published Date:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtPublishedDate" CssClass="form-control" placeHolder="Published Date" runat="server" required="required" TextMode="Date"></asp:TextBox>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtEdition" class="col-sm-2">Edition:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtEdition" CssClass="form-control" placeHolder="Edition" runat="server" required="required" TextMode="Number"></asp:TextBox>
               </div>
           </div>
           
           <div class="form-group row">
               <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
               <asp:Button ID="btnSingup" runat="server" Text="Add Book" CssClass="btn btn-success" OnClick="BtnAddBooks" />
           </div>
       </div>
    </div>
</asp:Content>