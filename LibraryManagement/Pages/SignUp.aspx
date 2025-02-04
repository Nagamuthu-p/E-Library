<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="LibraryManagement.Pages.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row h-100">
            <!-- Left Side (Black) -->
            <div class="col-md-6 login-left">
                <div class="login-form">
                    <h3 class="text-center mb-4">Sign Up</h3>
                    <form method="post" id="signUpForm" runat="server">
                        <div class="mb-2">
                            <label for="username" class="form-label">Username</label>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Required="True" ToolTip="Enter Username"></asp:TextBox>
                        </div>
                        <div class="mb-2">
                            <label for="email" class="form-label">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Required="True" TextMode="Email" ToolTip="Enter Email"></asp:TextBox>
                        </div>
                        <div class="mb-2">
                            <label for="password" class="form-label">Password</label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Required="True" ToolTip="Enter Password"></asp:TextBox>
                        </div>
                        <div class="mb-2">
                            <label for="confirmPassword" class="form-label">Confirm Password</label>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" Required="True" ToolTip="Re-enter Password"></asp:TextBox>
                        </div>

                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger "></asp:Label>

                        <div class="d-flex justify-content-between mt-5">
                            <asp:Button ID="btnSignUp" runat="server" CssClass="btn bg-white form-control custom-btn" Text="Sign Up"/>
                        </div>
                        <div class="d-flex justify-content-between">
                            <p>Already have an account?</p>
                            <a href="Login.aspx" class="text-white">Login</a>
                        </div>
                    </form>
                </div>
            </div>

            <!-- Right Side (White) -->
            <div class="col-md-6 login-right d-none d-md-block align-content-center">
                <div>
                    <p class="welcome-text">Join the Library Management Portal</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
