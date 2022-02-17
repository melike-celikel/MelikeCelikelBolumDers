using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelikeCelikelBolumDers
{
    /// <summary>
    /// Bölümlerin kodunun adının tutulduğu;Derslere ait SinglyLinkedListin olduğu sınıf.
    /// </summary>
    public class Bolum
    {
        public string BolumKod { get; set; }
        public string BolumAdı { get; set; }
        public SinglyLinkedList<Ders> Dersler { get; set; }

        public Bolum()
        {
            this.Dersler = new SinglyLinkedList<Ders>();
        }
        public Bolum( string BolumKod, string BolumAdı)
        {
            this.BolumKod = BolumKod;
            this.BolumAdı = BolumAdı;

            this.Dersler = new SinglyLinkedList<Ders>();
        }
    }
}
