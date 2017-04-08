<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Library_Management_System_AD.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Login</title>
    <webopt:bundlereference runat="server" path="~/Content/css" />
</head>
<body class="login">
<div>
    <a class="hiddenanchor" id="signup"></a>
    <a class="hiddenanchor" id="signin"></a>
    <div class="login_wrapper">
        <div class="animate form login_form">
            <section class="login_content">
                <form id="form1" runat="server">
                    <h1>Login</h1>
                    <div>
                        <asp:TextBox ID="txtUsername" CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnLogin" CssClass="btn btn-default submit"  runat="server" Text="Sign In" OnClick="btnLogin_Click" />
                        <a class="reset_pass"  runat="server" href="~/">← Back to Home Page.</a>
                    </div>
                    <div>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="clearfix"></div>
                    <div class="separator">
                        <p class="change_link">Lost your password?
                            <a href="#signup" class="to_register"> Reset </a>
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
        <div id="register" class="animate form registration_form">
          <section class="login_content">
            <form>
              <h1>Create Account</h1>
              <div>
                <input type="text" class="form-control" placeholder="Username" required="" />
              </div>
              <div>
                <input type="email" class="form-control" placeholder="Email" required="" />
              </div>
              <div>
                <input type="password" class="form-control" placeholder="Password" required="" />
              </div>
              <div>
                <a class="btn btn-default submit" href="index.html">Submit</a>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link">Already a member ?
                  <a href="#signin" class="to_register"> Log in </a>
                </p>

                <div class="clearfix"></div>
                <br />

                <div>
                  <h1><i class="fa fa-paw"></i> Library Management System</h1>
                  <p>©2016 All Rights Reserved.</p>
                </div>
              </div>
            </form>
          </section>
        </div>
    </div>
    </div>
</body>
</html>