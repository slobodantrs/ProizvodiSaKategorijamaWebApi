using System.Collections.Generic;
using System.Threading.Tasks;
using ProizvodiSaKategorijamaWebApi.Models;

namespace ProizvodiSaKategorijamaWebApi.Repositories.IRepositories{


    public interface IProizvodRepository{
        public Task<IEnumerable<Proizvod>> getSviProizvodi();
        public Task<Proizvod> getProizvod(int id);

        public Task<IEnumerable<Proizvod>> getProizvodiKategorije(int katId);
    }
}