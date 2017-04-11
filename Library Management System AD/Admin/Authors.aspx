<%@ Page Title="Create Authors" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Authors.aspx.cs" Inherits="Library_Management_System_AD.Admin.Authors" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <div class="form-group">
        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="book-title">Author Name: <span class="required">*</span>
        </label>
        <div class="col-md-6 col-sm-6 col-xs-12">
            <asp:TextBox ID="txtFUllName" CssClass="form-control col-md-7 col-xs-12" placeHolder="Enter Name" runat="server"  required="required"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="isbn-no">Author's Location <span class="required">*</span>
        </label>
        <div class="col-md-6 col-sm-6 col-xs-12">
            <asp:TextBox ID="txtLocation" CssClass="form-control col-md-7 col-xs-12" placeHolder="Author's Location" runat="server" required="required"></asp:TextBox>
        </div>
    </div>
    <div class="ln_solid"></div>
    <div class="form-group">
        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
            <button class="btn btn-primary" type="button">Cancel</button>
            <button class="btn btn-primary" type="reset">Reset</button>
            <button type="submit" class="btn btn-success">Submit Book</button>
        </div>
    </div>
</asp:Content>