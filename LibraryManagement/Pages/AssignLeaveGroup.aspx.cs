using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using LibraryManagement.DataAccess; // Ensure correct namespace

namespace LibraryManagement.Pages
{
    public partial class AssignLeaveGroup : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
                LoadLeaveGroups();
                LoadAssignedLeaveGroups();
            }
        }

        private void LoadUsers()
        {
            DataTable dt = DBHelper.ExecuteQuery("SELECT UserID, Username FROM Users WHERE UserType = 'Employee'");
            ddlUsers.DataSource = dt;
            ddlUsers.DataTextField = "Username";
            ddlUsers.DataValueField = "UserID";
            ddlUsers.DataBind();
            ddlUsers.Items.Insert(0, new ListItem("-- Select Employee --", "0"));
        }

        private void LoadLeaveGroups()
        {
            DataTable dt = DBHelper.ExecuteQuery("SELECT LeaveTypeID, LeaveName FROM LeaveTypes ");
            ddlLeaveGroups.DataSource = dt;
            ddlLeaveGroups.DataTextField = "LeaveName";
            ddlLeaveGroups.DataValueField = "LeaveTypeID";
            ddlLeaveGroups.DataBind();
            ddlLeaveGroups.Items.Insert(0, new ListItem("-- Select Leave Group --", "0"));
        }

        private void LoadAssignedLeaveGroups()
        {
            DataTable dt = DBHelper.ExecuteQuery(@"
                SELECT U.UserID, U.Username, LG.LeaveTypeID, LG.LeaveName 
                FROM EmployeeLeave EL
                JOIN Users U ON EL.UserID = U.UserID
                JOIN LeaveTypes LG ON EL.LeaveGroupID = LG.LeaveTypeID
            ");
            gvAssignedLeaveGroups.DataSource = dt;
            gvAssignedLeaveGroups.DataBind();
        }

        protected void AssignLeaveGroups(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(ddlUsers.SelectedValue);
            int leaveGroupID = Convert.ToInt32(ddlLeaveGroups.SelectedValue);

            System.Diagnostics.Debug.WriteLine(userID);
            System.Diagnostics.Debug.WriteLine(leaveGroupID);

            if (userID == 0 || leaveGroupID == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please select an Employee and a Leave Group!');", true);
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", userID),
                new SqlParameter("@LeaveGroupID", leaveGroupID)
            };

            DataTable result = DBHelper.ExecuteQuery("sp_AssignLeaveGroup", parameters,true);

            if (result.Rows[0]["Message"].ToString() == "Group Assigned Successfully" && result!=null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Leave Group Assigned Successfully!');", true);
                LoadAssignedLeaveGroups(); // Refresh GridView
            }
            else
            {
                string res = result.Rows[0]["Message"].ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('already');", true);
            }
        }
    }
}
