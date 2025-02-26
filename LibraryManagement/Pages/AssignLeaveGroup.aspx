<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssignLeaveGroup.aspx.cs" Inherits="LibraryManagement.Pages.AssignLeaveGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class=" container mt-5 p-5">
         <h2 class="text-center text-primary">Assign Leave Group to Employee</h2>

 <div class="mb-3">
     <label class="form-label">Select Employee:</label>
     <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control"></asp:DropDownList>
 </div>

 <div class="mb-3">
     <label class="form-label">Select Leave Group:</label>
     <asp:DropDownList ID="ddlLeaveGroups" runat="server" CssClass="form-control"></asp:DropDownList>
 </div>

 <div class="text-end">
     <asp:Button ID="btnAssignLeaveGroup" runat="server" Text="Assign Leave Group" CssClass="btn btn-primary" OnClick="AssignLeaveGroups" />
 </div>

 <h3 class="mt-4">Assigned Leave Groups</h3>
 <asp:GridView ID="gvAssignedLeaveGroups" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mt-3"
     EmptyDataText="No leave groups assigned.">
     <Columns>
         <asp:BoundField DataField="UserID" HeaderText="User ID" />
         <asp:BoundField DataField="Username" HeaderText="Username" />
         <asp:BoundField DataField="LeaveTypeID" HeaderText="Leave Group ID" />
         <asp:BoundField DataField="LeaveName" HeaderText="Leave Type" />
     </Columns>
 </asp:GridView>
    </div>
  
       

</asp:Content>
