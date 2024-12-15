using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Barınakv
{
    public partial class frmsahiplen : Form
    {
        // Constructor: Form başlatıldığında çalışır
        public frmsahiplen()
        {
            InitializeComponent();
        }

        // SQL bağlantısı için kullanılan nesne
        Sqlbaglant bgl = new Sqlbaglant();

        // Form yüklendiğinde çalışacak olan metod
        private void frmsahiplen_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false; // textBox1'i gizle

            // Cinsiyet ve Cins ComboBox'larını temizle ve doldur
            cmbcins.Items.Clear();
            SqlCommand komut = new SqlCommand("SELECT DISTINCT CİNS FROM Cins_Tbl", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbcins.Items.Add(dr["CİNS"].ToString()); // Cinsiyet değerlerini ComboBox'a ekle
            }
            dr.Close();
            bgl.baglanti().Close();

            cmbcinsiyet.Items.Clear();
            SqlCommand komuts = new SqlCommand("SELECT DISTINCT CİNSİYET FROM Cins_Tbl", bgl.baglanti());
            SqlDataReader drr = komuts.ExecuteReader();
            while (drr.Read())
            {
                cmbcinsiyet.Items.Add(drr["CİNSİYET"].ToString()); // Cinsiyet değerlerini ComboBox'a ekle
            }
            drr.Close();
            bgl.baglanti().Close();

            listele(); // DataGridView'i verilerle doldur
        }

        // DataGridView'e verileri yükleyen metod
        private void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter br = new SqlDataAdapter("Select* From Sahiplen_Tbl", bgl.baglanti());
            br.Fill(dt);
            dataGridView1.DataSource = dt; // DataGridView'e verileri ata
        }

        // Yeni bir sahiplenme talebi ekleme butonu (button1) için tıklama olayı
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = bgl.baglanti(); // SQL bağlantısını başlat
            SqlCommand komut = new SqlCommand("insert into Sahiplen_Tbl(AD,SOYAD,TELEFON,CİNS,CİNSİYET,ADRES) values (@p1,@p2,@p3,@p4,@p5,@p6)", conn);

            // Parametreleri ekle
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktel.Text);
            komut.Parameters.AddWithValue("@p4", cmbcins.Text);
            komut.Parameters.AddWithValue("@p5", cmbcinsiyet.Text);
            komut.Parameters.AddWithValue("@p6", txtadres.Text);

            komut.ExecuteNonQuery(); // SQL komutunu çalıştır
            conn.Close(); // Bağlantıyı kapat

            // Bir yayınlama işlemi gerçekleştir (Yayınla sınıfı örneği üzerinden)
            Yayınla ynl = new Yayınla();
            ynl.yayınla();

            listele(); // DataGridView'i güncelle
        }

        // DataGridView hücresine çift tıklandığında çalışacak olan metod
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex; // Seçilen hücrenin satır indexini al

            // Seçilen satırdaki verileri ilgili alanlara doldur
            textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            msktel.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            cmbcins.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            cmbcinsiyet.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtadres.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        // Seçili kaydı silen buton (button5) için tıklama olayı
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Delete from Sahiplen_Tbl where AD=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtad.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Talep Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Seçili kaydı güncelleyen buton (button6) için tıklama olayı
        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(
                "UPDATE Sahiplen_Tbl SET AD=@p1, SOYAD=@p2, TELEFON=@p3, CİNS=@p4, CİNSİYET=@p5, ADRES=@p6 WHERE ID=@p7",
                bgl.baglanti()
            );

            // Güncelleme için parametreleri ekle
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktel.Text);
            komut.Parameters.AddWithValue("@p4", cmbcins.Text);
            komut.Parameters.AddWithValue("@p5", cmbcinsiyet.Text);
            komut.Parameters.AddWithValue("@p6", txtadres.Text);
            komut.Parameters.AddWithValue("@p7", textBox1.Text); // Güncellenecek kaydın ID'si

            komut.ExecuteNonQuery(); // Komutu çalıştır
            bgl.baglanti().Close(); // Bağlantıyı kapat

            MessageBox.Show("Kayıt Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele(); // DataGridView'i güncelle
        }

        // Ana forma dönüş butonu (button2) için tıklama olayı
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1(); // Ana formu oluştur
            fr.Show(); // Ana formu göster
            this.Hide(); // Mevcut formu gizle
        }
    }
}
