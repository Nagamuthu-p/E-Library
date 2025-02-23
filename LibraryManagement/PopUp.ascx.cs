using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagement.DataAccess;
using System.Collections.Generic;
using LibraryManagement.Pages;

namespace LibraryManagement
{
    public partial class PopUp : System.Web.UI.UserControl
    {
        public string Query
        {
            get { return ViewState["Query"] as string; }
            set { ViewState["Query"] = value; }
        }

        public string SP
        {
            get { return ViewState["SP"] as string; }
            set { ViewState["SP"] = value; } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Query))
            {
                LoadingDynamic(Query);
            }
        }

        public void LoadingDynamic(string query)
        {
            if (string.IsNullOrEmpty(query)) return;

            DataTable dt = DBHelper.ExecuteQuery(query, null, false);
            formPanel.Controls.Clear(); // ✅ Clear previous controls

            foreach (DataColumn dataColumn in dt.Columns)
            {
                string fieldName = dataColumn.ColumnName;
                string controlID = "txt" + fieldName; // ✅ Ensure ID matches

                Panel divWrapper = new Panel();
                divWrapper.CssClass = "mb-3";

                Label lbl = new Label();
                lbl.Text = fieldName + ":";
                lbl.CssClass = "form-label";
                lbl.AssociatedControlID = controlID;

                TextBox txt = new TextBox();
                txt.ID = controlID; // ✅ Ensure ID matches FindControl
                txt.CssClass = "form-control";

                if (GetFieldType(dataColumn.DataType) == "Number") txt.TextMode = TextBoxMode.Number;
                else if (GetFieldType(dataColumn.DataType) == "Date") txt.TextMode = TextBoxMode.Date;

                divWrapper.Controls.Add(lbl);
                divWrapper.Controls.Add(txt);
                formPanel.Controls.Add(divWrapper);
            }

           
        }

        private string GetFieldType(Type dataType)
        {
            if (dataType == typeof(int) || dataType == typeof(decimal) || dataType == typeof(float))
                return "Number";
            if (dataType == typeof(DateTime))
                return "Date";
            return "Text";
        }

        protected void SaveLeaveGroup(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Query) || string.IsNullOrEmpty(SP)) return;

            DataTable dt = DBHelper.ExecuteQuery(Query);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            foreach (DataColumn column in dt.Columns)
            {
                string fieldName = column.ColumnName;
                string controlID = "txt" + fieldName;

                TextBox txtbox = (TextBox)FindControlRecursive(formPanel, controlID); // ✅ Use recursive function

                

                if (!string.IsNullOrEmpty(txtbox.Text))
                {
                   
                    sqlParameters.Add(new SqlParameter("@" + fieldName, txtbox.Text));
                }
            }

            if (sqlParameters.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('No data entered!');", true);
                return;
            }

            object result = DBHelper.ExecuteScalar(SP, sqlParameters.ToArray());

            if (result != null && result.ToString() == "saved")
            {
                ((LeaveGroup)this.Page).LoadLeaveTypes();
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Data Saved Successfully!'); location.reload();", true);
            }
        }




        private Control FindControlRecursive(Control parent, string id)
        {
            if (parent.ID == id) return parent;

            foreach (Control child in parent.Controls)
            {
                Control found = FindControlRecursive(child, id);
                if (found != null) return found;
            }

            return null;
        }
    }
}
