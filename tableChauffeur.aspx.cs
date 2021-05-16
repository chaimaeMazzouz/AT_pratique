using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            //SqlCommand cmd_rp = new SqlCommand("select*from chauffeur", cn_ComVoyage);
            //gv_Chauffeur.DataSource = cmd_rp.ExecuteReader();
            //gv_Chauffeur.DataBind();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select*from chauffeur", cn_ComVoyage);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            gv_Chauffeur.DataSource = dt;
            gv_Chauffeur.DataBind();
            cn_ComVoyage.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Filter"] = "ALL";
                Remplir_GridView();
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

        protected void ddlIdCh_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlChauffeur = (DropDownList)sender;
            ViewState["Filter"] = ddlChauffeur.SelectedValue;
            this.Remplir_GridView();
        }
        void BindCountryList(DropDownList ddlCountry)
        {
            //cn_ComVoyage.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("select ID_Chauffeur  from chauffeur ",cn_ComVoyage);
            cmd.Connection = cn_ComVoyage;
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlCountry.DataSource = dt;
            ddlCountry.DataTextField = "ID_Chauffeur";
            ddlCountry.DataValueField = "ID_Chauffeur";
            ddlCountry.DataBind();
            ddlCountry.Items.FindByValue(ViewState["Filter"].ToString()).Selected = true;
            //cn_ComVoyage.Close();
        }

        protected void gv_Chauffeur_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lbl = new Label();
                lbl.Text = "ID Chauffeur:";
                e.Row.Cells[0].Controls.Add(lbl);
                DropDownList ddl = new DropDownList();
                ddl.ID = "ddlIdCh";  
                ddl.AutoPostBack = true;
                ddl.Items.Add(new ListItem("All", "ALL"));
                ddl.Items.Add(new ListItem("TOP 10", "10"));
                ddl.AppendDataBoundItems = true;
                ddl.SelectedIndexChanged += new EventHandler(ddlIdCh_SelectedIndexChanged);
                this.BindCountryList(ddl);
                e.Row.Cells[0].Controls.Add(ddl);
            }
        }
    }
}