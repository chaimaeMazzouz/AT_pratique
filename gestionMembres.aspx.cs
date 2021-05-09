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
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection cn_ComVoyage = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                Remplir_GridView();
                //cn_ComVoyage.Open();
                //SqlCommand cmd_com = new SqlCommand("select pseudo from membre where categorie ='Membre'", cn_ComVoyage);
                //DropDownListMembre.DataSource = cmd_com.ExecuteReader();
                //DropDownListMembre.DataTextField = "pseudo";
                //DropDownListMembre.DataBind();
                //DropDownListMembre.SelectedIndex = 0;
                //cn_ComVoyage.Close();

            }
        }
        void Remplir_GridView()
        {
            cn_ComVoyage.Open();
            SqlCommand cmd_rp = new SqlCommand("select pseudo,matricule,nom,prenom,service_,mail,categorie from membre where categorie ='Membre'", cn_ComVoyage);
            GridView1.DataSource = cmd_rp.ExecuteReader();
            GridView1.DataBind();
            cn_ComVoyage.Close();
            
        }

        //protected void DropDownListMembre_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //cn_ComVoyage.Open();
        //    //SqlCommand cmd_rm = new SqlCommand("select*from membre where pseudo ='@ps'", cn_ComVoyage);
        //    //cmd_rm.Parameters.AddWithValue("@ps", DropDownListMembre.SelectedValue);
        //    //SqlDataReader dr = cmd_rm.ExecuteReader();
        //    //while (dr.Read())
        //    //{
        //    //    Nom.Text = dr[3].ToString();
        //    //    Prenom.Text = dr[4].ToString();
        //    //    matricule.Text = dr[2].ToString();
        //    //    Email.Text = dr[6].ToString();
        //    //    DdlService.SelectedValue = dr[5].ToString();
        //    //}
        //    //cn_ComVoyage.Close();
        //}

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
            Prenom.Text ="";
            Nom.Text = "";
            Email.Text ="";
            matricule.Text ="";
            DdlService.SelectedIndex=0;
        }
    }
}