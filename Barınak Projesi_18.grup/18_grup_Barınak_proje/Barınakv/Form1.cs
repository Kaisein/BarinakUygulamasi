using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barınakv
{
    public partial class Form1 : Form
    {
        // Constructor: Form1 ilk oluşturulduğunda çağrılır.
        public Form1()
        {
            InitializeComponent(); // Formun bileşenlerini başlatır.
        }

        // İletişim formunu açar ve bu formu gizler.
        private void button1_Click(object sender, EventArgs e)
        {
            frmiletişim fr = new frmiletişim(); // Yeni bir frmiletişim formu oluştur.
            fr.Show();                          // İletişim formunu göster.
            this.Hide();                        // Mevcut formu (Form1) gizle.
        }

        // Hakkımızda formunu açar ve bu formu gizler.
        private void button2_Click(object sender, EventArgs e)
        {
            frmhakkımızda fr = new frmhakkımızda(); // Yeni bir frmhakkımızda formu oluştur.
            fr.Show();                              // Hakkımızda formunu göster.
            this.Hide();                            // Mevcut formu (Form1) gizle.
        }

        // Sahiplenme formunu açar ve bu formu gizler.
        private void button4_Click(object sender, EventArgs e)
        {
            frmsahiplen fr = new frmsahiplen(); // Yeni bir frmsahiplen formu oluştur.
            fr.Show();                          // Sahiplenme formunu göster.
            this.Hide();                        // Mevcut formu (Form1) gizle.
        }

        // Eğlence formunu açar ve bu formu gizler.
        private void button3_Click(object sender, EventArgs e)
        {
            frmeglence fr = new frmeglence(); // Yeni bir frmeglence formu oluştur.
            fr.Show();                        // Eğlence formunu göster.
            this.Hide();                      // Mevcut formu (Form1) gizle.
        }

        // Form yüklendiğinde çalışacak olay.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Bu metod, form yüklendiğinde gerekli başlatma işlemlerini yapmak için kullanılabilir.
            // Şu an için boş bırakılmış.
        }
    }
}
