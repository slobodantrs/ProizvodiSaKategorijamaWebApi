using System.Collections.Generic;
using System.Threading.Tasks;
using ProizvodiSaKategorijamaWebApi.Models;
using ProizvodiSaKategorijamaWebApi.Repositories.IRepositories;
using ProizvodiSaKategorijamaWebApi.Services.IServices;

namespace ProizvodiSaKategorijamaWebApi.Services{

    public class ProizvodService : IProizvodService
    {
        private readonly IProizvodRepository _proizvodRepository;

        public ProizvodService(IProizvodRepository proizvodRepository)
        {
            _proizvodRepository=proizvodRepository;
        }
        public async Task<IEnumerable<Proizvod>> getProizvodiKategorije(int katId)
        {
            return await _proizvodRepository.getProizvodiKategorije(katId);
        }

        public async Task<Proizvod> getProizvod(int id)
        {
            return await _proizvodRepository.getProizvod(id);
        }

        public async Task<IEnumerable<Proizvod>> getSviProizvodi()
        {
            return await _proizvodRepository.getSviProizvodi();
        }
    }
}