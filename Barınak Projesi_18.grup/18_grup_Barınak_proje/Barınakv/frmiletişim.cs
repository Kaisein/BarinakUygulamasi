using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Barınakv
{
    public partial class frmiletişim : Form
    {
        // Constructor: Form başlatıldığında çalışır
        public frmiletişim()
        {
            InitializeComponent();
        }

        // Ana forma dönüş butonu (button2) için tıklama olayı
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1(); // Ana formu oluştur
            fr.Show();              // Ana formu göster
            this.Hide();            // Mevcut formu gizle
        }

        // Form yüklendiğinde çalışacak olan metod (şu an boş, gerektiğinde kullanılabilir)
        private void frmiletişim_Load(object sender, EventArgs e)
        {
            // Buraya form yüklendiğinde yapılması gereken işlemler eklenebilir
        }

        // SQL bağlantısı için kullanılan nesne
        Sqlbaglant bgl = new Sqlbaglant();

        // Mesaj gönderme butonu (button1) için tıklama olayı
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = bgl.baglanti(); // SQL bağlantısını başlat

            // SQL komutu: Mesaj_Tbl tablosuna mesaj ekle
            SqlCommand komut = new SqlCommand("INSERT INTO Mesaj_Tbl (Mesaj) VALUES (@p1)", conn);
            komut.Parameters.AddWithValue("@p1", richTextBox1.Text); // Parametre olarak mesajı ekle

            komut.ExecuteNonQuery(); // SQL komutunu çalıştır
            conn.Close();            // Bağlantıyı kapat

            // Kullanıcıya mesaj gönderildiğini bildiren uyarı
            MessageBox.Show("Mesaj gönderildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Mesaj gönderildikten sonra metin kutusunu temizle
            richTextBox1.Clear();
        }
    }
}
