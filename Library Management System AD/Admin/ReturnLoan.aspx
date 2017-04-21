<%@ Page Title="Add Books to Loan" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ReturnLoan.aspx.cs" Inherits="Library_Management_System_AD.Admin.ReturnLoan" %>

<asp:Content ID="userName" ContentPlaceHolderID="userName" runat="server">
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="userName1" ContentPlaceHolderID="userName1" runat="server">
    <asp:Label ID="lblUserName1" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Add Books to Loan <small>Enter Book's and User's Details here</small>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <div class = "panel panel-warning">
        <div class = "panel-heading">
            <h3 class = "panel-title"><%: Title %> </h3> <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>
        <div class="panel-body">
            
            <asp:HiddenField id="loanId" runat="server"/>

            <div class="form-group row">
                <label for="loanType" class="col-sm-2">Loan Type:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="loanType" CssClass="form-control" runat="server" readonly="True"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <label for="bookCopy" class="col-sm-2">Book Copy:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="bookCopy" CssClass="form-control" runat="server" readonly="True"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <label for="member" class="col-sm-2">Member:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="member" CssClass="form-control" runat="server" readonly="True"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <label for="txtIssuedDate" class="col-sm-2">Issued Date:</label>
                <div class="col-sm-8">
                   <asp:TextBox ID="txtIssuedDate" CssClass="form-control" runat="server" readonly="True"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <label for="txtDueDate" class="col-sm-2">Due Date:</label>
                <div class="col-sm-8">
                   <asp:TextBox ID="txtDueDate" CssClass="form-control" runat="server" readonly="True"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <label for="txtReturnedDate" class="col-sm-2">Returned Date:</label>
                <div class="col-sm-8">
                    <div class='input-group date' id='lmsDatetimePicker'>
                        <asp:TextBox ID="txtReturnedDate" CssClass="form-control" placeHolder="YYYY-MM-DD" runat="server"></asp:TextBox>
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div>

           <div class="form-group row">
               <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
               <asp:Button ID="btnReturnLoan" runat="server" Text="Return Book" CssClass="btn btn-success" OnClick="BtnReturnLoan" />
           </div>

       </div>
    </div>
</asp:Content>