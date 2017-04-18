<%@ Page Title="Add Membership Type" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="MembershipType.aspx.cs" Inherits="Library_Management_System_AD.Admin.MembershipType" %>

<asp:Content ID="userName" ContentPlaceHolderID="userName" runat="server">
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="userName1" ContentPlaceHolderID="userName1" runat="server">
    <asp:Label ID="lblUserName1" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="Title" runat="server">
    Add Membership Type <small>Enter Membership Type's Details here</small>
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
                   <asp:TextBox ID="txtType" CssClass="form-control" placeHolder="Enter Membership Type" runat="server" required="required"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqValTxtType" runat="server" ControlToValidate="txtType" Display="Dynamic" EnableClientScript="True" ErrorMessage="Membership Type is required." ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtBooksAllowed" class="col-sm-2">Books Allowed:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtBooksAllowed" CssClass="form-control" placeHolder="Books Allowed" runat="server" required="required"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqValTxtBooksAllowed" runat="server" ControlToValidate="txtBooksAllowed" Display="Dynamic" EnableClientScript="True" ErrorMessage="Number of book allowed to member is required." ForeColor="Red"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegExpValTxtBooksAllowed" runat="server" ControlToValidate="txtBooksAllowed" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="txtPenaltyCharge" class="col-sm-2">Penalty Charge:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtPenaltyCharge" CssClass="form-control" placeHolder="Penalty Charge amount" runat="server" required="required"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="reqValTxtPenaltyCharge" runat="server" ControlToValidate="txtPenaltyCharge" Display="Dynamic" EnableClientScript="True" ErrorMessage="Penalty Charge amount is required." ForeColor="Red"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegExpValTxtPenaltyCharge" runat="server" ControlToValidate="txtPenaltyCharge" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
               </div>
           </div>

            <div class="form-group row">
                <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
                <asp:Button ID="btnSingup" runat="server" Text="Add Membership Type" CssClass="btn btn-success" OnClick="BtnAddMembershipType" />
            </div>
       </div>
    </div>
</asp:Content>