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
           <div class="form-group row">
               <label for="txtFUllName" class="col-sm-2">Full Name:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtFUllName" CssClass="form-control" placeHolder="Enter Name" runat="server" required="required"></asp:TextBox>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtUsername" class="col-sm-2">Username:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtUsername" CssClass="form-control" placeHolder="Enter Username" runat="server" required="required"></asp:TextBox>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtEmailID" class="col-sm-2">Email Id:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtEmailID" CssClass="form-control" placeHolder="Enter EMail Id" runat="server" TextMode="Email" required="required"></asp:TextBox>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtMobileNo" class="col-sm-2">Mobile No:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtMobileNo" CssClass="form-control" placeHolder="Enter Mobile no" runat="server" TextMode="Phone"></asp:TextBox>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtJoinedDate" class="col-sm-2">Joined Date:</label>
               <div class="col-sm-8">
                   <div class='input-group date' id='lmsDatetimePicker'>
                       <asp:TextBox ID="txtJoinedDate" CssClass="form-control" placeHolder="YYYY-MM-DD" runat="server" TextMode="Date"></asp:TextBox>
                       <span class="input-group-addon">
                           <span class="glyphicon glyphicon-calendar"></span>
                       </span>
                   </div>
               </div>
           </div>
           
           <div class="form-group row">
               <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
               <asp:Button ID="btnSingup" runat="server" Text="Register" CssClass="btn btn-success" OnClick="BtnAddUser" />
           </div>
               
       </div>
    </div>
</asp:Content>