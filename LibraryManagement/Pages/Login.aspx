<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibraryManagement.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row h-100">
            <!-- Left side (Black) -->
            <div class="col-md-6 login-left ">
                <div class="login-form">
                    <h3 class="text-center mb-4">Login</h3>
                    <form method="post" id="loginForm" runat="server">
                        <div class="mb-2">
                            <label for="username" class="form-label">Username</label>
                            <asp:TextBox ID="username" runat="server" CssClass="form-control " Required="True" ToolTip="username"></asp:TextBox>
                        </div>
                        <div class="mb-2">
                            <label for="password" class="form-label">Password</label>
                            <asp:TextBox ID="password" runat="server" CssClass="form-control bg-black " TextMode="Password" Required="True" ToolTip="password"></asp:TextBox>
                        </div>
                 
                        <div class="d-flex justify-content-between mt-3">
                            <asp:Button ID="LoginButton" runat="server" CssClass="btn bg-white form-control custom-btn" Text="Login" />
                        </div>
                        <div class="d-flex justify-content-between mt-3">
                            <p>Don't Have an account</p>
                            <a href="SignUp.aspx" class=" text-white">Sign Up</a>
                        </div>

                    </form>
                </div>
            </div>

            <!-- Right side (White) -->
            <div class="col-md-6 login-right d-none d-md-block align-content-center">
                <div>
                    <p class="welcome-text">Welcome Back to the Library Management Portal</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
