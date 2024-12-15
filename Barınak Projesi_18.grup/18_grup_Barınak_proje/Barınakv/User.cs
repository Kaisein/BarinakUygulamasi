using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barınakv
{
    // User sınıfı, kullanıcı bilgilerini tutmak için oluşturulmuş bir sınıftır.
    // Bu sınıf, kullanıcıya ait ad, soyad, TC, kullanıcı adı ve şifre gibi bilgileri saklar.
    class User
    {
        // Private alanlar
        private string adSoyad;      // Kullanıcının adı ve soyadı
        private string tc;           // Kullanıcının TC numarası
        private string kullaniciAdi; // Kullanıcının kullanıcı adı
        private string sifre;        // Kullanıcının şifresi

        // AdSoyad Özelliği
        // Bu özellik, adSoyad alanının değerini almak ve değiştirmek için kullanılır.
        public string AdSoyad
        {
            get { return adSoyad; }  // adSoyad değerini döndürür
            set { adSoyad = value; } // adSoyad değerini ayarlar
        }

        // Tc Özelliği
        // Bu özellik, tc alanının değerini almak ve değiştirmek için kullanılır.
        public string Tc
        {
            get { return tc; }       // tc değerini döndürür
            set { tc = value; }      // tc değerini ayarlar
        }

        // KullaniciAdi Özelliği
        // Bu özellik, kullaniciAdi alanının değerini almak ve değiştirmek için kullanılır.
        public string KullaniciAdi
        {
            get { return kullaniciAdi; }  // kullaniciAdi değerini döndürür
            set { kullaniciAdi = value; } // kullaniciAdi değerini ayarlar
        }

        // Sifre Özelliği
        // Bu özellik, sifre alanının değerini almak ve değiştirmek için kullanılır.
        public string Sifre
        {
            get { return sifre; }    // sifre değerini döndürür
            set { sifre = value; }   // sifre değerini ayarlar
        }
    }
}

