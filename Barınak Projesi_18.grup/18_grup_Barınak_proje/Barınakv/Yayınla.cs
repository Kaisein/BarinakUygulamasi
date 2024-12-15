using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Barınakv
{
    // AbstractYayınla sınıfından türeyen Yayınla sınıfını tanımlıyoruz.
    // Yayınla sınıfı, AbstractYayınla sınıfının soyut metodunu implement (gerçekleştir) etmek zorundadır.
    class Yayınla : AbstractYayınla
    {
        // AbstractYayınla sınıfındaki soyut metodun implementasyonu.
        // Burada, yayınla metodu çağrıldığında bir MessageBox gösterilecek.
        public override void yayınla()
        {
            // MessageBox ile bir bilgi mesajı gösteriliyor.
            // "Kayıt işlemi başarıyla gerçekleştirildi" metni ve başlık olarak "Bilgi" kullanılmakta.
            // OK butonu ve bilgi simgesi ekleniyor.
            MessageBox.Show("Kayıt işlemi başarıyla gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
