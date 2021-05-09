using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AT7_AT8_projet
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection cn_ComVoyage = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        protected void btnAjout_Click(object sender, EventArgs e)
        {
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"insert into membre values('{pseudo.Text}','{password.Text}','{matricule.Text}','{lastName.Text}','{firstName.Text}','{DdlService.SelectedValue}','{email.Text}','{DdlCategorie.SelectedValue}')",cn_ComVoyage);
            cmd.ExecuteNonQuery();
            cn_ComVoyage.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted');", true);
            Server.Transfer("index.aspx");

        }
    }
}