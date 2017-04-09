<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Library_Management_System_AD.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Reset Password</title>
     <webopt:bundlereference runat="server" path="~/Content/css" />
</head>
<body class="login">
<div>
    <div class="login_wrapper">
        <div class="animate form login_form">
            <section class="login_content">
                <form id="form1" runat="server">
                    <h1>Reset Password</h1>
                    <div>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Email" runat="server" required="required"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnReset" CssClass="btn btn-default submit"  runat="server" Text="Reset" OnClick="btnReset_Click"/>
                        <a class="reset_pass"  runat="server" href="~/">← Back to Home Page.</a>
                    </div>
                    <div class="clearfix"></div>
                    <div class="separator">
                        <p class="change_link">Remembered your password?
                            <a runat="server" href="~/Login"> Login </a>
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
