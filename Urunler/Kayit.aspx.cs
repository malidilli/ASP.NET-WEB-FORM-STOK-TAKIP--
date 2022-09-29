using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace Urunler
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        SqlConnection con=new 
          SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Kullanıcıdb;Integrated Security=True;");
        con.Open();        
       SqlCommand cmd = new SqlCommand("Insert into Üyeler(KullanıcıAD,SİFRE,ADSoyad) values('" + tbxkullanıcı.Text +
        "','" + tbxsifre.Text + "','" + tbxadsoyad.Text + "')", con);
           cmd.ExecuteNonQuery();
           
              Response.Write("<script>alert('Kayıt olundu');</script>");
            //   Response.Write("<script>alert('kayıt olundu');</script>");
            //  Response.Redirect("Login.aspx");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}