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

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlCommand cmd_pseudo = new SqlCommand("Select count(*) from membre where pseudo=@numPs");
            cmd_pseudo.Connection = cn_ComVoyage;
            SqlParameter pnum = new SqlParameter("@numPs", SqlDbType.VarChar);
            cmd_pseudo.Parameters.Add(pnum);
            pnum.Value = args.Value.ToString();
            cn_ComVoyage.Open();
            int nbre = (int)cmd_pseudo.ExecuteScalar();
            if (nbre != 0)
                args.IsValid = false;
            else
                args.IsValid = true;
            cn_ComVoyage.Close();
        }
    }
}