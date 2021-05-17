using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace AT7_AT8_projet
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        SqlConnection cn_ComVoyage = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        void Remplir_GridView()
        {
            cn_ComVoyage.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select*from chauffeur", cn_ComVoyage);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            gv_Chauffeur.DataSource = dt;
            gv_Chauffeur.DataBind();
            cn_ComVoyage.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                Remplir_GridView();
                BindChauffeur();
            }

        }

        protected void gv_Chauffeur_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = gv_Chauffeur.DataKeys[e.RowIndex].Value.ToString();
            TextBox txtname = (TextBox)gv_Chauffeur.Rows[e.RowIndex].FindControl("TextBoxNom");
            TextBox txtprenom = (TextBox)gv_Chauffeur.Rows[e.RowIndex].FindControl("TextBoxPrenom");
            TextBox txtadresse = (TextBox)gv_Chauffeur.Rows[e.RowIndex].FindControl("TextBoxAdresse");
            TextBox txtdateR = (TextBox)gv_Chauffeur.Rows[e.RowIndex].FindControl("TextBoxDateRec");
            TextBox txtsalaire = (TextBox)gv_Chauffeur.Rows[e.RowIndex].FindControl("TextBoxSalaire");
            mofifier_Chauffeur(id, txtname.Text, txtprenom.Text, txtadresse.Text, txtdateR.Text, float.Parse(txtsalaire.Text));
            gv_Chauffeur.EditIndex = -1;
            Remplir_GridView();
        }

        protected void gv_Chauffeur_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_Chauffeur.EditIndex = -1;
            Remplir_GridView();
        }

        protected void gv_Chauffeur_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gv_Chauffeur.DataKeys[e.RowIndex].Value.ToString();
            supprimer_Chauffeur(id);
            Remplir_GridView();
        }
        private void mofifier_Chauffeur(string id,string nom,string prenom,string adresse,string dateR,float salaire) 
        {
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"update chauffeur set  nom ='{nom}',prenom='{prenom}',adresse ='{adresse}',Date_Recrutement ='{dateR}' ,salaire ='{salaire}' where ID_chauffeur ='{id}'", cn_ComVoyage);
            cmd.ExecuteNonQuery();
            cn_ComVoyage.Close();
        }
        private void supprimer_Chauffeur(string id)
        {
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"delete from chauffeur where ID_chauffeur ='{id}'", cn_ComVoyage);
            cmd.ExecuteNonQuery();
            cn_ComVoyage.Close();
        }

        protected void gv_Chauffeur_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_Chauffeur.EditIndex = e.NewEditIndex;
            Remplir_GridView();
        }

        void BindChauffeur()
        {
            DataTable dt = new DataTable();
            
                cn_ComVoyage.Open();
                SqlCommand cmd = new SqlCommand("Select Distinct  ID_Chauffeur  from chauffeur", cn_ComVoyage);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cn_ComVoyage.Close();
                ddlIdChauffeur.DataSource = dt;
                ddlIdChauffeur.DataTextField = "ID_Chauffeur";
                ddlIdChauffeur.DataValueField = "ID_Chauffeur";
                ddlIdChauffeur.DataBind();
                cn_ComVoyage.Close();
            
        }

        protected void ddlIdChauffeur_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
           
                cn_ComVoyage.Open();
                if (ddlIdChauffeur.SelectedValue != "Tous")
                {
                    SqlCommand cmd = new SqlCommand("select * from Chauffeur where ID_Chauffeur =@id", cn_ComVoyage);
                    cmd.Parameters.AddWithValue("@id", ddlIdChauffeur.SelectedValue);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                else 
                {
                    SqlCommand cmd = new SqlCommand("select * from Chauffeur", cn_ComVoyage);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                cn_ComVoyage.Close();
                gv_Chauffeur.DataSource = dt;
                gv_Chauffeur.DataBind();
            
        }

      
    }
}