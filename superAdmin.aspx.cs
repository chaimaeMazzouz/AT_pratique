using System;
using System.Configuration;
using System.Data.SqlClient;

namespace AT7_AT8_projet
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        SqlConnection cn_ComVoyage = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        String pseudo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                if ((Session["matricule"] != null) && (Session["nom"] != null) && (Session["prenom"] != null) && (Session["service"] != null) && (Session["mail"] != null))
                {

                    matricule.Text = Session["matricule"].ToString();
                    Nom.Text = Session["nom"].ToString();
                    Prenom.Text = Session["prenom"].ToString();
                    DdlService.SelectedValue = Session["service"].ToString();
                    Email.Text = Session["mail"].ToString();
                    lblHeader.Text = $"{Session["nom"]} {Session["prenom"]}";

                }
                else
                    Server.Transfer("index.aspx");
            if (String.Equals(Session["service"], "Ressources Humaines"))
            {
                hlTable.Text = "Gestion chauffeur";
                hlTable.NavigateUrl = "tableChauffeur.aspx";
            }
            else if (String.Equals(Session["service"], "Logistique"))
            {
                hlTable.Text = "Gestion véhicule";
                hlTable.NavigateUrl = "tableVehicule.aspx";
            }
            else if (String.Equals(Session["service"], "Marketing"))
            {
                hlTable.Text = "Gestion voyage et billet";
                hlTable.NavigateUrl = "tablesVoyageBillet.aspx";
            }
            pseudo = Session["pseudo"].ToString();
            Remplir_GridView();
        }
        void Remplir_GridView()
        {
            cn_ComVoyage.Open();
            SqlCommand cmd_rp = new SqlCommand("select*from membre where categorie ='Membre' or  categorie='Administrateur'", cn_ComVoyage);
            GridView1.DataSource = cmd_rp.ExecuteReader();
            GridView1.DataBind();
            cn_ComVoyage.Close();
        }

        protected void BtnModifier_Click(object sender, EventArgs e)
        {
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"update membre set matricule='{ matricule.Text}', nom ='{Nom.Text}',prenom='{Prenom.Text}',service_ ='{DdlService.Text}',mail ='{Email.Text}' where pseudo ='{pseudo}'", cn_ComVoyage);
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