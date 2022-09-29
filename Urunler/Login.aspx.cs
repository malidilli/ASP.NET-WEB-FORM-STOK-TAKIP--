using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace Urunler
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kayit.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Kullanıcıdb;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From Üyeler where  KullanıcıAD='" + txtGiris.Text + "' and  SİFRE ='" + txtSifre.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Write("<script>alert('hatalı giriş yaptınız');</script>");
                
            }

        }
    }
}