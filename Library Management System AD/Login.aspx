﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Library_Management_System_AD.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Login</title>
    <webopt:bundlereference runat="server" path="~/Content/css" />
</head>
<body class="login">
<div>
    <div class="login_wrapper">
        <div class="animate form login_form">
            <section class="login_content">
                <form id="form1" runat="server">
                    <h1>Login</h1>
                    <div>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtUsername" CssClass="form-control" placeholder="Username" runat="server" required="required" ValidateRequestMode="Enabled"></asp:TextBox>
                    </div>
                    <div>
                        <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Password" TextMode="Password" runat="server" required="required" ValidateRequestMode="Enabled"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnLogin" CssClass="btn btn-default submit"  runat="server" Text="Sign In" OnClick="btnLogin_Click" />
                        <a class="reset_pass"  runat="server" href="~/">← Back to Home Page.</a>
                    </div>
                    <div class="clearfix"></div>
                    <div class="separator">
                        <p class="change_link">Lost your password?
                            <a runat="server" href="~/ResetPassword"> Reset </a>
                        </p>
                        <div class="clearfix"></div>
                        <br />
                        <div>
                            <h1><i class="fa fa-book"></i> Library Management System</h1>
                            <p>©2017 All Rights Reserved.</p>
                        </div>
                    </div>
                </form>
            </section>
        </div>
    </div>
</div>
</body>
</html>