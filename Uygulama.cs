using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimSistemiUygulamasi
{
    //kullanıcı etkileşimi
    internal class Uygulama
    {
        Okul G065Okulu = new Okul();
       
        public void Calistir()
        {
            Menu();
            while (true)
            {
 
                string secim = AracGerecler.MenuSecimAl("Yapmak istediginiz islemi seçiniz: ").ToLower();
                switch (secim)
                {
                    case "1":
                        G065Okulu.OgrenciListele();
                        break;
                    case "2":
                        G065Okulu.SubeyeGoreListele();
                        break;
                    case "3":
                        G065Okulu.CinsiyeteGoreListele();
                        break;
                    case "4":
                        G065Okulu.DogumTarihineGoreListele();
                        break;
                    case "5":
                        G065Okulu.AdreseGöreListele();
                        break;
                    case "6":
                        G065Okulu.NotaGoreListele();
                        break;
                    case "7":
                        G065Okulu.KitabaGoreListele();
                        break;
                    case "8":
                        G065Okulu.Top5eGoreListele();
                        break;
                    case "9":
                        G065Okulu.Worst3eGoreListele();
                        break;
                    case "10":
                        G065Okulu.SubedeTop5eGoreListele();
                        break;
                    case "11":
                        G065Okulu.SubedeWorst3eGoreListele();
                        break;
                    case "12":
                        G065Okulu.OgrenciNotOrtalamasiGoster();
                        break;
                    case "13":
                        G065Okulu.SubeninNotOrtalamasi();
                        break;
                    case "14":
                        G065Okulu.OkuduguSonKitabıGetir();
                        break;
                    case "15":
                        OgrenciEkle();
                        break;
                    case "16":
                        OgrenciGuncelle();
                        break;
                    case "17":
                        OgrenciSil();
                        break;
                    case "18":
                        G065Okulu.AdresGir();
                        break;
                    case "19":
                        G065Okulu.KitapGir();
                        break;
                    case "20":
                        G065Okulu.NotGir();
                        break;
                    case "liste":
                        Menu();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                        break;
                    case "çıkış":
                        Environment.Exit(0);
                        break;
                    case "cikis":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
        public void Menu()
        {
            Console.WriteLine("------  Okul Yönetim Uygulamasi  ------");
            Console.WriteLine("1 - Bütün öğrencileri listele");
            Console.WriteLine("2 - Şubeye göre öğrencileri listele");
            Console.WriteLine("3 - Cinsiyetine göre öğrencileri listele");
            Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine("5 - İllere göre sıralayarak öğrencileri listele");
            Console.WriteLine("6 - Öğrencinin tüm notlarını listele");
            Console.WriteLine("7 - Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("8 - Okuldaki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("9 - Okuldaki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("10 - Şubedeki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("11 - Şubedeki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("12 - Öğrencinin not ortalamasını gör");
            Console.WriteLine("13 - Şubenin not ortalamasını gör");
            Console.WriteLine("14 - Öğrencinin okuduğu son kitabı gör");
            Console.WriteLine("15 - Öğrenci ekle");
            Console.WriteLine("16 - Öğrenci güncelle");
            Console.WriteLine("17 - Öğrenci sil");
            Console.WriteLine("18 - Öğrencinin adresini gir");
            Console.WriteLine("19 - Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("20 - Öğrencinin notunu gir");
            Console.WriteLine();
            Console.WriteLine("çıkış yapmak için \"çıkış\" yazıp \"enter\"a basın.");


        }
        public void OgrenciEkle()
        {
            //ekrandan bilgiler alınacak..
            G065Okulu.OgrenciEkleme();
            //G065Okulu.OgrenciEkleme("", "", SUBE.A, new DateTime(2011, 12, 11), 1, CINSIYET.Empty);
        }
        public void NotEkleme()
        {
            Console.WriteLine("20 - Not Gir----------------------------------------------------------");
            Console.Write("Ögrencinin numarasi: ");
            int no = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Ögrencinin Adı Soyadı: ");
            Console.WriteLine("Ögrencinin Subesi: ");
            Console.WriteLine();
            Console.Write("Not eklemek istediğiniz ders: ");
            string ders = Console.ReadLine();

            Console.Write("Eklemek istediginiz not adedi: ");
            int adet = int.Parse(Console.ReadLine());
            for (int i = 0; i < adet; i++)
            {
                Console.Write(i + 1 + ". Notu girin: ");
                float not = float.Parse(Console.ReadLine());
                //G065Okulu.NotEkleme(no, ders, not);
            }

            Console.WriteLine("Bilgiler sisteme girilmistir. ");
            Console.WriteLine();



        }
        public void OgrenciGuncelle()
        {
            G065Okulu.OgrenciGuncelleme();
        }
        public void OgrenciSil() 
        {
            G065Okulu.OgrenciSilme();
        }
        

    }
}
