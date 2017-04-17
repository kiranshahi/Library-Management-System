    <%@ Page Title="Add Books to Loan" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Loans.aspx.cs" Inherits="Library_Management_System_AD.Admin.Loans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Add Books to Loan <small>Enter Book's and User's Details here</small>
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
                   <select id="loanType" class="form-control" runat="server" name="loanType">
                   </select>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="bookCopy" class="col-sm-2">Book Copy:</label>
               <div class="col-sm-8">
                   <select id="bookCopy" class="form-control" runat="server" name="bookCopy">
                   </select>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="member" class="col-sm-2">Member:</label>
               <div class="col-sm-8">
                   <select id="member" class="form-control" runat="server" name="member">
                   </select>
               </div>
           </div>
           <div class="form-group row">
               <label for="user" class="col-sm-2">User:</label>
               <div class="col-sm-8">
                   <select id="user" class="form-control" runat="server" name="user">
                   </select>
               </div>
           </div>

           <div class="form-group row">
               <label for="txtIssuedDate" class="col-sm-2">Issued Date:</label>
               <div class="col-sm-8">
                   <div class='input-group date' id='lmsDatetimePicker'>
                       <asp:TextBox ID="txtIssuedDate" CssClass="form-control" placeHolder="YYYY-MM-DD" runat="server" required="required"></asp:TextBox>
                       <span class="input-group-addon">
                           <span class="glyphicon glyphicon-calendar"></span>
                       </span>
                   </div>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtReturnedDate" class="col-sm-2">Returned Date:</label>
               <div class="col-sm-8">
                   <div class='input-group date' id='lmsDatetimePicker1'>
                       <asp:TextBox ID="txtReturnedDate" CssClass="form-control" placeHolder="YYYY-MM-DD" runat="server" required="required"></asp:TextBox>
                       <span class="input-group-addon">
                           <span class="glyphicon glyphicon-calendar"></span>
                       </span>
                   </div>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtLocation" class="col-sm-2">Location:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtLocation" CssClass="form-control" placeHolder="Location" runat="server" required="required"></asp:TextBox>
               </div>
           </div>

           <div class="form-group row">
               <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
               <asp:Button ID="btnSingup" runat="server" Text="Add To Loan" CssClass="btn btn-success" OnClick="BtnAddLoan" />
           </div>
       </div>
    </div>
</asp:Content>