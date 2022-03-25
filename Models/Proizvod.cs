using System.ComponentModel.DataAnnotations.Schema;

namespace ProizvodiSaKategorijamaWebApi.Models{
    
    public class Proizvod{

        public int ProizvodID { get; set; }        
        public string Naziv { get; set; }
        public string Boja { get; set; }
        public string Velicina { get; set; }
        public double Cena { get; set; }
        public int Kolicina { get; set; }

        public int KategorijaID { get; set; }

        [ForeignKey("KategorijaID")]


      //  public Kategorija Kategorija { get; set; }=new Kategorija();
        public string Slika { get; set; }
    }
}



