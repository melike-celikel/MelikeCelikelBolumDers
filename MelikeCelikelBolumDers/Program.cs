using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MelikeCelikelBolumDers
{
    class Program
    {
        //Dersler ve bölümler için listler
        public static SinglyLinkedList<Ders> dersListesi;
        public static SinglyLinkedList<Bolum> bolumListesi;
        static void Main(string[] args)
        {
            dersListesi = new SinglyLinkedList<Ders>();
            bolumListesi = new SinglyLinkedList<Bolum>();

            testverisi();

            int secim;
            while(true)
            { 
                secim = menuGosterSec();
                if( secim==1)  // Ders Ekle
                {
                    dersEkle();
                }
                else if( secim==2) // Ders Sil
                {
                    dersSil();

                }
                else if (secim == 3)
                {
                    dersleriListele();
                }
                else if (secim == 4)
                {
                    bolumEkle();
                }
                else if (secim == 5)
                {
                    bolumSil();
                }
                else if (secim == 6)                 //Seçimler
                {
                    bolumGoster();
                }
                else if (secim == 7)
                {
                    bolumleriListele();
                }
                else if (secim == 8)
                {
                    bolumeDersEkle();

                }
                else if (secim == 9)
                {
                    bolumdenDersSil();
                }
                else if (secim == 10)
                {
                    dosyayaKaydet();
                }
                else if (secim == 20) // Çıkış
                {
                    break;
                }
                else 
                {
                    Console.WriteLine("Geçersiz menu seçimi!");
                }
                

            }
            
            

        }
        /// <summary>
        /// Seçim menüsü (yapılabilecek işlemler) tasarımı.
        /// </summary>
        /// <returns></returns>
        public static int menuGosterSec()
        {
            Console.WriteLine("1. Ders Ekle");
            Console.WriteLine("2. Ders Sil");
            Console.WriteLine("3. Dersleri Listele");
            Console.WriteLine("--------------------");
            Console.WriteLine("4. Bölüm Ekle");
            Console.WriteLine("5. Bölüm Sil");
            Console.WriteLine("6. Bölüm Goster");
            Console.WriteLine("7. Bölümleri Listele");
            Console.WriteLine("8. Bölüme Ders Ekle");
            Console.WriteLine("9. Bölümden Ders Sil");
            Console.WriteLine("--------------------");
            Console.WriteLine("10. Dosyaya Kaydet");
            Console.WriteLine("--------------------");
            Console.WriteLine("20. Çıkış");

            Console.WriteLine();
            Console.Write("Seçiminiz: ");
            int secim = int.Parse(Console.ReadLine());

            return secim;


        }

        public static void testverisi()
        {
            Ders ders1 = new Ders("BİL101", "Matematik", 5);
            Ders ders2 = new Ders("BİL102", "Fizik", 3);
            Ders ders3 = new Ders("BİL103", "Kimya", 4);
            Ders ders4 = new Ders("BİL104", "C# Programlama", 3);

            Ders ders5 = new Ders("END101", "Matematik", 5);
            Ders ders6 = new Ders("END102", "Fizik", 3);
            Ders ders7 = new Ders("END103", "Kimya", 4);

            Ders ders8 = new Ders("İNS101", "Matematik", 4);
            Ders ders9 = new Ders("İNS102", "Fizik", 3);
            Ders ders10 = new Ders("İNS103", "Kimya", 3);

            //Listeye veri ekleme işlemleri.

            dersListesi.Add(ders1);
            dersListesi.Add(ders2);
            dersListesi.Add(ders3);
            dersListesi.Add(ders4);

            dersListesi.Add(ders5);     
            dersListesi.Add(ders6);
            dersListesi.Add(ders7);

            dersListesi.Add(ders8);

            dersListesi.Add(ders9);
            dersListesi.Add(ders10);



            Bolum bolum1 = new Bolum("BİL", "Bilgisayar Mühendisliği");
            Bolum bolum2 = new Bolum("END", "Endüstri Mühendisliği");
            Bolum bolum3 = new Bolum("İNS", "İnşaat Mühendisliği");

            bolum1.Dersler.Add(ders1);
            bolum1.Dersler.Add(ders2);  
            bolum1.Dersler.Add(ders3);
            bolum1.Dersler.Add(ders4);

            bolum2.Dersler.Add(ders5);
            bolum2.Dersler.Add(ders6);
            bolum2.Dersler.Add(ders7);


            bolumListesi.Add(bolum1);
            bolumListesi.Add(bolum2);
            bolumListesi.Add(bolum3);
        }

        /// <summary>
        /// Ders ekleme işlemi.
        /// </summary>
        public static void dersEkle()
        {
            string DersKodu;
            string DersAdı;
            int Kredi;
            Ders ders;
            Console.WriteLine("Eklemek istediginiz Ders Bilgilerini girin");
            Console.Write("Ders Kodu : ");
            DersKodu = Console.ReadLine();
            
            Console.Write("Ders Adı  : ");
            DersAdı = Console.ReadLine();
            
            Console.Write("Kredi     : ");
            Kredi = int.Parse(Console.ReadLine());

            ders = new Ders(DersKodu, DersAdı, Kredi);

            if( !dersVar(ders) )
            {
                dersListesi.Add(ders);
                Console.WriteLine("Ders Eklendi...");
            }
            else
            {
                Console.WriteLine("Ders Kodu veya Ders Adı daha önce var");
            }

            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();

        }

        public static  bool dersVar(Ders ders)
        {
            IEnumerable<Ders> e = dersListesi.GetEnumerator();

            foreach( Ders d in e)
            {
                if( ders.DersKodu.ToLower()== d.DersKodu.ToLower() )
                {
                    return true;

                }
            }

            return false;


        }
        public static Ders dersBul(string DersKodu)
        {
            IEnumerable<Ders> e = dersListesi.GetEnumerator();
          
            foreach (Ders d in e)
            {
                if ( d.DersKodu.ToLower() == DersKodu.ToLower())
                {
                    return d;

                }
            }

            return null;


        }

        public static void dersSil()
        {
            string DersKodu;

            Console.Write("Silinecek Dersin kodunu giriniz: ");
            DersKodu = Console.ReadLine();

            Ders ders = dersBul(DersKodu);
            
            if( ders!=null)
            {
                int position = dersListesi.Find(ders);
                dersListesi.Remove(position);

                Console.WriteLine("Ders Silindi...");

            }
            else
            {
                Console.WriteLine("Ders bulunamadı!");
            }


            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();
        }
        public static void dersleriListele()
        {
            Console.WriteLine("--- Derslerin Listesi ---");
            IEnumerable<Ders> e = dersListesi.GetEnumerator();
            foreach (Ders d in e)
            {
                Console.WriteLine(d.DersKodu + " " + d.DersAdı + " " + d.Kredi);
            }

            Console.WriteLine();

            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();
        }
       
        public static void bolumEkle()
        {
            string BolumKod;
            string BolumAdı;
            Bolum bolum;

            Console.WriteLine("Eklemek istediginiz Bölüm Bilgilerini girin");

            Console.Write("Bölüm Kodu : ");
            BolumKod = Console.ReadLine();

            Console.Write("Bölüm Adı  : ");
            BolumAdı = Console.ReadLine();


            bolum = new Bolum(BolumKod, BolumAdı);

            if (!bolumVar(bolum))
            {
                bolumListesi.Add(bolum);
                Console.WriteLine("Bölüm Eklendi...");
            }
            else
            {
                Console.WriteLine("Bölüm Kodu veya Bölüm Adı daha önce var");
            }

            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
            Console.WriteLine();
        }

        public static bool bolumVar(Bolum bolum)
        {
            IEnumerable<Bolum> e = bolumListesi.GetEnumerator();

            foreach (Bolum b in e)
            {
                if (bolum.BolumKod.ToLower() == b.BolumKod.ToLower() || bolum.BolumAdı.ToLower() == b.BolumAdı.ToLower())
                {
                    return true;

                }
            }

            return false;


        }

        public static Bolum bolumBul(string BolumKod)
        {
            IEnumerable<Bolum> e = bolumListesi.GetEnumerator();

            foreach (Bolum b in e)
            {
                if (b.BolumKod.ToLower() == BolumKod.ToLower())
                {
                    return b;

                }
            }

            return null;


        }


        public static void bolumSil()
        {
            string BolumKod;

            Console.Write("Silinecek Bölümün kodunu giriniz: ");
            BolumKod = Console.ReadLine();

            Bolum bolum = bolumBul(BolumKod);

            if (bolum != null)
            {
                int position = bolumListesi.Find(bolum);
                bolumListesi.Remove(position);

                Console.WriteLine("Bölüm Silindi...");

            }
            else
            {
                Console.WriteLine("Bölüm bulunamadı!");
            }


            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();


        }


        public static void bolumGoster()
        {
            string BolumKod;

            Console.Write("Gösterilecek Bölümün kodunu giriniz: ");
            BolumKod = Console.ReadLine();

            Bolum bolum = bolumBul(BolumKod);

            if (bolum != null)
            {

                Console.WriteLine("Bölüm Kod : " + bolum.BolumKod);
                Console.WriteLine("Bölüm Adı : " + bolum.BolumAdı);

                IEnumerable<Ders> e = bolum.Dersler.GetEnumerator();
                Console.WriteLine("Bölümün Dersleri");
                foreach (Ders d in e)
                {
                    Console.WriteLine("    " + d.DersKodu + " " + d.DersAdı + " " + d.Kredi);
                }

                Console.WriteLine("-------------------------------");

            }
            else
            {
                Console.WriteLine("Bölüm bulunamadı!");
            }


            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();


        }

        public static void bolumleriListele()
        {

            Console.WriteLine("--- Bölümlerin Listesi ---");
            IEnumerable<Bolum> e = bolumListesi.GetEnumerator();
            foreach (Bolum b in e)
            {
                Console.WriteLine(b.BolumKod + " " + b.BolumAdı);

                IEnumerable<Ders> e2 = b.Dersler.GetEnumerator();
                Console.WriteLine("Bölümün Dersleri");
                foreach (Ders d in e2)
                {
                    Console.WriteLine("    "+ d.DersKodu + " " + d.DersAdı + " " + d.Kredi);
                }
                Console.WriteLine("-------------------------------");
            }

            Console.WriteLine();

            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();

        }

        public static void bolumeDersEkle()
        {

            string BolumKod;

            Console.Write("Ders Eklemek İstediğiniz Bölümün kodunu giriniz: ");
            BolumKod = Console.ReadLine();

            Bolum bolum = bolumBul(BolumKod);
            string DersKodu;
            Ders ders;
            string cevap;
            if (bolum != null)
            {
                while (true)
                {
                    Console.Write("Eklemek İstediğiniz Ders Kodunu Giriniz: ");
                    DersKodu = Console.ReadLine();
                    ders = dersBul(DersKodu);
                    if (ders != null)
                    {
                        bolum.Dersler.Add(ders);
                        Console.WriteLine("Bölüme Ders Eklendi...");
                        
                    }
                    else
                    {
                        Console.WriteLine("Ders bulunamadı");
                    }

                    Console.WriteLine("Ders Eklemeye Devam Etmek İstiyor musunuz (E/H) ?");
                    cevap = Console.ReadLine();
                    if (cevap.ToLower().Equals("h"))
                    {
                        return;
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("Bölüm bulunamadı!");
            }

            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();

        }
        public static int bolumdeDersBul(Bolum bolum, string DersKodu)
        {
            IEnumerable<Ders> e = bolum.Dersler.GetEnumerator();
            
            foreach (Ders d in e)
            {
                if (d.DersKodu.ToLower() == DersKodu.ToLower())
                {
                    int position = bolum.Dersler.Find(d);
                    return position;

                }
            }

           

            return -1;


        }

        public static void bolumdenDersSil()
        {
            string BolumKod;

            Console.Write("Ders Silmek İstediğiniz Bölümün kodunu giriniz: ");
            BolumKod = Console.ReadLine();
            string DersKodu;
            Bolum bolum = bolumBul(BolumKod);
            


            Console.WriteLine("--- Bölümdeki Derslerin Listesi ---");
            IEnumerable<Ders> e = bolum.Dersler.GetEnumerator();
            foreach (Ders d in e)
            {
                Console.WriteLine(d.DersKodu + " " + d.DersAdı + " " + d.Kredi);
            }

            Console.WriteLine();
            int position;
            string cevap;

            if (bolum != null)
            {
                while (true)
                {
                    Console.Write("Silmek İstediğiniz Ders Kodunu Giriniz: ");
                    DersKodu = Console.ReadLine();
                    position = bolumdeDersBul(bolum, DersKodu);
                    if (position != -1)
                    {
                        bolum.Dersler.Remove(position);
                        Console.WriteLine("Bölümden Ders Silindi...");

                    }
                    else
                    {
                        Console.WriteLine("Bölümde Ders bulunamadı");
                    }

                    Console.WriteLine("Bölümden Ders Silmeye Devam Etmek İstiyor musunuz (E/H) ?");
                    cevap = Console.ReadLine();
                    if (cevap.ToLower().Equals("h"))
                    {
                        return;
                    }
                    Console.WriteLine();
                }

            }
            else
            {
                Console.WriteLine("Bölüm bulunamadı!");
            }

            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();
        }
        
        
        /// <summary>
        /// text dosyaya json formatta verileri kaydettirme işlemi.
        /// </summary>
        public static void dosyayaKaydet()
        {

            string json="{\n";
            string jsonders;
            string jsonbolum;
            using(StreamWriter wr= new StreamWriter("BolumlerDersler.txt") ) //txt dosyası.
            {
                IEnumerable<Ders> e = dersListesi.GetEnumerator();
                json = json + "\"dersler\":[\n";
                foreach( Ders d in e)
                {
                    jsonders = "  {\n";
                    jsonders = jsonders + "   \"DersKodu\":" +  "\""+d.DersKodu+"\",\n";
                    jsonders = jsonders + "   \"DersAdı\":" + "\"" + d.DersAdı + "\",\n";
                    jsonders = jsonders + "   \"Kredi\":" + d.Kredi + "\n";

                    jsonders = jsonders + "  },\n";
                    json = json + jsonders;
                }
                
                json=json.Remove(json.LastIndexOf(","), 1);
                json = json + "],\n";

                

                IEnumerable<Bolum> e2 = bolumListesi.GetEnumerator();
                json = json + "\"bolumler\":[\n";
                foreach (Bolum b in e2)
                {
                    jsonbolum = "  {\n";
                    jsonbolum = jsonbolum + "   \"BolumKod\":" + "\"" + b.BolumKod + "\",\n";
                    jsonbolum = jsonbolum + "   \"BolumAdı\":" + "\"" + b.BolumAdı + "\",\n";

                    jsonbolum = jsonbolum + "   \"dersler\":[\n";

                    IEnumerable<Ders> e3 = b.Dersler.GetEnumerator();
                    foreach (Ders d in e3)
                    {
                        jsonders = "      {\n";
                        jsonders = jsonders + "       \"DersKodu\":" + "\"" + d.DersKodu + "\",\n";
                        jsonders = jsonders + "       \"DersAdı\":" + "\"" + d.DersAdı + "\",\n";
                        jsonders = jsonders + "       \"Kredi\":" + d.Kredi + "\n";

                        jsonders = jsonders + "      },\n";
                        jsonbolum = jsonbolum + jsonders;
                    }
                    if( b.Dersler.Count>0)
                    {
                        jsonbolum = jsonbolum.Remove(jsonbolum.LastIndexOf(","), 1);
                    }
                    

                    jsonbolum = jsonbolum + "    ]\n";

                    jsonbolum = jsonbolum + "  },\n";

                    json = json + jsonbolum;


                }
                json = json.Remove(json.LastIndexOf(","), 1);
                json = json + "\n]\n";

                json = json + "}";

                Console.WriteLine(json);
                wr.WriteLine(json);
            }



            Console.WriteLine("Devam etmek için bir tusa basin...");
            Console.ReadKey();
            Console.WriteLine();
            
        }



    }
}
