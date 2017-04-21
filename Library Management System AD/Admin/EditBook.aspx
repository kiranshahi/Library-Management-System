<%@ Page Title="Add Books" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="EditBook.aspx.cs" Inherits="Library_Management_System_AD.Admin.EditBook" %>

<asp:Content ID="userName" ContentPlaceHolderID="userName" runat="server">
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="userName1" ContentPlaceHolderID="userName1" runat="server">
    <asp:Label ID="lblUserName1" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Add New Book <small>Enter Book's Details here</small>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
        <div class = "panel panel-warning">
            <div class = "panel-heading">
                <h3 class = "panel-title"><%: Title %> </h3> <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
            </div>
            <div class = "panel-body" >
                
                <div class="form-group row">
                    <label for="txtTitle" class="col-sm-2">Title:</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtTitle" CssClass="form-control" placeHolder="Book's Title" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqValTxtTitle" runat="server" ControlToValidate="txtTitle" Display="Dynamic" EnableClientScript="True" ErrorMessage="Title is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                
                <div class="form-group row">
                    <label for="txtOverview" class="col-sm-2">Book's Overview:</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtOverview" CssClass="form-control" placeHolder="Book's Overview" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group row">
                    <label for="txtIsbn" class="col-sm-2">ISBN No:</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtIsbn" CssClass="form-control" placeHolder="ISBN No" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqValTxtOverview" runat="server" ControlToValidate="txtIsbn" Display="Dynamic" EnableClientScript="True" ErrorMessage="ISBN number is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                
                <div class="form-group row">
                    <label for="txtPublisher" class="col-sm-2">Publisher:</label>
                    <div class="col-sm-8">
                        <select id="publisherList" class="form-control" name="publisherList" runat="server">
                            
                        </select>
                    </div>
                </div>
                
                <div class="form-group row">
                    <label for="authorList" class="col-sm-2">Author:</label>
                    <div class="col-sm-8">
                        <select id="authorList" class="form-control" name="authorList" multiple="true" runat="server">
                            
                        </select>
                    </div>
                </div>
                
                <div class="form-group row">
                    <label for="txtPublishedDate" class="col-sm-2">Published Date:</label>
                    <div class="col-sm-8">
                        <div class='input-group date' id='lmsDatetimePicker1'>
                            <asp:TextBox ID="txtPublishedDate" CssClass="form-control" placeHolder="YYYY-MM-DD" runat="server" TextMode="Date"></asp:TextBox>
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
                
                <div class="form-group row">
                    <label for="txtEdition" class="col-sm-2">Edition:</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtEdition" CssClass="form-control" placeHolder="Edition" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqValtxtEdition" runat="server" ControlToValidate="txtEdition" Display="Dynamic" EnableClientScript="False" ErrorMessage="Edition is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegExpValtxtEdition" runat="server" ControlToValidate="txtEdition" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    </div>
                </div>
                
                <div class="form-group row">
                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
                    <asp:Button ID="btnAddBook" runat="server" Text="Update Book" CssClass="btn btn-success" OnClick="updateBookDetails"/>
                </div>
            </div>
        </div>
</asp:Content>