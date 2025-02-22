<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LeaveGroup.aspx.cs" Inherits="LibraryManagement.Pages.LeaveGroup" %>

<%@ Register Src="~/PopUp.ascx" TagPrefix="uc" TagName="PopUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5 p-5">
        <h2 class="text-center text-primary">Manage Leave Types</h2>

        <!-- Add Leave Type Button -->
        <div class="text-end">
            <asp:Button ID="btnShowPopup" runat="server" Text="Add Leave Type" CssClass="btn btn-success" OnClick="CallPopUp" />
        </div>
       



        <!-- Bootstrap Modal for Adding Leave Type -->
        <uc:PopUp runat="server" ID="LeaveTypeModalControl" />

        <hr>
    </div>

    <script>
        function openModal() {
            console.log("Opening Modal...");
            var modal = new bootstrap.Modal(document.getElementById('addLeaveTypeModal'));
            modal.show();
        }
    </script>
   
</asp:Content>
