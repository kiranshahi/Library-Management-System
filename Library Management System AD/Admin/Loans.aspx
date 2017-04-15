<%@ Page Title="Add Authors" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Loans.aspx.cs" Inherits="Library_Management_System_AD.Admin.Loans" %>
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
               <label for="loanType" class="col-sm-2">Loan Type:</label>
               <div class="col-sm-8">
                   <select id="loanType" class="form-control" runat="server" name="D1">
                   </select>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="TextBox1" class="col-sm-2">Author's Address</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="TextBox1" CssClass="form-control" placeHolder="Author's Address" runat="server" required="required"></asp:TextBox>
               </div>
           </div>
           
           <div class="form-group row">
               <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
               <asp:Button ID="btnSingup" runat="server" Text="Add To Loan" CssClass="btn btn-success" OnClick="BtnAddLoan" />
           </div>
       </div>
    </div>
</asp:Content>