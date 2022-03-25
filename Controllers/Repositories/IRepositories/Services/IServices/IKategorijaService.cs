using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProizvodiSaKategorijamaWebApi.Models;
using ProizvodiSaKategorijamaWebApi.Services.Comunications;

namespace ProizvodiSaKategorijamaWebApi.Services.IServices{
    public interface IKategorijaService{

        public  Task<IEnumerable<Kategorija>> ListAllKategorijeAsync();

        public  Task<Kategorija> GetKategorija(int id);
        public Task<SaveKategorijaResponse>SaveAsync(Kategorija kategorija);
    }
}