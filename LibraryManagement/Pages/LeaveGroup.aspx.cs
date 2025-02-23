using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagement.DataAccess;

namespace LibraryManagement.Pages
{
    public partial class LeaveGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLeaveTypes();
            }
        }

        protected void CallPopUp(object sender, EventArgs e)
        {
            if (LeaveTypeModalControl != null)
            {
                // Set query to load dynamic fields
                LeaveTypeModalControl.Query = "SELECT LeaveName, EligibleDays FROM LeaveTypes WHERE 1=0";
                LeaveTypeModalControl.SP = "sp_SaveLeaveGroup";
                LeaveTypeModalControl.LoadingDynamic(LeaveTypeModalControl.Query);
            }

            // Open Bootstrap modal using JavaScript
            ScriptManager.RegisterStartupScript(this, GetType(), "showPopup", "openModal();", true);
        }

        protected void gvLeaveTypes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int leaveTypeID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditLeave")
            {
                // ✅ Open PopUp to Edit the Leave Type
                if (LeaveTypeModalControl != null)
                {
                    LeaveTypeModalControl.Query = $"SELECT LeaveName, EligibleDays FROM LeaveTypes WHERE LeaveTypeID = {leaveTypeID}";
                    LeaveTypeModalControl.SP = "sp_UpdateLeaveGroup"; // ✅ Call Update Stored Procedure
                    LeaveTypeModalControl.LoadingDynamic(LeaveTypeModalControl.Query);
                }

           
            }
            else if (e.CommandName == "DeleteLeave")
            {
                // ✅ Delete the Leave Type
                SqlParameter[] parameters = { new SqlParameter("@LeaveTypeID", leaveTypeID) };
                object result = DBHelper.ExecuteScalar("sp_DeleteLeaveGroup", parameters);

                if (result!=null && result.ToString()=="deleted")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Leave Type Deleted Successfully!');", true);
                    LoadLeaveTypes(); 
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Error deleting leave type!');", true);
                }
            }
        }


        public void LoadLeaveTypes()
        {
            DataTable dt = DBHelper.ExecuteQuery("SELECT LeaveTypeID, LeaveName, EligibleDays FROM LeaveTypes");
            gvLeaveTypes.DataSource = dt;
            gvLeaveTypes.DataBind();
        }


    }

    
    
}