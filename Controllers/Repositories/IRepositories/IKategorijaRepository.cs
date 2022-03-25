using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProizvodiSaKategorijamaWebApi.Models;

namespace ProizvodiSaKategorijamaWebApi.Repositories.IRepositories{

    public interface IKategorijaRepository{
        public Task<IEnumerable<Kategorija>> ListAllKategorijeAsync();

        public Task<Kategorija> GetKategorija(int id);
        public Task<Kategorija> AddAsync(Kategorija kategorija);
    }
}