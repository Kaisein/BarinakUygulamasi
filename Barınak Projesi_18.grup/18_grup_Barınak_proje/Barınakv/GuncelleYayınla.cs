using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barınakv
{
    // AbstractYayınla sınıfından türeyen GuncelleYayınla sınıfını tanımlıyoruz.
    // GuncelleYayınla sınıfı, AbstractYayınla sınıfındaki soyut metod olan yayınla'yı implement etmek zorundadır.
    class GuncelleYayınla : AbstractYayınla
    {
        // AbstractYayınla sınıfındaki soyut metodun implementasyonu.
        // Bu metod çağrıldığında bir MessageBox gösterilecek.
        public override void yayınla()
        {
            // MessageBox ile bir bilgi mesajı gösteriliyor.
            // "Güncelleme işlemi başarıyla gerçekleştirildi" metni ve başlık olarak "Bilgi" kullanılmakta.
            // OK butonu ve bilgi simgesi ekleniyor.
            MessageBox.Show("Güncelleme işlemi başarıyla gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
