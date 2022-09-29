using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Urunler
{   
    public partial class Default : System.Web.UI.Page
    {
        Urunler_VTEntities baglanti = new Urunler_VTEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnEkle_Click(object sender, EventArgs e)   {
            Urunler urunEkle = new Urunler();

            urunEkle.UrunKodu = int.Parse(tbxUrunKodu.Text);
            urunEkle.UrunAdi = (tbxUrunAdi.Text);
            urunEkle.StokMiktari = int.Parse(tbxStokMiktari.Text);
            urunEkle.BirimFiyat = int.Parse(tbxBirimFiyatı.Text);
            try
            {
                baglanti.Urunler.Add(urunEkle);
                baglanti.SaveChanges();
                   Response.Write("<script>alert('kayıt başarıyla eklendi');</script>");      
            }
            catch (Exception)
            {      
                Response.Write("<script>alert('kayıt kayıt eklenemedi');</script>");
            }
        }

        protected void btnListele_Click(object sender, EventArgs e)
        {
            baglanti.Urunler.Load();
            GridView1.DataSource = baglanti.Urunler.Local;  //baglantıyı kurma
            GridView1.DataBind();   

        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            int urunkodu = int.Parse(tbxUrunKodu.Text);
            var     sorgu = (from kayit in baglanti.Urunler     //veritabanında kayıt varmı
                         where kayit.UrunKodu == urunkodu
                         select kayit).ToList(); // listeleme indis almak için

            if (sorgu.Count == 1)
            {
                baglanti.Urunler.Remove(sorgu[0]);    //listedeki 0.indisi silme
                baglanti.SaveChanges();           //kayıt etme
                
                Response.Write("<script>alert('kayıt silindi');</script>");
               
            }
            else
            {
             
                Response.Write("<script>alert('kayıt bulunamadı');</script>");
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            int urunkodu  = int.Parse(tbxUrunKodu.Text);
            var sorgu = (from kayit in baglanti.Urunler 
                         where kayit.UrunKodu == urunkodu 
                         select kayit).ToList();

            if (sorgu.Count == 1)
            {
                sorgu[0].UrunAdi =tbxUrunAdi.Text;
                sorgu[0].BirimFiyat = int.Parse(tbxBirimFiyatı.Text);
                sorgu[0].StokMiktari =int.Parse (tbxStokMiktari.Text);
                baglanti.SaveChanges();
                Response.Write("<script>alert('ürünler güncellendi');</script>");
            }
            else {
                Response.Write("<script>alert('kayıt bulunamadı');</script>");
            }

        }
    }
}