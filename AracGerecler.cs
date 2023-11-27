using System;
using System.Security.Cryptography.X509Certificates;

namespace OkulYonetimSistemiUygulamasi
{
    public static class AracGerecler
    {

        public static int SayiAl(string metin)
        {
            bool sonuc;
            int sayi;

            do
            {
                Console.Write(metin);
                string giris = Console.ReadLine();
                sonuc = int.TryParse(giris, out sayi);

                if (!sonuc)
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                }

            } while (!sonuc);

            return sayi;
        }


        public static string MenuSecimAl(string metin)
        {
            int sayac = 0;
            string karakterler = "1234567891011121314151617181920";
            while (true)
            {
                sayac++;
                Console.WriteLine();
                Console.Write(metin);
                string giris = Console.ReadLine();
                Console.WriteLine();

                if ((giris.Length == 1 && karakterler.IndexOf(giris) > -1) ||
                    (giris.Length == 2 && int.TryParse(giris, out int sayi) && sayi >= 10 && sayi <= 20))
                {
                    return giris;
                }
                else if (giris == "liste" || giris == "çıkış" || giris == "cikis")
                {
                    return giris;
                }
                else if (sayac == 10)
                {
                    Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                    Environment.Exit(0);
                }

                Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");
            }

        }
        
        public static DateTime DogumTarihiAl(string metin)
        {
            DateTime tarih;
            bool sonuc;

            do
            {
                Console.Write(metin);
                sonuc = DateTime.TryParse(Console.ReadLine(), out tarih);
               

                if (!sonuc)
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                }

            } while (!sonuc);

            return tarih;
        }
        public static DateTime DogumTarihiAl(DateTime defaultValue)
        {
            DateTime tarih;
            bool sonuc;
            do
            {
                Console.Write("Ögrencinin dogum tarihi: ");
                string veri = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(veri))
                {
                    return defaultValue;
                }

                sonuc = DateTime.TryParse(veri, out tarih);

                if (!sonuc)
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                }

            } while (!sonuc);

            return tarih;
        }
        public static string StringAl(string metin, string defaultValue = "")
        {
            string isim;
            do
            {
                Console.Write(metin);
                isim = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(isim))
                {
                    isim = defaultValue;
                    break;
                }
                bool harfVar = false;
                foreach (char karakter in isim)
                {
                    if (char.IsLetter(karakter))
                    {
                        harfVar = true;
                        break;
                    }
                }
                if (!harfVar)
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                }
            } while (!isim.Any(char.IsLetter));
            return isim.Substring(0, 1).ToUpper() + isim.Substring(1).ToLower();
        }

        public static string StringAl(string metin)
        {
            string isim;
            do
            {
                Console.Write(metin);
                isim = Console.ReadLine();
                bool harfVar = false;
                foreach (char karakter in isim)
                {
                    if (char.IsLetter(karakter))
                    {
                        harfVar = true;
                        break;
                    }
                }
                if (!harfVar)
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                }
            } while (!isim.Any(char.IsLetter));
            return isim.Substring(0, 1).ToUpper() + isim.Substring(1).ToLower();
        }

        public static string AdresAl(string metin)
        {
            string isim;
            do
            {
                Console.Write(metin);
                isim = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(isim))
                {
                    Console.WriteLine("Veri girişi yapılmadı tekrar deneyin.");
                    continue;
                }
                bool harfVar = false;
                foreach (char karakter in isim)
                {
                    if (char.IsLetter(karakter))
                    {
                        harfVar = true;
                        break;
                    }
                }
                if (!harfVar)
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                }
            } while (!isim.Any(char.IsLetter));
            return isim.Substring(0, 1).ToUpper() + isim.Substring(1).ToLower();
        }

        public static string KitapIsmiAl(string metin)
        {
            string isim;
            while(true)
            {
                Console.Write(metin);
                isim = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(isim))
                {
                    Console.WriteLine("Veri girişi yapılmadı tekrar deneyin.");
                    continue;
                }
            return isim.Substring(0, 1).ToUpper() + isim.Substring(1).ToLower();
            }
        }

        public static CINSIYET CinsiyetSec(string metin, CINSIYET defaultValue)
        {
           
            while (true)
            {

                Console.Write(metin);
                string secim = Console.ReadLine().ToLower();
                if (string.IsNullOrWhiteSpace(secim))
                {
                    return defaultValue;
                }

                    if (secim == "k")
                {
                    return CINSIYET.Kiz;
                }
                else if (secim == "e")
                {
                    return CINSIYET.Erkek;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                }

            }
        }
        public static CINSIYET CinsiyetSec(string metin)
        {

            while (true)
            {

                Console.Write(metin);
                string secim = Console.ReadLine().ToLower();

                if (secim == "k")
                {
                    return CINSIYET.Kiz;
                }
                else if (secim == "e")
                {
                    return CINSIYET.Erkek;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                }

            }
        }
        public static SUBE SubeSec(string metin, SUBE defaultValue)
        {
            while (true)
            {

                Console.Write(metin);
                string secim = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(secim)) { return defaultValue; }

                if (secim == "a")
                {
                    return SUBE.A;
                }
                else if (secim == "b")
                {
                    return SUBE.B;
                }
                else if (secim == "c")
                {
                    return SUBE.C;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                }

            }
        }
        public static SUBE SubeSec(string metin)
        {
            while (true)
            {

                Console.Write(metin);
                string secim = Console.ReadLine().ToLower();

                

                if (secim == "a")
                {
                    return SUBE.A;
                }
                else if (secim == "b")
                {
                    return SUBE.B;
                }
                else if (secim == "c")
                {
                    return SUBE.C;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                }

            }
        }
        public static DERSLER DersSec(string metin)
        {
            while (true)
            {
                Console.Write(metin);
                string secim = Console.ReadLine().ToLower();
                if (secim == "1")
                {
                    return DERSLER.Fen;
                }
                else if (secim == "2")
                {
                    return DERSLER.Sosyal;
                }
                else if (secim == "3")
                {
                    return DERSLER.Matematik;
                }
                else if (secim == "4")
                {
                    return DERSLER.Türkçe;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar deneyin.");
                }

            }
        }

       




    }
}
