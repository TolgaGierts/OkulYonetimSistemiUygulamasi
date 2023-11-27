using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimSistemiUygulamasi
{
    internal class Adres
    {
        public string Il;
        public string Ilce;
        public string Mahalle;

      

        public Adres(string ıl,string ılce)
        {
            this.Il = ıl;
            this.Ilce = ılce;
           
        }


    }
}
