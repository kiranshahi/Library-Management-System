<%@ Page Title="Add Books" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Library_Management_System_AD.Admin.Books" %>

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
    <asp:Panel id="bookPanel" DefaultButton="btnAddBook" Runat="Server" ValidationGroup="first">
        <div class = "panel panel-warning">
            <div class = "panel-heading">
                <h3 class = "panel-title"><%: Title %> </h3> <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
            </div>
            <div class = "panel-body" >
                
                <div class="form-group row">
                    <label for="txtTitle" class="col-sm-2">Title:</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtTitle" CssClass="form-control" placeHolder="Book's Title" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqValTxtTitle" runat="server" ControlToValidate="txtTitle" Display="Dynamic" EnableClientScript="False" ErrorMessage="Title is required." ForeColor="Red" ValidationGroup="first"></asp:RequiredFieldValidator>
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
                        <asp:RequiredFieldValidator ID="reqValTxtOverview" runat="server" ControlToValidate="txtOverview" Display="Dynamic" EnableClientScript="True" ErrorMessage="ISBN number is required." ForeColor="Red" ValidationGroup="first"></asp:RequiredFieldValidator>
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
                    <label for="txtPublishedDate" class="col-sm-2">Published Date:</label>
                    <div class="col-sm-8">
                        <div class='input-group date' id='lmsDatetimePicker'>
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
                        <asp:RequiredFieldValidator ID="reqValtxtEdition" runat="server" ControlToValidate="txtEdition" Display="Dynamic" EnableClientScript="False" ErrorMessage="Edition is required." ForeColor="Red" ValidationGroup="first"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegExpValtxtEdition" runat="server" ControlToValidate="txtEdition" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                    </div>
                </div>
                
                <div class="form-group row">
                    <label for="txtBarCode" class="col-sm-2">Bar Code:</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtBarCode" CssClass="form-control" placeHolder="Bar Code" runat="server"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group row">
                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
                    <asp:Button ID="btnAddBook" runat="server" Text="Add Book" CssClass="btn btn-success" OnClick="BtnAddBooks" ValidationGroup="first"/>
                    <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal">
                        Add Author
                    </button>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel id="authorPanel" DefaultButton="btnAddNewAuthor" Runat="Server" ValidationGroup="second">
        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Add Author</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group row">
                            <label for="txtFUllName" class="col-sm-2">Full Name:</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtFUllName" CssClass="form-control" placeHolder="Enter Name" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqValTxtFUllName" runat="server" ControlToValidate="txtFUllName" Display="Dynamic" EnableClientScript="False" ErrorMessage="Author's name is required." ForeColor="Red" ValidationGroup="second"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="txtAddress" class="col-sm-2">Author's Address:</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtAddress" CssClass="form-control" placeHolder="Author's Address" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqValTxtAddress" runat="server" ControlToValidate="txtAddress" Display="Dynamic" EnableClientScript="False" ErrorMessage="Author's location is required." ForeColor="Red" ValidationGroup="second"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnResetAuthor" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
                        <asp:Button ID="btnAddNewAuthor" runat="server" Text="Add Author" CssClass="btn btn-success" OnClick="BtnAddAuthor" />
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal Ends-->
    </asp:Panel>
</asp:Content>