using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Barınakv
{
    public partial class frmeglence : Form
    {
        // Constructor: Form başlatıldığında çalışır
        public frmeglence()
        {
            InitializeComponent();
        }

        // Ana forma dönüş butonu (button4) için tıklama olayı
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1(); // Ana formun bir örneğini oluştur
            fr.Show();              // Ana formu göster
            this.Hide();            // Mevcut formu gizle
        }

        // SQL bağlantısı için sınıf örneği
        Sqlbaglant bgl = new Sqlbaglant();

        // Form yüklendiğinde çalışacak metod
        private void frmeglence_Load(object sender, EventArgs e)
        {
            // Eğlence verilerini DataGridView'e yükler
            DataTable dt = new DataTable();
            SqlDataAdapter br = new SqlDataAdapter("Select * From Eğlence_Tbl", bgl.baglanti());
            br.Fill(dt);
            dataGridView1.DataSource = dt;

            // ComboBox içeriğini temizle ve eğlence türlerini yükle
            cmbtext.Items.Clear();
            SqlCommand komut = new SqlCommand("Select DISTINCT EĞLENCETÜR FROM Eglencetur_Tbl", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbtext.Items.Add(dr["EĞLENCETÜR"].ToString());
            }
            dr.Close();               // DataReader'ı kapat
            bgl.baglanti().Close();   // Bağlantıyı kapat
        }

        // Randevu kaydetme butonu (btnkaydet) için tıklama olayı
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlConnection conn = bgl.baglanti(); // Bağlantıyı bir değişkene atayın
            SqlCommand komut = new SqlCommand("insert into Eğlence_Tbl (AD, SOYAD, TELEFON, SEÇİM, GÜN, SAAT) values (@p1, @p2, @p3, @p4, @p5, @p6)", conn);

            // Parametreleri atayın
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktel.Text);
            komut.Parameters.AddWithValue("@p4", cmbtext.Text);
            komut.Parameters.AddWithValue("@p5", txtgün.Text);
            komut.Parameters.AddWithValue("@p6", txtsaats.Text);

            komut.ExecuteNonQuery(); // SQL komutunu çalıştır
            conn.Close();            // Bağlantıyı kapat

            // Kullanıcıya bilgi mesajı göster
            MessageBox.Show("Randevunuz Kaydedilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            listele(); // Listeyi güncelle
        }

        // DataGridView'de bir hücreye çift tıklandığında çalışacak metod
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex; // Seçilen satırın indeksini al

            // Seçilen satırdaki bilgileri ilgili alanlara doldur
            txtıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            msktel.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            cmbtext.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtgün.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtsaats.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        // Randevu güncelleme butonu (btnguncelle) için tıklama olayı
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(
                "UPDATE Eğlence_Tbl SET AD=@p1, SOYAD=@p2, TELEFON=@p3, SEÇİM=@p4, GÜN=@p5, SAAT=@p6 WHERE ID=@p7",
                bgl.baglanti());

            // Parametreleri atayın
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktel.Text);
            komut.Parameters.AddWithValue("@p4", cmbtext.Text);
            komut.Parameters.AddWithValue("@p5", txtgün.Text);
            komut.Parameters.AddWithValue("@p6", txtsaats.Text);
            komut.Parameters.AddWithValue("@p7", txtıd.Text);

            komut.ExecuteNonQuery(); // SQL komutunu çalıştır
            bgl.baglanti().Close();  // Bağlantıyı kapat

            // Güncelleme sonrası listeyi yenile
            listele();
        }

        // Randevuları listeleyen metod
        private void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter br = new SqlDataAdapter("Select * From Eğlence_Tbl", bgl.baglanti());
            br.Fill(dt);
            dataGridView1.DataSource = dt; // DataGridView'e veriyi bağla
        }

        // Randevu silme butonu (btnsil) için tıklama olayı
        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from Eğlence_Tbl where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtıd.Text); // Silinecek ID'yi parametre olarak atayın
            komut.ExecuteNonQuery(); // SQL komutunu çalıştır
            bgl.baglanti().Close();  // Bağlantıyı kapat

            // Kullanıcıya bilgi mesajı göster
            MessageBox.Show("Randevu Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            listele(); // Listeyi güncelle
        }

        // Boş metod (şu an kullanılmıyor)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        // Boş metod (şu an kullanılmıyor)
        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }
    }
}
