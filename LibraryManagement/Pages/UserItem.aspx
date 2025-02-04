<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserItem.aspx.cs" Inherits="LibraryManagement.Pages.UserItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" card">
        <div class="card-body">
            <div class="row">
                <div class="col">
                    <center>
                        <h2>Your Issued Books</h2>
                        <img src="../Fontawesome/svgs/solid/book-open.svg" width="50" height="50" class="card-img" />
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <hr >
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <form runat="server">
                    <asp:GridView ID="table" runat="server" CssClass=" table table-striped table-bordered"></asp:GridView>
                        </form>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
