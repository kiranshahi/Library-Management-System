<%@ Page Title="Add Members" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="Library_Management_System_AD.Admin.Members" %>
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
               <label for="txtEmail" class="col-sm-2">E-mail:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtEmail" CssClass="form-control" placeHolder="example@yourdomain.com" runat="server" required="required" TextMode="Email"></asp:TextBox>
               </div>
           </div>
           <div class="form-group row">
               <label for="txtPhone" class="col-sm-2">Phone Number:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtPhone" CssClass="form-control" placeHolder="Phone Number" runat="server" required="required" TextMode="Phone"></asp:TextBox>
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
               <label for="txtJoinedDate" class="col-sm-2">Joined Date:</label>
               <div class="col-sm-8">
                   <asp:TextBox ID="txtJoinedDate" CssClass="form-control" placeHolder="YYYY-MM-DD" runat="server" required="required" TextMode="Date"></asp:TextBox>
               </div>
           </div>
           <div class="form-group row">
               <asp:Button ID="Reset_Button" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="this.form.reset();return false;" />
               <asp:Button ID="btnSingup" runat="server" Text="Add Memebers" CssClass="btn btn-success" OnClick="BtnAddMember" />
           </div>
       </div>
    </div>
</asp:Content>