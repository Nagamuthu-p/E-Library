<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApplyLeave.aspx.cs" Inherits="LibraryManagement.Pages.ApplyLeave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" container">
        <h2 class="text-center text-primary">Apply for Leave</h2>

    <!-- ✅ Auto-fill Username -->
    <div class="mb-3">
        <label class="form-label">Employee Name:</label>
        <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">Select Leave Type:</label>
        <asp:DropDownList ID="ddlLeaveTypes" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>

    
    <div class="mb-3">
        <label class="form-label">From Date:</label>
        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <div class="mb-3">
        <label class="form-label">To Date:</label>
        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <div class="text-end">
        <asp:Button ID="btnApplyLeave" runat="server" Text="Apply Leave" CssClass="btn btn-primary" OnClick="ApplyLeaves" />
    </div>

    <h3 class="mt-4">Your Applied Leave Requests</h3>
    <asp:GridView ID="gvAppliedLeaves" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mt-3"
        EmptyDataText="No leave applications found.">
        <Columns>
            <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" />
            <asp:BoundField DataField="LeaveDays" HeaderText="Leave Days" />
            <asp:BoundField DataField="FromDate" HeaderText="From Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="ToDate" HeaderText="To Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="ApprovalStatus" HeaderText="Status" />
        </Columns>
    </asp:GridView>
    </div>
    
</asp:Content>
