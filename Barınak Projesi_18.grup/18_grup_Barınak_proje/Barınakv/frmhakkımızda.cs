using System;
using System.Windows.Forms;

namespace Barınakv
{
    public partial class frmhakkımızda : Form
    {
        // Constructor: Form başlatıldığında çalışır
        public frmhakkımızda()
        {
            InitializeComponent();
        }

        // Ana forma dönüş butonu (button1) için tıklama olayı
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1(); // Ana formu oluştur
            fr.Show();              // Ana formu göster
            this.Hide();            // Mevcut formu gizle
        }

        // İletişim formuna geçiş butonu (button2) için tıklama olayı
        private void button2_Click(object sender, EventArgs e)
        {
            frmiletişim fr = new frmiletişim(); // İletişim formunu oluştur
            fr.Show();                          // İletişim formunu göster
            this.Hide();                        // Mevcut formu gizle
        }

        // Form yüklendiğinde çalışacak olan metod (şu an boş, gerektiğinde kullanılabilir)
        private void frmhakkımızda_Load(object sender, EventArgs e)
        {
            // Buraya form yüklendiğinde yapılması gereken işlemler eklenebilir
        }
    }
}
