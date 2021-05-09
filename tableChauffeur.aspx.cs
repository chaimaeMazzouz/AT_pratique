using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace AT7_AT8_projet
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        SqlConnection cn_ComVoyage = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
        void Remplir_GridView()
        {
            cn_ComVoyage.Open();
            SqlCommand cmd_rp = new SqlCommand("select*from chauffeur", cn_ComVoyage);
            gv_Chauffeur.DataSource = cmd_rp.ExecuteReader();
            gv_Chauffeur.DataBind();
            cn_ComVoyage.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Remplir_GridView();

        }

        protected void gv_Chauffeur_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gv_Chauffeur_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gv_Chauffeur_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}