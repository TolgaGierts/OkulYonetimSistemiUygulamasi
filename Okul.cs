using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimSistemiUygulamasi
{
    //verinin yönetimi için metotlar
    internal class Okul
    {
        public List<Ogrenci> ogrenciler = new List<Ogrenci>();

        public void OgrenciEkleme()
        {
            Console.WriteLine("15-Öğrenci Ekle -----------------------------------------------------");
            int no = AracGerecler.SayiAl("Ögrencinin numarası: ");

            string ad = AracGerecler.StringAl("Ögrencinin adı: ");

            string soyad = AracGerecler.StringAl("Ogrencinin soyadı: ");

            DateTime dogumTarihi = AracGerecler.DogumTarihiAl("Ögrencinin dogum tarihi(gg/aa/yyyy): ");

            CINSIYET cns = AracGerecler.CinsiyetSec("Ögrencinin cinsiyeti(K / E): ");

            SUBE sb = AracGerecler.SubeSec("Ögrencinin subesi (A/B/C): ");

            foreach (Ogrenci item in ogrenciler)
            {
                if (item.No == no)
                {
                    int yeniNo = EnDusukNo(ogrenciler);
                    Console.WriteLine();
                    Console.WriteLine($"Sistemde {no} numaralı öğrenci olduğu için verdiğiniz öğrenci no {yeniNo} olarak değiştirildi.");
                    no = yeniNo;
                }
            }
            this.ogrenciler.Add(new Ogrenci(no, ad, soyad, dogumTarihi, cns, sb));

            Console.WriteLine();
            Console.WriteLine($"{no} numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.");
        }

        public void OgrenciSilme()
        {
            Console.WriteLine("17-Ögrenci sil ----------------------------------------------------------------");

            bool sonuc = true;
            while (sonuc)
            {
                Console.WriteLine();
                int numara = AracGerecler.SayiAl("Ögrencinin numarası: ");

                Ogrenci a = ogrenciler.FirstOrDefault(o => o.No == numara);
                if (a == null)
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    continue;
                }

                Console.WriteLine($"Ögrencinin Adı Soyadı: {a.Ad} {a.Soyad}");
                Console.WriteLine($"Ögrencinin Subesi: {a.Sube}");
                Console.WriteLine();
                Console.Write("Ögrenciyi silmek istediginize emin misiniz(E/ H): ");
                string secim = Console.ReadLine().ToLower();
                if (secim == "e")
                {
                    ogrenciler.Remove(a);
                    Console.WriteLine("Ögrenci basarılı bir sekilde silindi.");
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                    break;
                }
            }
        }

        public void OgrenciGuncelleme()
        {
            Console.WriteLine("16-Ögrenci Güncelle -----------------------------------------------------------");

            bool sonuc = true;
            while (sonuc)
            {
                Console.WriteLine();
                int numara = AracGerecler.SayiAl("Ögrencinin numarası: ");

                Ogrenci a = ogrenciler.FirstOrDefault(o => o.No == numara);
                if (a == null)
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    continue;
                }

                string ad = AracGerecler.StringAl("Ögrencinin adı: ", a.Ad);

                string soyad = AracGerecler.StringAl("Ögrencinin soyadı: ", a.Soyad);

                DateTime dogumTarihi = AracGerecler.DogumTarihiAl(a.DogumTarihi);

                CINSIYET cns = AracGerecler.CinsiyetSec("Ögrencinin cinsiyeti(K / E): ", a.Cinsiyet);

                SUBE sb = AracGerecler.SubeSec("Ögrencinin subesi (A/B/C): ", a.Sube);

                Console.WriteLine();
                Console.WriteLine("Ogrenci güncellendi.");

                a.Ad = ad;
                a.Soyad = soyad;
                a.DogumTarihi = dogumTarihi;
                a.Cinsiyet = cns;
                a.Sube = sb;

                break;
            }
        }

        public void AdresGir()
        {
            Console.WriteLine("18-Ögrencinin Adresini Gir ------------------------------------------");
            bool sonuc = true;
            while (sonuc)
            {
                Console.WriteLine();
                int numara = AracGerecler.SayiAl("Ögrencinin numarası: ");

                Ogrenci a = ogrenciler.FirstOrDefault(o => o.No == numara);
                if (a == null)
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    continue;
                }

                Console.WriteLine($"Ögrencinin Adı Soyadı: {a.Ad} {a.Soyad}");
                Console.WriteLine($"Ögrencinin Subesi: {a.Sube}");
                Console.WriteLine();
                string il = AracGerecler.AdresAl("Il: ");
                string ilce = AracGerecler.AdresAl("Ilçe: ");
                string mahalle = AracGerecler.AdresAl("Mahalle: ");

                a.Adres.Il = il;
                a.Adres.Ilce = ilce;
                a.Adres.Mahalle = mahalle;
                Console.WriteLine();
                Console.WriteLine("Bilgiler sisteme girilmistir.");

                break;
            }
        }

        public void KitapGir()
        {
            Console.WriteLine("19-Ögrencinin okudugu kitabı gir ------------------------------------");
            bool sonuc = true;
            while (sonuc)
            {
                Console.WriteLine();
                int numara = AracGerecler.SayiAl("Ögrencinin numarası: ");

                Ogrenci a = ogrenciler.FirstOrDefault(o => o.No == numara);
                if (a == null)
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    continue;
                }

                Console.WriteLine($"Ögrencinin Adı Soyadı: {a.Ad} {a.Soyad}");
                Console.WriteLine($"Ögrencinin Subesi: {a.Sube}");
                Console.WriteLine();
                string kitap = AracGerecler.KitapIsmiAl("Eklenecek Kitabin Adı: ");
                a.Kitaplar.Add(kitap);
                Console.WriteLine("Bilgiler sisteme girilmistir.");
                break;
            }

        }

        public void NotGir()
        {
            Console.WriteLine("20-Not Gir ----------------------------------------------------------");
            bool sonuc = true;
            while (sonuc)
            {
                Console.WriteLine();
                int numara = AracGerecler.SayiAl("Ögrencinin numarası: ");

                Ogrenci a = ogrenciler.FirstOrDefault(o => o.No == numara);

                if (a == null)
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    continue;
                }

                Console.WriteLine($"Ögrencinin Adı Soyadı: {a.Ad} {a.Soyad}");
                Console.WriteLine($"Ögrencinin Subesi: {a.Sube}");
                Console.WriteLine();

                Console.WriteLine("Fen icin 1");
                Console.WriteLine("Sosyal icin 2");
                Console.WriteLine("Matematik icin 3");
                Console.WriteLine("Turkce icin 4");
                DERSLER secim = AracGerecler.DersSec("Not eklemek istediğiniz dersi seciniz: ");
                int adet = AracGerecler.SayiAl("Eklemek istediginiz not adeti: ");
                for (int i = 1; i <= adet; i++)
                {
                    int not = AracGerecler.SayiAl($"{i}. notu girin: ");
                    DersNotu dersNotu = new DersNotu(secim, not);
                    a.Notlar.Add(dersNotu);
                }

                Console.WriteLine("Bilgiler sisteme girilmistir.");
                break;
            }
        }

        public static int EnDusukNo(List<Ogrenci> ogrenciler)
        {
            int numara = 1;
            while (ogrenciler.Any(a => a.No == numara))
            {
                numara++;
            }
            return numara;
        }

        public void OgrenciListele()
        {
            Console.WriteLine("1-Bütün Ögrencileri Listele --------------------------------------------------");
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("-------------------------------------------------------------------------------");
            foreach (Ogrenci item in ogrenciler)
            {
                Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + $"{item.Ad} {item.Soyad}".PadRight(25) + item.NotOrtalamasıHesapla().ToString("#.##").PadRight(15) + item.ToplamOkunanKitapSayisi.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
        }

        public void AdreseGöreListele()
        {
            Console.WriteLine("5-Illere Göre Ögrencileri Listele --------------------------------------------");
            Console.WriteLine();
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }

            var siraliOgrenciler = ogrenciler.OrderBy(o => o.Adresler.FirstOrDefault()?.Il);

            Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Sehir".PadRight(15) + "Semt");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (Ogrenci item in siraliOgrenciler)
            {
                var siraliAdresler = item.Adresler.OrderBy(a => a.Il);

                foreach (Adres adres in siraliAdresler)
                {
                    Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + $"{item.Ad} {item.Soyad}".PadRight(25) + adres.Il.PadRight(15) + adres.Ilce);
                }
            }
        }


        public void SubeyeGoreListele()
        {
            Console.WriteLine("2-Subeye Göre Ögrencileri Listele --------------------------------------------");
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }

            SUBE sube = AracGerecler.SubeSec("Listelemek istediğiniz şubeyi girin(A/B/C): ");
            Console.WriteLine();
            List<Ogrenci> yeniListe = ogrenciler.Where(o => o.Sube == sube).ToList();
            Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("-------------------------------------------------------------------------------");


            if (yeniListe.Count >= 1)
            {
                foreach (Ogrenci item in yeniListe)
                {

                    Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + $"{item.Ad} {item.Soyad}".PadRight(25) + item.NotOrtalamasıHesapla().ToString().PadRight(15) + item.ToplamOkunanKitapSayisi);

                }
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
            }
            else
            {
                Console.WriteLine("Listelenecek öğrenci yok.");
            }
        }

        public void CinsiyeteGoreListele()
        {
            Console.WriteLine("3-Cinsiyete Göre Öğrencileri Listele -----------------------------------------");
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }
            CINSIYET cinsiyet = AracGerecler.CinsiyetSec("Listelemek istediğiniz cinsiyeti girin (K/E): ");
            Console.WriteLine();
            List<Ogrenci> yeniListe = ogrenciler.Where(o => o.Cinsiyet == cinsiyet).ToList();
            Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("-------------------------------------------------------------------------------");


            if (yeniListe.Count >= 1)
            {
                foreach (Ogrenci item in yeniListe)
                {

                    Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + $"{item.Ad} {item.Soyad}".PadRight(25) + item.NotOrtalamasıHesapla().ToString().PadRight(15) + item.ToplamOkunanKitapSayisi);

                }
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
            }
            else
            {
                Console.WriteLine("Listelenecek öğrenci yok.");
            }

        }

        public void DogumTarihineGoreListele()
        {
            Console.WriteLine("4-Dogum Tarihine Göre Ögrencileri Listele ------------------------------------");
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }
            while (true)
            {
                DateTime dTarihi = AracGerecler.DogumTarihiAl("Hangi tarihten sonraki ögrencileri listelemek istersiniz(gg/aa/yyyy): ");
                Console.WriteLine();
                List<Ogrenci> yeniListe = ogrenciler.Where(o => o.DogumTarihi >= dTarihi).ToList();


                if (yeniListe.Count >= 1)
                {
                    Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    foreach (Ogrenci item in yeniListe)
                    {

                        Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + $"{item.Ad} {item.Soyad}".PadRight(25) + item.NotOrtalamasıHesapla().ToString().PadRight(15) + item.ToplamOkunanKitapSayisi);

                    }
                    Console.WriteLine();
                    Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                    break;
                }
                else
                {
                    Console.WriteLine("Listelenecek öğrenci yok.");
                    break;
                }
            }
        }

        public void NotaGoreListele()
        {
            Console.WriteLine("6-Ögrencinin notlarını görüntüle ---------------------------------------------");
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                return;
            }
            while (true)
            {
                int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");

                Ogrenci o = ogrenciler.FirstOrDefault(o => o.No == no);
                if (o != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ögrencinin Adı Soyadı: {o.Ad} {o.Soyad}");
                    Console.WriteLine($"Ögrencinin Subesi: {o.Sube}");
                    Console.WriteLine();
                    Console.WriteLine("Dersin Adi".PadRight(15) + "Notu");
                    Console.WriteLine("--------------------");
                    foreach (DersNotu dersnotu in o.Notlar)
                    {
                        Console.WriteLine($"{dersnotu.DersAdi.ToString().PadRight(15)} {dersnotu.Not}");
                    }


                    Console.WriteLine();
                    Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                }
            }
        }

        public void KitabaGoreListele()
        {
            Console.WriteLine("7-Ögrencinin okudugu kitapları listele ---------------------------------------");
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }
            while (true)
            {
                int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
                Ogrenci o = ogrenciler.FirstOrDefault(o => o.No == no);
                if (o != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ögrencinin Adı Soyadı: {o.Ad} {o.Soyad}");
                    Console.WriteLine($"Ögrencinin Subesi: {o.Sube}");
                    Console.WriteLine();
                    Console.WriteLine("Okudugu Kitaplar");
                    Console.WriteLine("-----------------");


                    foreach (string kitap in o.Kitaplar)
                    {
                        Console.WriteLine(kitap);

                    }


                    Console.WriteLine();
                    Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                    return;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                }

            }
        }

        public void Top5eGoreListele()
        {

            Console.WriteLine("8-Okuldaki en basarılı 5 ögrenciyi listele -----------------------------------");
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("-------------------------------------------------------------------------------");
            List<Ogrenci> yeniListe = ogrenciler.OrderByDescending(o => o.NotOrtalamasıHesapla()).Take(5).ToList();
            if (ogrenciler.Count >= 1)
            {
                foreach (Ogrenci item in yeniListe)
                {

                    Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + $"{item.Ad} {item.Soyad}".PadRight(25) + item.NotOrtalamasıHesapla().ToString("#.##").PadRight(15) + item.ToplamOkunanKitapSayisi);

                }
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
            }

        }

        public void Worst3eGoreListele()
        {
            Console.WriteLine("9-Okuldaki en basarısız 3 ögrenciyi listele ----------------------------------");

            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("-------------------------------------------------------------------------------");
            List<Ogrenci> yeniListe = ogrenciler.OrderBy(o => o.NotOrtalamasıHesapla()).Take(3).ToList();

            foreach (Ogrenci item in yeniListe)
            {

                Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + $"{item.Ad} {item.Soyad}".PadRight(25) + item.NotOrtalamasıHesapla().ToString("#.##").PadRight(15) + item.ToplamOkunanKitapSayisi);

            }
            Console.WriteLine();
            Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");

        }


        public void SubedeTop5eGoreListele()
        {
            Console.WriteLine("10-Subedeki en basarılı 5 ögrenciyi listele -----------------------------------");
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }
            SUBE sube = AracGerecler.SubeSec("Listelemek istediğiniz şubeyi girin(A/B/C): ");
            Console.WriteLine();
            List<Ogrenci> yeniListe = ogrenciler.Where(o => o.Sube == sube).ToList();
            Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("-------------------------------------------------------------------------------");
            List<Ogrenci> subeYeniListe = yeniListe.OrderByDescending(o => o.NotOrtalamasıHesapla()).Take(5).ToList();
            if (subeYeniListe.Count >= 1)
            {
                foreach (Ogrenci item in subeYeniListe)
                {

                    Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + $"{item.Ad} {item.Soyad}".PadRight(25) + item.NotOrtalamasıHesapla().ToString("#.##").PadRight(15) + item.ToplamOkunanKitapSayisi);

                }
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
            }
            else
            {
                Console.WriteLine("Subede listelenecek öğrenci yok.");
            }
        }

        public void SubedeWorst3eGoreListele()
        {
            Console.WriteLine("11-Subedeki en basarısız 3 ögrenciyi listele ----------------------------------");
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }
            SUBE sube = AracGerecler.SubeSec("Listelemek istediğiniz şubeyi girin(A/B/C): ");
            Console.WriteLine();
            List<Ogrenci> yeniListe = ogrenciler.Where(o => o.Sube == sube).ToList();
            Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
            Console.WriteLine("-------------------------------------------------------------------------------");
            List<Ogrenci> subeYeniListe = yeniListe.OrderBy(o => o.NotOrtalamasıHesapla()).Take(3).ToList();
            if (subeYeniListe.Count >= 1)
            {
                foreach (Ogrenci item in subeYeniListe)
                {

                    Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + $"{item.Ad} {item.Soyad}".PadRight(25) + item.NotOrtalamasıHesapla().ToString("#.##").PadRight(15) + item.ToplamOkunanKitapSayisi);

                }
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
            }
            else
            {
                Console.WriteLine("Subede listelenecek öğrenci yok.");
            }
        }

        public void OgrenciNotOrtalamasiGoster()
        {
            Console.WriteLine("12-Ögrencinin Not Ortalamasını Gör ----------------------------------");
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }
            while (true)
            {
                int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
                Ogrenci o = ogrenciler.FirstOrDefault(o => o.No == no);
                if (o != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ögrencinin Adı Soyadı: {o.Ad} {o.Soyad}");
                    Console.WriteLine($"Ögrencinin Subesi: {o.Sube}");
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin not ortalaması: " + o.NotOrtalamasıHesapla().ToString("#.##"));
                    Console.WriteLine();
                    Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                }

            }
        }

        public void SubeninNotOrtalamasi()
        {
            Console.WriteLine("13-Şubenin Not Ortalamasını Gör -------------------------------------");
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }
            SUBE sube = AracGerecler.SubeSec("Listelemek istediğiniz şubeyi girin(A/B/C): ");
            List<Ogrenci> yeniListe = ogrenciler.Where(o => o.Sube == sube).ToList();
            float toplam = 0;
            float ort = 0;
            if (yeniListe.Count >= 1)
            {
                foreach (Ogrenci ortalama in yeniListe)
                {
                    toplam += ortalama.NotOrtalamasıHesapla();
                }
                ort = toplam / yeniListe.Count;
                Console.WriteLine();
                Console.WriteLine($"{sube} subesinin not ortalaması: {ort.ToString("#.##")}");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
            }
            else
            {
                Console.WriteLine("Subede listelenecek öğrenci yok.");
            }
        }


        public void OkuduguSonKitabıGetir()
        {
            Console.WriteLine("14-Ögrencinin okudugu son kitabı listele ----------------------------");
            if (ogrenciler.Count < 1)
            {
                Console.WriteLine("Listede ögrenci yok.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                return;
            }
            while (true)
            {
                int no = AracGerecler.SayiAl("Ögrencinin numarasi: ");
                Ogrenci o = ogrenciler.FirstOrDefault(o => o.No == no);
                if (o != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ögrencinin Adı Soyadı: {o.Ad} {o.Soyad}");
                    Console.WriteLine($"Ögrencinin Subesi: {o.Sube}");
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Okudugu Son Kitap");
                    Console.WriteLine("-----------------------------");

                    Console.WriteLine(o.Kitaplar[o.Kitaplar.Count - 1]);


                    Console.WriteLine();
                    Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                }
            }



        }





        public Okul()
        {
            SahteVeriGir();
        }

        public void SahteVeriGir()
        {
            ogrenciler.Add(new Ogrenci(1, "Elif", "Selçuk", new DateTime(1970, 01, 01), CINSIYET.Kiz, SUBE.A));
            ogrenciler.Add(new Ogrenci(2, "Betül", "Yılmaz", new DateTime(1971, 01, 01), CINSIYET.Kiz, SUBE.B));
            ogrenciler.Add(new Ogrenci(3, "Hakan", "Çelik", new DateTime(1972, 01, 01), CINSIYET.Erkek, SUBE.C));
            ogrenciler.Add(new Ogrenci(4, "Kerem", "Akay", new DateTime(1970, 01, 01), CINSIYET.Erkek, SUBE.A));
            ogrenciler.Add(new Ogrenci(5, "Hatice", "Çınar", new DateTime(1973, 01, 01), CINSIYET.Kiz, SUBE.B));
            ogrenciler.Add(new Ogrenci(6, "Selim", "İleri", new DateTime(1975, 01, 01), CINSIYET.Erkek, SUBE.B));
            ogrenciler.Add(new Ogrenci(7, "Selin", "Kamış", new DateTime(1970, 01, 01), CINSIYET.Kiz, SUBE.C));
            ogrenciler.Add(new Ogrenci(8, "Sinan", "Avcı", new DateTime(1977, 01, 01), CINSIYET.Erkek, SUBE.A));
            ogrenciler.Add(new Ogrenci(9, "Deniz", "Çoban", new DateTime(1970, 01, 01), CINSIYET.Kiz, SUBE.C));
            ogrenciler.Add(new Ogrenci(10, "Selda", "Kavak", new DateTime(1970, 01, 01), CINSIYET.Kiz, SUBE.B));

            ogrenciler[0].KitapEkle("Noel Şarkısı");
            ogrenciler[1].KitapEkle("Jane Eyre");
            ogrenciler[2].KitapEkle("Ölü Ozanlar Derneği");
            ogrenciler[3].KitapEkle("Jane Eyre");
            ogrenciler[4].KitapEkle("Harry Potter Sırlar Odası");
            ogrenciler[5].KitapEkle("Uğultulu Tepeler");
            ogrenciler[6].KitapEkle("Geortge Orwell");
            ogrenciler[7].KitapEkle("Harry Potter Azkaban Tutsağı");
            ogrenciler[8].KitapEkle("Uğultulu Tepeler");
            ogrenciler[9].KitapEkle("Uğultulu Tepeler");

            ogrenciler[0].Notlar.Add(new DersNotu(DERSLER.Fen, 73));
            ogrenciler[0].Notlar.Add(new DersNotu(DERSLER.Türkçe, 10));
            //ogrenciler[0].Notlar.Add(new DersNotu(DERSLER.Matematik, 0));
            ogrenciler[0].Notlar.Add(new DersNotu(DERSLER.Sosyal, 36));
            ogrenciler[1].Notlar.Add(new DersNotu(DERSLER.Türkçe, 39));
            ogrenciler[1].Notlar.Add(new DersNotu(DERSLER.Matematik, 91));
            ogrenciler[1].Notlar.Add(new DersNotu(DERSLER.Fen, 99));
            ogrenciler[1].Notlar.Add(new DersNotu(DERSLER.Sosyal, 86));
            ogrenciler[2].Notlar.Add(new DersNotu(DERSLER.Türkçe, 6));
            ogrenciler[2].Notlar.Add(new DersNotu(DERSLER.Matematik, 24));
            ogrenciler[2].Notlar.Add(new DersNotu(DERSLER.Sosyal, 11));
            ogrenciler[2].Notlar.Add(new DersNotu(DERSLER.Fen, 26));
            ogrenciler[3].Notlar.Add(new DersNotu(DERSLER.Türkçe, 21));
            ogrenciler[3].Notlar.Add(new DersNotu(DERSLER.Matematik, 35));
            ogrenciler[3].Notlar.Add(new DersNotu(DERSLER.Fen, 38));
            ogrenciler[3].Notlar.Add(new DersNotu(DERSLER.Sosyal, 52));
            ogrenciler[4].Notlar.Add(new DersNotu(DERSLER.Türkçe, 30));
            ogrenciler[4].Notlar.Add(new DersNotu(DERSLER.Matematik, 74));
            ogrenciler[4].Notlar.Add(new DersNotu(DERSLER.Fen, 49));
            ogrenciler[4].Notlar.Add(new DersNotu(DERSLER.Sosyal, 49));
            ogrenciler[5].Notlar.Add(new DersNotu(DERSLER.Türkçe, 73));
            ogrenciler[5].Notlar.Add(new DersNotu(DERSLER.Matematik, 97));
            ogrenciler[5].Notlar.Add(new DersNotu(DERSLER.Fen, 73));
            ogrenciler[5].Notlar.Add(new DersNotu(DERSLER.Sosyal, 33));
            ogrenciler[6].Notlar.Add(new DersNotu(DERSLER.Türkçe, 23));
            ogrenciler[6].Notlar.Add(new DersNotu(DERSLER.Matematik, 94));
            ogrenciler[6].Notlar.Add(new DersNotu(DERSLER.Fen, 78));
            ogrenciler[6].Notlar.Add(new DersNotu(DERSLER.Sosyal, 60));
            ogrenciler[7].Notlar.Add(new DersNotu(DERSLER.Türkçe, 48));
            ogrenciler[7].Notlar.Add(new DersNotu(DERSLER.Matematik, 75));
            ogrenciler[7].Notlar.Add(new DersNotu(DERSLER.Fen, 73));
            ogrenciler[7].Notlar.Add(new DersNotu(DERSLER.Sosyal, 43));
            ogrenciler[8].Notlar.Add(new DersNotu(DERSLER.Türkçe, 60));
            ogrenciler[8].Notlar.Add(new DersNotu(DERSLER.Matematik, 69));
            ogrenciler[8].Notlar.Add(new DersNotu(DERSLER.Fen, 92));
            ogrenciler[8].Notlar.Add(new DersNotu(DERSLER.Sosyal, 87));
            ogrenciler[9].Notlar.Add(new DersNotu(DERSLER.Türkçe, 53));
            ogrenciler[9].Notlar.Add(new DersNotu(DERSLER.Matematik, 34));
            ogrenciler[9].Notlar.Add(new DersNotu(DERSLER.Fen, 28));
            ogrenciler[9].Notlar.Add(new DersNotu(DERSLER.Sosyal, 84));

            ogrenciler[0].Adresler.Add(new Adres("Ankara", "Çankaya"));
            ogrenciler[1].Adresler.Add(new Adres("Ankara", "Keçiören"));
            ogrenciler[2].Adresler.Add(new Adres("Ankara", "Çankaya"));
            ogrenciler[3].Adresler.Add(new Adres("İzmir", "Karşıyaka"));
            ogrenciler[4].Adresler.Add(new Adres("İzmir", "Gaziemir"));
            ogrenciler[5].Adresler.Add(new Adres("İzmir", "Gaziemir"));
            ogrenciler[6].Adresler.Add(new Adres("İzmir", "Bayraklı"));
            ogrenciler[7].Adresler.Add(new Adres("İstanbul", "Arnavutköy"));
            ogrenciler[8].Adresler.Add(new Adres("İstanbul", "Beykoy"));
            ogrenciler[9].Adresler.Add(new Adres("İstanbul", "Ataşehir"));
        }




    }
}
