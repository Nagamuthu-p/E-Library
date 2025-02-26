using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using LibraryManagement.DataAccess; // Ensure correct namespace

namespace LibraryManagement.Pages
{
    public partial class ApplyLeave : Page
    {
        protected int LoggedInUserID = 1; // Stores logged-in user ID

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserID"] == null)
            //{
            //    Response.Redirect("Login.aspx"); // Redirect to login if session expired
            //}

            //LoggedInUserID = Convert.ToInt32(Session["UserID"]); // Get logged-in UserID

            if (!IsPostBack)
            {
                LoadUserDetails();
                LoadLeaveTypes();
                LoadAppliedLeaves();
            }
        }

        private void LoadUserDetails()
        {
            DataTable dt = DBHelper.ExecuteQuery($"SELECT Username FROM Users WHERE UserID = {LoggedInUserID}");
            if (dt.Rows.Count > 0)
            {
                txtEmployeeName.Text = dt.Rows[0]["Username"].ToString(); // Auto-fill Employee Name
            }
        }

        private void LoadLeaveTypes()
        {
            DataTable dt = DBHelper.ExecuteQuery("SELECT DISTINCT LeaveType FROM EmployeeLeave WHERE UserID = " + LoggedInUserID);
            ddlLeaveTypes.DataSource = dt;
            ddlLeaveTypes.DataTextField = "LeaveType";
            ddlLeaveTypes.DataValueField = "LeaveType";
            ddlLeaveTypes.DataBind();
            ddlLeaveTypes.Items.Insert(0, new ListItem("-- Select Leave Type --", ""));
        }

        private void LoadAppliedLeaves()
        {
            DataTable dt = DBHelper.ExecuteQuery($@"
                SELECT LeaveType,LeaveDays, FromDate, ToDate, ApprovalStatus
                FROM EmployeeLeave WHERE UserID = {LoggedInUserID}
            ");
            gvAppliedLeaves.DataSource = dt;
            gvAppliedLeaves.DataBind();
        }

        protected void ApplyLeaves(object sender, EventArgs e)
        {
            string leaveType = ddlLeaveTypes.SelectedValue;
            //int leaveDays = Convert.ToInt32(txtLeaveDays.Text);
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);

            if (string.IsNullOrEmpty(leaveType))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please select a Leave Type!');", true);
                return;
            }

            SqlParameter[] parameters = {
                new SqlParameter("@UserID", LoggedInUserID),
                new SqlParameter("@LeaveType", leaveType),
                //new SqlParameter("@LeaveDays", leaveDays),
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };

            try
            {
                DataTable result = DBHelper.ExecuteQuery("sp_ApplyForLeave", parameters,true);

                if (result.Rows[0]["Message"].ToString() == "leave Applied.")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Leave Applied Successfully!');", true);
                    LoadAppliedLeaves(); // Refresh GridView
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Error applying leave!');", true);
                }
            }
            catch (SqlException ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('{ex.Message}');", true);
            }
        }
    }
}
