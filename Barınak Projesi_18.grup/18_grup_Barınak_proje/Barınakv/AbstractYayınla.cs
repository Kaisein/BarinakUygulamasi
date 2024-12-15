using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barınakv
{
    // AbstractYayınla adında soyut bir sınıf tanımlıyoruz. 
    // Soyut sınıflar, kendisinden türetilen sınıflar için şablon sağlar, doğrudan örneği alınamaz.
    abstract class AbstractYayınla
    {
        // Soyut bir metod tanımlıyoruz. Bu metod, AbstractYayınla sınıfından türeyen sınıflarda uygulanmak zorundadır.
        // Metodun içeriği burada belirtilmemiştir, sadece bir şablon olarak belirlenmiştir.
        // Sınıfın türeyen sınıflarında bu metodun işlevi yazılacaktır.
        abstract public void yayınla();
    }
}

