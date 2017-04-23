<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Library_Management_System_AD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
<div class="clearfix"></div>
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">

                          <div class="x_content">

                            <div class="col-md-2 pull-right clearfix">
                                      <input id="submit" type="submit" value="Search" class="btn btn-primary" runat="server"/>
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
                               </div>
                                  <div class="row form-group">
                                      <label class="col-sm-1 col-sm-offset-5" style="padding-top: 15px">Filter</label>
                                      <asp:DropDownList ID="Filter" CssClass="form-control col-sm-6" style="margin: 10px auto; width: 50%" runat="server" AutoPostBack="true"></asp:DropDownList>
                                  </div>
                              <asp:GridView ID="BookLister" CssClass="table table-striped table-bordered" runat="server">
                              
                                  
                              </asp:GridView>
                              <div class="row">
                                  <asp:Label ID="info" CssClass="clearfix col-md-12" runat="server" Text=""></asp:Label>
                              </div>

                            
                          </div>
                        </div>
                    </div>
                </div>
</asp:Content>
