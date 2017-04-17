<%@ Page Title="Add Publisher" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Publishers.aspx.cs" Inherits="Library_Management_System_AD.Admin.Publishers" %>

<asp:Content ID="userName" ContentPlaceHolderID="userName" runat="server">
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="userName1" ContentPlaceHolderID="userName1" runat="server">
    <asp:Label ID="lblUserName1" runat="server"></asp:Label>
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
               <label for="txtAddress" class="col-sm-2">Author's Address:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtAddress" CssClass="form-control" placeHolder="Author's Address" runat="server" required="required"></asp:TextBox>
               </div>
           </div>
           
           <div class="form-group row">
               <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
               <asp:Button ID="btnSingup" runat="server" Text="Add Publisher" CssClass="btn btn-success" OnClick="BtnAddPublisher" />
           </div>
       </div>
    </div>
</asp:Content>