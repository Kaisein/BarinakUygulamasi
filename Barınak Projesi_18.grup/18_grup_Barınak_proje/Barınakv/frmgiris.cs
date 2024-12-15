using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // SQL Server bağlantısı ve komutları için gerekli kütüphane

namespace Barınakv
{
    public partial class frmgiris : Form
    {
        public frmgiris()
        {
            InitializeComponent(); // Form bileşenlerini başlatan metot
        }

        // Resim kutusuna tıklandığında çalışacak olay metodu (şu an boş)
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        // Label2'ye tıklandığında çalışacak olay metodu (şu an boş)
        private void label2_Click(object sender, EventArgs e)
        {

        }

        // SQL bağlantısı için nesne oluşturuluyor
        Sqlbaglant bgl = new Sqlbaglant();

        // Label3'e tıklandığında çalışacak olay metodu (şu an boş)
        private void label3_Click(object sender, EventArgs e)
        {

        }

        // "Giriş" butonuna tıklandığında çalışacak olay metodu
        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı ve şifre kontrolü için SQL komutu oluşturuluyor
            SqlCommand komut = new SqlCommand("Select * FROM Kayıt_Tbl where KULLANICIADI=@p1 and SİFRE=@p2", bgl.baglanti());

            // Parametrelere giriş kutularından alınan değerler atanıyor
            komut.Parameters.AddWithValue("@p1", textBox1.Text); // Kullanıcı adı
            komut.Parameters.AddWithValue("@p2", textBox2.Text); // Şifre
          

            // SQL komutunu çalıştırıp sonuçları okumak için SqlDataReader kullanılıyor
            SqlDataReader sr = komut.ExecuteReader();

            // Eğer kullanıcı adı ve şifre doğruysa yeni bir form açılır
            if (sr.Read())
            {
                Form1 fr = new Form1(); // Ana formun örneğini oluştur
                fr.Show();              // Ana formu göster
                this.Hide();            // Mevcut giriş formunu gizle
            }
            else
            {
                // Hatalı giriş yapıldığında kullanıcıya uyarı mesajı göster
                MessageBox.Show("Hatalı Giriş yaptınız.");
            }
        }

        // "Kayıt Ol" linkine tıklandığında çalışacak olay metodu
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmkayitt fr = new frmkayitt(); // Kayıt formunun örneğini oluştur
            fr.Show();                      // Kayıt formunu göster
            this.Hide();                    // Mevcut giriş formunu gizle
        }

        // Form yüklendiğinde çalışacak olay metodu (şu an boş)
        private void Frmkayıt_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
