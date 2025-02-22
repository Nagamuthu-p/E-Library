using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryManagement.DataAccess;

namespace LibraryManagement
{
    public partial class PopUp : System.Web.UI.UserControl
    {

        public string Query
        {
            get { return ViewState["Query"] as string; }  
            set { ViewState["Query"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !string.IsNullOrEmpty(Query))
            {
                LoadingDynamic(Query);
            }
        }

        public void LoadingDynamic(string query)
        {
            if (string.IsNullOrEmpty(query)) return;

            DataTable dt = DBHelper.ExecuteQuery(query,null,false);

            Console.WriteLine(query);

            foreach(DataColumn dataColumn in dt.Columns)
            {
                string fieldName = dataColumn.ColumnName;
                string fieldType = GetFieldType(dataColumn.DataType);

                Panel divWrapper = new Panel();
                divWrapper.CssClass = "mb-3";

                Label lbl = new Label();
                lbl.Text = fieldName + ":";
                lbl.CssClass = "form-label";

                TextBox txt = new TextBox();
                txt.ID = "txt" + fieldName;
                txt.CssClass = "form-control";

                divWrapper.Controls.Add(lbl);
                divWrapper.Controls.Add(txt);

                // Add Wrapper to Form Panel
                formPanel.Controls.Add(divWrapper);

                if (fieldType == "Number") txt.TextMode = TextBoxMode.Number;
                else if (fieldType == "Date") txt.TextMode = TextBoxMode.Date;

                formPanel.Controls.Add(lbl);
                formPanel.Controls.Add(txt);


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
    }
}