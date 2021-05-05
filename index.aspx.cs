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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void BtnAuthentifier_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn_ComVoyage = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString))
            {
                cn_ComVoyage.Open();
                string Qr = "select count(1) from membre where pseudo=@pseudo and pass=@pass";
                SqlCommand cmd = new SqlCommand(Qr, cn_ComVoyage);
                cmd.Parameters.AddWithValue("@pseudo", Pseudo.Text);
                cmd.Parameters.AddWithValue("@pass", password.Text);

                int count = (int)cmd.ExecuteScalar();
                if (count == 1)
                {
                    
                    string Qr_sel = "select * from membre where pseudo=@pseudo and pass=@pass";
                    SqlCommand cmd_sel = new SqlCommand(Qr_sel, cn_ComVoyage);
                    cmd_sel.Parameters.AddWithValue("@pseudo", Pseudo.Text);
                    cmd_sel.Parameters.AddWithValue("@pass", password.Text);
                    SqlDataReader dr = cmd_sel.ExecuteReader();
                    while(dr.Read())
                    {
                        Session["pseudo"] = dr[0].ToString();
                        Session["matricule"] = dr[2].ToString();
                        Session["nom"] = dr[3].ToString();
                        Session["prenom"] = dr[4].ToString();
                        Session["service"] = dr[5].ToString();
                        Session["mail"] = dr[6].ToString();
                        Session["categ"] = dr[7].ToString();
                    }
                    
                        Response.Redirect("membre.aspx");
                   
                  
                   
                }
                else
                {
                    Response.Write("<script>alert('Ce membre n'exsist pas')</script>");
                }
            }
    }
}
    }