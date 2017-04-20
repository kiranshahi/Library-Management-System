<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="EditMember.aspx.cs" Inherits="Library_Management_System_AD.Admin.EditMember" %>

<asp:Content ID="userName" ContentPlaceHolderID="userName" runat="server">
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="userName1" ContentPlaceHolderID="userName1" runat="server">
    <asp:Label ID="lblUserName1" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Profile <small>Edit your details here</small>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <div class = "panel panel-warning">
        <div class = "panel-heading">
            <h3 class = "panel-title"><%: Title %> </h3> <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>
        <div class = "panel-body" >
            
            <asp:HiddenField id="memberId" runat="server"/>

            <div class="form-group row">
                <label for="txtName" class="col-sm-2">Name:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <label for="txtEmail" class="col-sm-2">Email:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
                <label for="txtPhone" class="col-sm-2">Mobile No:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="form-group row">
               <label for="membershipType" class="col-sm-2">Membership Type:</label>
               <div class="col-sm-8">
                   <select id="membershipType" class="form-control" runat="server" name="membershipType">
                   </select>
               </div>
           </div>
            
            <div class="form-group row">
                <label for="txtAddress" class="col-sm-2">Address:</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <asp:Button ID="btnUpdateProfile" runat="server" Text="Update Member" CssClass="btn btn-success" OnClick="BtnUpdateDetails"/>
            </div>
        </div>
    </div>
</asp:Content>