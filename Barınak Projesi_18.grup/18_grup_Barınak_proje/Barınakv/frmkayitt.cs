using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // SQL Server bağlantısı ve komutlarını kullanmak için gerekli kütüphane

namespace Barınakv
{
    public partial class frmkayitt : Form
    {
        public frmkayitt()
        {
            InitializeComponent(); // Form bileşenlerini başlatan metot
        }

        // SQL bağlantısını temsil eden bir nesne oluşturuluyor
        Sqlbaglant bgl = new Sqlbaglant();

        // Form yüklendiğinde çalışacak olay metodu (şu an boş)
        private void frmgiris_Load(object sender, EventArgs e)
        {

        }

        // "Kullanıcı Oluştur" butonuna tıklandığında çalışacak olay metodu
        private void button1_Click(object sender, EventArgs e)
        {
            // Yeni bir kullanıcı nesnesi oluşturuluyor
            User newUser = new User();
            newUser.AdSoyad = txtad.Text;      // AdSoyad alanına, ilgili text kutusundan değer atanıyor
            newUser.Tc = maskedTextBox1.Text;           // Tc alanına, ilgili text kutusundan değer atanıyor
            newUser.KullaniciAdi = txtkulla.Text; // Kullanıcı adı alanına, ilgili text kutusundan değer atanıyor
            newUser.Sifre = txtsifre.Text;     // Şifre alanına, ilgili text kutusundan değer atanıyor

            if (newUser.Tc.Length >= 11 && !newUser.AdSoyad.Equals("") || !newUser.KullaniciAdi.Equals("") || !newUser.Sifre.Equals("")) 
            
            {
                // SQL komutu oluşturuluyor ve bağlantı açılıyor
                SqlCommand komut = new SqlCommand("insert into Kayıt_Tbl(İSİMSOYİSİM,TC,KULLANICIADI,SİFRE) values (@p1,@p2,@p3,@p4)", bgl.baglanti());

                // Parametrelere ilgili değerler atanıyor
                komut.Parameters.AddWithValue("@p1", newUser.AdSoyad);
                komut.Parameters.AddWithValue("@p2", newUser.Tc);
                komut.Parameters.AddWithValue("@p3", newUser.KullaniciAdi);
                komut.Parameters.AddWithValue("@p4", newUser.Sifre);
                // SQL komutu çalıştırılıyor (veritabanına yeni kayıt ekleniyor)
                komut.ExecuteNonQuery();

                // Veritabanı bağlantısı kapatılıyor
                bgl.baglanti().Close();

                // Kullanıcıya bilgi mesajı gösteriliyor
                MessageBox.Show("Kullanıcı Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Lütfen bilgilerinizi kontrol edin!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        // Label3 tıklandığında çalışacak olay metodu (şu an boş)
        private void label3_Click(object sender, EventArgs e)
        {

        }

        // İkinci TextBox içeriği değiştiğinde çalışacak olay metodu (şu an boş)
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmgiris fr = new frmgiris();
            fr.Show();
            this.Hide();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
