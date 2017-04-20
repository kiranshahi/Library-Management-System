<%@ Page Title="Loans" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="ActiveLoans.aspx.cs" Inherits="Library_Management_System_AD.Admin.ActiveLoans" %>


<asp:Content ID="userName" ContentPlaceHolderID="userName" runat="server">
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="userName1" ContentPlaceHolderID="userName1" runat="server">
    <asp:Label ID="lblUserName1" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Active Loans <small>The following are the loans taken</small>
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="AdminContent" runat="server">
    
<div class="clearfix"></div>
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">

                          <div class="x_content">

                              <asp:GridView ID="LoanLister" CssClass="table table-striped table-bordered" runat="server" OnRowDataBound="LoanLister_RowDataBound">
                              
                                  
                              </asp:GridView>
                              <div class="row">
                                  <asp:Label ID="info" CssClass="clearfix col-md-12" runat="server" Text=""></asp:Label>
                              </div>


                          </div>
                        </div>
                    </div>
                </div>


</asp:Content>