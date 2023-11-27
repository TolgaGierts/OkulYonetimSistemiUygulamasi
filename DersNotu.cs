using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimSistemiUygulamasi
{
    internal class DersNotu
    {
        public DERSLER DersAdi;
        public float Not;
        public DersNotu(DERSLER ders, float not)
        {
            this.DersAdi = ders;
            this.Not = not;
        }
    }

    public enum DERSLER
    {
        Fen, Sosyal, Türkçe, Matematik
    }
}
