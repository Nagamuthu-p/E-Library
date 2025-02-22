using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement.Pages
{
    public partial class LeaveGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CallPopUp(object sender, EventArgs e)
        {
            if (LeaveTypeModalControl != null)
            {
                // Set query to load dynamic fields
                LeaveTypeModalControl.Query = "SELECT LeaveName, EligibleDays FROM LeaveTypes WHERE 1=0";
                LeaveTypeModalControl.LoadingDynamic(LeaveTypeModalControl.Query);
            }

            // Open Bootstrap modal using JavaScript
            ScriptManager.RegisterStartupScript(this, GetType(), "showPopup", "openModal();", true);
        }
    }

    
    
}