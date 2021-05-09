using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace AT7_AT8_projet
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        SqlConnection cn_ComVoyage = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pseudo"] != null && Session["matricule"] != null && Session["nom"] != null && Session["prenom"] != null && Session["service"] != null && Session["mail"] != null && Session["categ"] != null)
            {
                if (!IsPostBack)
                {
                    Remplir_GridView();

                }
            }
            else
                Server.Transfer("index.aspx");
                
        }
        void Remplir_GridView()
        {
            cn_ComVoyage.Open();
            SqlCommand cmd_rp = new SqlCommand("select pseudo,matricule,nom,prenom,service_,mail,categorie from membre where categorie ='Membre' or categorie ='Administrateur'", cn_ComVoyage);
            GridView1.DataSource = cmd_rp.ExecuteReader();
            GridView1.DataBind();
            cn_ComVoyage.Close();

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int r = e.NewSelectedIndex;
            TextBoxPseudo.Text = GridView1.Rows[r].Cells[1].Text;
            Prenom.Text = GridView1.Rows[r].Cells[4].Text;
            Nom.Text = GridView1.Rows[r].Cells[3].Text;
            Email.Text = GridView1.Rows[r].Cells[6].Text;
            matricule.Text = GridView1.Rows[r].Cells[2].Text;
            DdlService.Text = GridView1.Rows[r].Cells[5].Text;
        }

        protected void BtnModifier_Click(object sender, EventArgs e)
        {
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"update membre set matricule='{ matricule.Text}', nom ='{Nom.Text}',prenom='{Prenom.Text}',service_ ='{DdlService.Text}',mail ='{Email.Text}' where pseudo ='{TextBoxPseudo.Text}'", cn_ComVoyage);
            cmd.ExecuteNonQuery();
            cn_ComVoyage.Close();
            Remplir_GridView();
        }

        protected void BtnSupprimer_Click(object sender, EventArgs e)
        {
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"delete membre  where pseudo ='{TextBoxPseudo.Text}'", cn_ComVoyage);
            cmd.ExecuteNonQuery();
            cn_ComVoyage.Close();
            Remplir_GridView();
            TextBoxPseudo.Text = "";
            Prenom.Text = "";
            Nom.Text = "";
            Email.Text = "";
            matricule.Text = "";
            DdlService.SelectedIndex = 0;
        }
    }
}