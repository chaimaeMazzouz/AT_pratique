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
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection cn_ComVoyage = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        String pseudo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            if ((Session["matricule"] != null)&& (Session["nom"] != null)&& (Session["prenom"] != null)&& (Session["service"] != null) && (Session["mail"] != null))
            {
                
                matricule.Text = Session["matricule"].ToString();
                Nom.Text = Session["nom"].ToString();
                Prenom.Text = Session["prenom"].ToString();
                DdlService.SelectedValue = Session["service"].ToString();
                Email.Text = Session["mail"].ToString();
                lblHeader.Text = $"{Session["nom"]} {Session["prenom"]}";
                
            }
            pseudo = Session["pseudo"].ToString();


        }
       
        protected void BtnModifier_Click(object sender, EventArgs e)
        {
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"update membre set matricule='{ matricule.Text}', nom ='{Nom.Text}',prenom='{Prenom.Text}',service_ ='{DdlService.Text}',mail ='{Email.Text}' where pseudo ='{pseudo}'",cn_ComVoyage);
            cmd.ExecuteNonQuery();
            cn_ComVoyage.Close();
            Response.Write("<script>alert('Modification effuctuée')</script>");
        }

        protected void BtnDeconnecter_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Cookies.Clear();
            Response.Redirect("index.aspx");
        }
    }
}