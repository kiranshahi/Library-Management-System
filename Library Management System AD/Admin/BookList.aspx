<%@ Page Title="Search Books" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="Library_Management_System_AD.BookList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="userName" runat="server">
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="userName1" runat="server">
    <asp:Label ID="lblUserName1" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="AdminContent" runat="server">
    
<div class="clearfix"></div>
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">

                          <div class="x_content">

                            <div class="col-md-2 pull-right clearfix">
                                      <input id="Submit1" type="submit" value="submit" class="btn btn-primary"/>
                              </div>

                              <!-- asp components for search -->
                              <div class="row search-field clearfix" style="float: right; margin-bottom: 15px">
                                  
                                  <div class="col-md-4">
                                      <asp:TextBox placeholder="Search book/ISBN" ID="bookName" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                  </div>
                               
                                     <div class="col-md-4">
                                      <asp:TextBox placeholder="Search publisher name" ID="publisherName" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                  </div>

                                  <div class="col-md-4">
                                      <asp:TextBox placeholder="Search author name" ID="authorName" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                  </div>
                                  

                                  <asp:CheckBox ID="includeLoaned" CssClass="pull-right" style="margin: 10px auto" runat="server" AutoPostBack="True" Text="Include loaned books?" />
                              </div>
                              <asp:GridView ID="BookLister" CssClass="table table-striped table-bordered" runat="server">
                              
                                  
                              </asp:GridView>
                              <div class="row">
                                  <asp:Label ID="info" CssClass="clearfix col-md-12" runat="server" Text=""></asp:Label>
                              </div>

                              <%--
                            <table id="datatable-buttons" class="table table-striped table-bordered">
                              <thead>
                                <tr>
                                  <th>Name</th>
                                  <th>Position</th>
                                  <th>Office</th>
                                  <th>Age</th>
                                  <th>Start date</th>
                                </tr>
                              </thead>


                              <tbody>
                                <tr>
                                  <td>Tiger Nixon</td>
                                  <td>System Architect</td>
                                  <td>Edinburgh</td>
                                  <td>61</td>
                                  <td>2011/04/25</td>
                                </tr>
                                <tr>
                                    <td>Python Machine Learning</td>
                                    <td>9781783555147</td>
                                    <td>Sebastian Raschka</td>
                                    <td>Leverage Python's most powerful open-source libraries for deep learning, data wrangling, and data visualization</td>
                                    <td>2015/09/23</td>
                                </tr>
                              </tbody>
                            </table> 
                              --%>
                          </div>
                        </div>
                    </div>
                </div>


</asp:Content>
