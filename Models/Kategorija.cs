using System;
using System.Collections.Generic;

namespace ProizvodiSaKategorijamaWebApi.Models
{

    public class Kategorija
    {
        public int KategorijaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public IList<Proizvod> Proizvodi { get; set; }=new List<Proizvod>();
       
    }


}