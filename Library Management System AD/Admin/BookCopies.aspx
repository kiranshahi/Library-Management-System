﻿<%@ Page Title="Add Book Copies" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="BookCopies.aspx.cs" Inherits="Library_Management_System_AD.Admin.BookCopies" %>

<asp:Content ID="userName" ContentPlaceHolderID="userName" runat="server">
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="userName1" ContentPlaceHolderID="userName1" runat="server">
    <asp:Label ID="lblUserName1" runat="server"></asp:Label>
</asp:Content>

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
               <label for="txtCopyNumber" class="col-sm-2">Copy Number: </label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtCopyNumber" CssClass="form-control" placeHolder="Copy Number" runat="server" required="required"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqValTxtCopyNumber" runat="server" ControlToValidate="txtCopyNumber" Display="Dynamic" EnableClientScript="False" ErrorMessage="Copy number is required." ForeColor="Red"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="reqValTxtCopyNumber1" runat="server" ControlToValidate="txtCopyNumber" ErrorMessage="Please Enter Only Numbers." ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
               </div>
           </div>

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
                   <div class='input-group date' id='lmsDatetimePicker'>
                       <asp:TextBox ID="txtPurchasedDate" CssClass="form-control" placeHolder="YYYY-MM-DD" runat="server" required="required" TextMode="Date"></asp:TextBox>
                       <span class="input-group-addon">
                           <span class="glyphicon glyphicon-calendar"></span>
                       </span>
                   </div>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtLocation" class="col-sm-2">Location</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtLocation" CssClass="form-control" placeHolder="Location" runat="server" required="required"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqValTxtLocation" runat="server" ControlToValidate="txtLocation" Display="Dynamic" EnableClientScript="True" ErrorMessage="Location is required." ForeColor="Red" ValidationGroup="second"></asp:RequiredFieldValidator>
               </div>
           </div>

            <div class="form-group row">
                <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
                <asp:Button ID="btnSingup" runat="server" Text="Add Author" CssClass="btn btn-success" OnClick="BtnAddBookCopies" />
            </div>
       </div>
    </div>
</asp:Content>