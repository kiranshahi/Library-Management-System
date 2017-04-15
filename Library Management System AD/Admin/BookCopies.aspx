<%@ Page Title="Add Book Copies" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="BookCopies.aspx.cs" Inherits="Library_Management_System_AD.Admin.BookCopies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Add New Book Copies <small>Enter Book Copies' Details here</small>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <div class = "panel panel-warning">
        <div class = "panel-heading">
            <h3 class = "panel-title"><%: Title %> </h3> <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>
       <div class = "panel-body" >
           <div class="form-group row">
               <label for="book" class="col-sm-2">Books</label>
               <div class="col-sm-8">
                   <select id="bookOption" class="form-control" name="bookOption" runat="server">
                       
                   </select>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtPurchasedDate" class="col-sm-2">Purchased Date:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtPurchasedDate" CssClass="form-control" placeHolder="YYYY-MM-DD" runat="server" required="required" TextMode="Date"></asp:TextBox>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtLocation" class="col-sm-2">Location</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtLocation" CssClass="form-control" placeHolder="Location" runat="server" required="required"></asp:TextBox>
               </div>
           </div>

            <div class="form-group row">
                <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
                <asp:Button ID="btnSingup" runat="server" Text="Add Author" CssClass="btn btn-success" OnClick="BtnAddBookCopies" />
            </div>
       </div>
    </div>
</asp:Content>