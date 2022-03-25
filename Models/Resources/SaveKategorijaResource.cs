using System.ComponentModel.DataAnnotations;

namespace ProizvodiSaKategorijamaWebApi.Models.Resources{
    public class SaveKategorijaResource{

        [Key]
        public int KategorijaID { get; set; }
        [Required]       
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}