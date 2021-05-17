using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace AT7_AT8_projet
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        SqlConnection cn_ComVoyage = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        void Remplir_GridView_Voyage()
        {
            cn_ComVoyage.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select*from voyage", cn_ComVoyage);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            gv_Voyage.DataSource = dt;
            gv_Voyage.DataBind();
            cn_ComVoyage.Close();
        }
        void BindVoyage()
        {
            DataTable dt = new DataTable();

            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand("Select Distinct  ID_Voyage  from Voyage", cn_ComVoyage);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cn_ComVoyage.Close();
            ddlIdVehicule.DataSource = dt;
            ddlIdVehicule.DataTextField = "ID_Voyage";
            ddlIdVehicule.DataValueField = "ID_Voyage";
            ddlIdVehicule.DataBind();
            cn_ComVoyage.Close();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Remplir_GridView_Voyage();
                BindVoyage();
                Remplir_GridView_billet();
                Bindbillet();
            }
        }

        protected void gv_Voyage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_Voyage.EditIndex = -1;
            Remplir_GridView_Voyage();
        }

        protected void gv_Voyage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(gv_Voyage.DataKeys[e.RowIndex].Value.ToString());
            supprimer_Voyage(id);
            Remplir_GridView_Voyage();
        }

        protected void gv_Voyage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(gv_Voyage.DataKeys[e.RowIndex].Value.ToString());
            TextBox txtDate_Voyage = (TextBox)gv_Voyage.Rows[e.RowIndex].FindControl("TextBoxDate_Voyage");
            TextBox txtVilleD = (TextBox)gv_Voyage.Rows[e.RowIndex].FindControl("TextBoxVille_Depart");
            TextBox txtVilleA = (TextBox)gv_Voyage.Rows[e.RowIndex].FindControl("TextBoxVille_Arrive");
            TextBox txtDuree = (TextBox)gv_Voyage.Rows[e.RowIndex].FindControl("TextBoxDuree");
            TextBox txtNbrV = (TextBox)gv_Voyage.Rows[e.RowIndex].FindControl("TextBoxNbre_Voyageurs");
            TextBox txtPlaceL = (TextBox)gv_Voyage.Rows[e.RowIndex].FindControl("TextBoxPlace_libre");
            TextBox txtTarif = (TextBox)gv_Voyage.Rows[e.RowIndex].FindControl("TextBoxTarif");
            TextBox txtID_ch = (TextBox)gv_Voyage.Rows[e.RowIndex].FindControl("TextBoxID_chauffeur");
            TextBox txtMat = (TextBox)gv_Voyage.Rows[e.RowIndex].FindControl("TextBoxImmatricule");
            mofifier_Voyage(id, txtDate_Voyage.Text, txtVilleD.Text, txtVilleA.Text,float.Parse(txtDuree.Text),int.Parse(txtNbrV.Text),int.Parse(txtPlaceL.Text),float.Parse(txtTarif.Text),txtID_ch.Text,txtMat.Text);
            gv_Voyage.EditIndex = -1;
            Remplir_GridView_Voyage();
        }

        protected void gv_Voyage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_Voyage.EditIndex = e.NewEditIndex;
            Remplir_GridView_Voyage();
        }

        protected void ddlIdVehicule_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            cn_ComVoyage.Open();
            if (ddlIdVehicule.SelectedValue != "Tous")
            {
                SqlCommand cmd = new SqlCommand("select * from Voyage where ID_Voyage =@id", cn_ComVoyage);
                cmd.Parameters.AddWithValue("@id", ddlIdVehicule.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from Voyage", cn_ComVoyage);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            cn_ComVoyage.Close();
            gv_Voyage.DataSource = dt;
            gv_Voyage.DataBind();
        }
        private void mofifier_Voyage(int id,string DateV, string VilleD, string VilleA,float duree,int nbreV,int placeL,float  Tarif, string id_ch,string mat )
        { 
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"update voyage set  Date_Voyage ='{DateV}',Ville_Depart='{VilleD}',Ville_Arrive ='{VilleA}' ,Duree={duree} ,Nbre_Voyageurs={nbreV},Place_libre={placeL} ,Tarif={Tarif} ,ID_chauffeur='{id_ch}' ,Immatricule='{mat}' where ID_Voyage ={id}", cn_ComVoyage);
            cmd.ExecuteNonQuery();
            cn_ComVoyage.Close();
        }
        private void supprimer_Voyage(int id)
        {
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"delete from Voyage where ID_Voyage ={id}", cn_ComVoyage);
            cmd.ExecuteNonQuery();
            cn_ComVoyage.Close();
        }
        void Remplir_GridView_billet()
        {
            cn_ComVoyage.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select*from billet", cn_ComVoyage);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            gv_billet.DataSource = dt;
            gv_billet.DataBind();
            cn_ComVoyage.Close();
        }
        void Bindbillet()
        {
            DataTable dt = new DataTable();

            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand("Select Distinct  N_billet  from billet", cn_ComVoyage);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cn_ComVoyage.Close();
            ddlBillet.DataSource = dt;
            ddlBillet.DataTextField = "N_billet";
            ddlBillet.DataValueField = "N_billet";
            ddlBillet.DataBind();
            cn_ComVoyage.Close();

        }
        protected void ddlBillet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            cn_ComVoyage.Open();
            if (ddlBillet.SelectedValue != "Tous")
            {
                SqlCommand cmd = new SqlCommand("select * from billet where N_billet =@Num", cn_ComVoyage);
                cmd.Parameters.AddWithValue("@Num", ddlBillet.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from billet", cn_ComVoyage);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            cn_ComVoyage.Close();
            gv_billet.DataSource = dt;
            gv_billet.DataBind();
        }

        protected void gv_billet_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_billet.EditIndex = -1;
            Remplir_GridView_billet();
        }

        protected void gv_billet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(gv_billet.DataKeys[e.RowIndex].Value.ToString());
            supprimer_billet(id);
            Remplir_GridView_billet();
        }

        protected void gv_billet_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = int.Parse(gv_billet.DataKeys[e.RowIndex].Value.ToString());
            TextBox txtDate_D = (TextBox)gv_billet.Rows[e.RowIndex].FindControl("TextBoxDate_Delivrance");
            TextBox txtId_Voyage = (TextBox)gv_billet.Rows[e.RowIndex].FindControl("TextBoxID_Voyage");
            mofifier_billet(id, txtDate_D.Text,int.Parse(txtId_Voyage.Text) );
            gv_Voyage.EditIndex = -1;
            Remplir_GridView_billet();
        }

        protected void gv_billet_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_billet.EditIndex = e.NewEditIndex;
            Remplir_GridView_billet();
        }
        private void mofifier_billet(int Num, string DateD, int idV)
        {
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"update billet set  Date_Delivrance ='{DateD}',ID_Voyage={idV} where N_Billet ={Num}", cn_ComVoyage);
            cmd.ExecuteNonQuery();
            cn_ComVoyage.Close();
        }
        private void supprimer_billet(int id)
        {
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"delete from billet where N_billet ={id}", cn_ComVoyage);
            cmd.ExecuteNonQuery();
            cn_ComVoyage.Close();
        }
    }
}