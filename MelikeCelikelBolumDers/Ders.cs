using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelikeCelikelBolumDers
{
    /// <summary>
    /// Derslerin kodunun adının ve kredilerinin tutulduğu bir sınıf.
    /// </summary>
    public class Ders
    {
        public string DersKodu { get; set; }
        public string DersAdı { get; set; }
        public int Kredi { get; set; }

        public Ders()
        {

        }

        public Ders(string DersKodu, string DersAdı, int Kredi)
        {
            this.DersKodu = DersKodu;
            this.DersAdı = DersAdı;
            this.Kredi = Kredi;
        }
    }
}
