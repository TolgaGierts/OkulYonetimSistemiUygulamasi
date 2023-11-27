using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimSistemiUygulamasi
{
    internal class Ogrenci
    {
        public int No;
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public SUBE Sube { get; set; }
        public CINSIYET Cinsiyet { get; set; }
        public Adres Adres { get; set; }
        public float Ortalama { get; }
        public DateTime DogumTarihi { get; set; }


        public int ToplamOkunanKitapSayisi
        {
            get
            {
                return Kitaplar.Count;

            }
        }


        public List<string> Kitaplar = new List<string>();
        public List<DersNotu> Notlar = new List<DersNotu>();
        public List<Adres> Adresler = new List<Adres>();

        public Ogrenci(int no, string ad, string soyad, DateTime tarih, CINSIYET cins, SUBE sb)
        {
            this.No = no;
            this.Ad = ad;
            this.Sube = sb;
            this.Soyad = soyad;
            this.DogumTarihi = tarih;
            this.Cinsiyet = cins;  
        }


        public float NotOrtalamasıHesapla()
        {
            float toplamNot = 0;

            foreach (DersNotu item in Notlar)
            {
                toplamNot += item.Not;
            }
            float ort = toplamNot / Notlar.Count;
            if (Notlar.Count == 0)
            {
                ort = 0;
            }
            return ort;
        }

        public void KitapEkle(string kitapAdi)
        {
            Kitaplar.Add(kitapAdi);
        }
    }
    public enum SUBE
    {
        A, B, C
    }
    public enum CINSIYET
    {
        
        Kiz, Erkek
    }
}
