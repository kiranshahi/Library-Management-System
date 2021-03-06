﻿<%@ Page Title="Old Book Copies" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="OldBookCopies.aspx.cs" Inherits="Library_Management_System_AD.Admin.OldBookCopies" %>

<asp:Content ID="userName" ContentPlaceHolderID="userName" runat="server">
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="userName1" ContentPlaceHolderID="userName1" runat="server">
    <asp:Label ID="lblUserName1" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Old Books Copies: <small>Listed book copies are older than 1 year</small>
</asp:Content>




<asp:Content ID="Content4" ContentPlaceHolderID="AdminContent" runat="server">
    
<div class="clearfix"></div>
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">

                          <div class="x_content">

                              <!-- asp components for search -->
                                  
                              </div>
                              <asp:GridView ID="BookLister" CssClass="table table-striped table-bordered" runat="server">
                              
                                  
                              </asp:GridView>
                              <div class="row">
                                  <asp:Label ID="info" CssClass="clearfix col-md-12" runat="server" Text=""></asp:Label>
                                    <asp:Button ID="deleteBtn" CssClass="pull-right btn btn-danger" runat="server" Text="Delete All" OnClientClick="return confirm('Are you sure you want to delete the listed book copies?')" OnClick="deleteBtn_Click"/>
                              </div>

                          </div>
                    </div>
                </div>


</asp:Content>


