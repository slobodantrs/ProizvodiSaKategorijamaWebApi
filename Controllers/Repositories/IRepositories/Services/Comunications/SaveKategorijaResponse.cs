using ProizvodiSaKategorijamaWebApi.Models;

namespace ProizvodiSaKategorijamaWebApi.Services.Comunications{
    public class SaveKategorijaResponse : BaseResponse
    {
        public Kategorija Kategorija { get; set; }
        
        public SaveKategorijaResponse(bool success, string message,Kategorija kategorija) : base(success, message)
        {
            Kategorija=kategorija;
            
        }
    }
}