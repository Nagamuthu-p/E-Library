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


    <h3 class="mt-4">Available Leave Types</h3>
<asp:GridView ID="gvLeaveTypes" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mt-3" EmptyDataText="No leave types found.">
    <Columns>
        <asp:BoundField DataField="LeaveTypeID" HeaderText="ID" />
        <asp:BoundField DataField="LeaveName" HeaderText="Leave Name" />
        <asp:BoundField DataField="EligibleDays" HeaderText="Eligible Days" />
    </Columns>
</asp:GridView>
    <script>
        function openModal() {
            console.log("Opening Modal...");
            var modal = new bootstrap.Modal(document.getElementById('addLeaveTypeModal'));
            modal.show();
        }
    </script>
   
</asp:Content>
