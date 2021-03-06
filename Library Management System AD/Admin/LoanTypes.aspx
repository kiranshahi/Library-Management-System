﻿<%@ Page Title="Add Loan Type" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="LoanTypes.aspx.cs" Inherits="Library_Management_System_AD.Admin.LoanTypes" %>

<asp:Content ID="userName" ContentPlaceHolderID="userName" runat="server">
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="userName1" ContentPlaceHolderID="userName1" runat="server">
    <asp:Label ID="lblUserName1" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="Title" runat="server">
    Add New Loan Type <small>Enter Loan Type's Details here</small>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <div class = "panel panel-warning">
        <div class = "panel-heading">
            <h3 class = "panel-title"><%: Title %> </h3> <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>
       <div class = "panel-body" >
           <div class="form-group row">
               <label for="txtType" class="col-sm-2">Type:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtType" CssClass="form-control" placeHolder="Loan Type" runat="server" required="required"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqValTxtType" runat="server" ControlToValidate="txtType" Display="Dynamic" EnableClientScript="True" ErrorMessage="Loan type is required." ForeColor="Red" ValidationGroup="first"></asp:RequiredFieldValidator>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtMaxDuration" class="col-sm-2">Maximum Duration:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtMaxDuration" CssClass="form-control" placeHolder="Maximum Duration" runat="server" required="required"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqValTxtMaxDuration" runat="server" ControlToValidate="txtMaxDuration" Display="Dynamic" EnableClientScript="True" ErrorMessage="Maximum Duration is required." ForeColor="Red" ValidationGroup="first"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegExpValTxtMaxDuration" runat="server" ControlToValidate="txtMaxDuration" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
               </div>
           </div>

            <div class="form-group row">
                <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
                <asp:Button ID="btnSingup" runat="server" Text="Add Loan Type" CssClass="btn btn-success" OnClick="BtnAddLoanType" />
            </div>
       </div>
    </div>
</asp:Content>