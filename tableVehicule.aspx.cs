using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace AT7_AT8_projet
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        SqlConnection cn_ComVoyage = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        void Remplir_GridView()
        {
            cn_ComVoyage.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select*from Vehicule", cn_ComVoyage);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            gv_Vehicule.DataSource = dt;
            gv_Vehicule.DataBind();
            cn_ComVoyage.Close();
        }
        void BindChauffeur()
        {
            DataTable dt = new DataTable();

            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand("Select Distinct  Immatricule  from Vehicule", cn_ComVoyage);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cn_ComVoyage.Close();
            ddlIdVehicule.DataSource = dt;
            ddlIdVehicule.DataTextField = "Immatricule";
            ddlIdVehicule.DataValueField = "Immatricule";
            ddlIdVehicule.DataBind();
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

        protected void ddlIdVehicule_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            cn_ComVoyage.Open();
            if (ddlIdVehicule.SelectedValue != "Tous")
            {
                SqlCommand cmd = new SqlCommand("select * from Vehicule where Immatricule =@mat", cn_ComVoyage);
                cmd.Parameters.AddWithValue("@mat", ddlIdVehicule.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from Vehicule", cn_ComVoyage);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            cn_ComVoyage.Close();
            gv_Vehicule.DataSource = dt;
            gv_Vehicule.DataBind();
        }

        protected void gv_Vehicule_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_Vehicule.EditIndex = -1;
            Remplir_GridView();
        }

        protected void gv_Vehicule_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gv_Vehicule.DataKeys[e.RowIndex].Value.ToString();
            supprimer_Chauffeur(id);
            Remplir_GridView();
        }

        protected void gv_Vehicule_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = gv_Vehicule.DataKeys[e.RowIndex].Value.ToString();
            TextBox txtMarque = (TextBox)gv_Vehicule.Rows[e.RowIndex].FindControl("TextBoxMarque");
            TextBox txtType_Vehicule = (TextBox)gv_Vehicule.Rows[e.RowIndex].FindControl("TextBoxType_Vehicule");
            TextBox txtDt = (TextBox)gv_Vehicule.Rows[e.RowIndex].FindControl("TextBoxDt_Mise_Service");
            mofifier_Chauffeur(id, txtMarque.Text, txtType_Vehicule.Text, txtDt.Text);
            gv_Vehicule.EditIndex = -1;
            Remplir_GridView();
        }

        protected void gv_Vehicule_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_Vehicule.EditIndex = e.NewEditIndex;
            Remplir_GridView();
        }
        private void mofifier_Chauffeur( string Immatricule, string Marque, string Type_Vehicule, string Dt_Mise_Service)
        {
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"update Vehicule set  Marque ='{Marque}',Type_Vehicule='{Type_Vehicule}',Dt_Mise_Service ='{Dt_Mise_Service}' where Immatricule ='{Immatricule}'", cn_ComVoyage);
            cmd.ExecuteNonQuery();
            cn_ComVoyage.Close();
        }
        private void supprimer_Chauffeur(string id)
        {
            cn_ComVoyage.Open();
            SqlCommand cmd = new SqlCommand($"delete from Vehicule where Immatricule ='{id}'", cn_ComVoyage);
            cmd.ExecuteNonQuery();
            cn_ComVoyage.Close();
        }
    }
}