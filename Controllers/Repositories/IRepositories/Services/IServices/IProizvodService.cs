using System.Collections.Generic;
using System.Threading.Tasks;
using ProizvodiSaKategorijamaWebApi.Models;

namespace ProizvodiSaKategorijamaWebApi.Services.IServices{

    public interface IProizvodService{

        public Task<IEnumerable<Proizvod>> getSviProizvodi();
        public Task<Proizvod> getProizvod(int id);

        public Task<IEnumerable<Proizvod>> getProizvodiKategorije(int katId);
    }
}