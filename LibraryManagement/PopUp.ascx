<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PopUp.ascx.cs" Inherits="LibraryManagement.PopUp" %>



<div class="modal fade" id="addLeaveTypeModal" tabindex="-1" aria-labelledby="addLeaveTypeLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title text-primary">Add/Edit Leave Type</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
         
                    <!-- Dynamic Fields Panel -->
                    <asp:Panel ID="formPanel" runat="server" CssClass="mb-3"></asp:Panel>

                    <div class="modal-footer">
                        <asp:Button ID="btnSaveLeaveType" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="SaveLeaveGroup" />
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    </div>
          
            </div>
        </div>
    </div>
</div>
