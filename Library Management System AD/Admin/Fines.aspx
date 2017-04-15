<%@ Page Title="Charge Fine" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Fines.aspx.cs" Inherits="Library_Management_System_AD.Admin.Fines" %>
<asp:Content ID="Content" ContentPlaceHolderID="Title" runat="server">
    Add New Fine <small>Enter Fine's Details here</small>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <div class = "panel panel-warning">
        <div class = "panel-heading">
            <h3 class = "panel-title"><%: Title %> </h3> <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
        </div>
       <div class = "panel-body" >
           <div class="form-group row">
               <label for="txtRate" class="col-sm-2">Rate:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtRate" CssClass="form-control" placeHolder="Rate" runat="server" required="required"></asp:TextBox>
               </div>
           </div>
           
           <div class="form-group row">
               <label for="loan" class="col-sm-2">Loan :</label>
               <div class="col-sm-8">
                   <select id="loan" class="form-control"></select>
               </div>
           </div>

            <div class="form-group row">
                <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
                <asp:Button ID="btnSingup" runat="server" Text="Charge Fine" CssClass="btn btn-success" OnClick="BtnAddFines" />
            </div>
       </div>
    </div>
</asp:Content>