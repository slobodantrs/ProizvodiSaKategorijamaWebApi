using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProizvodiSaKategorijamaWebApi.Models;
using ProizvodiSaKategorijamaWebApi.Repositories.IRepositories;
using ProizvodiSaKategorijamaWebApi.Services.Comunications;
using ProizvodiSaKategorijamaWebApi.Services.IServices;

namespace ProizvodiSaKategorijamaWebApi.Services{

    public class KategorijaService : IKategorijaService
    {
        private readonly IKategorijaRepository _kategorijaRepository;
        public KategorijaService(IKategorijaRepository kategorijaRepository)
        {
            _kategorijaRepository=kategorijaRepository;
        }

        public Task<Kategorija> GetKategorija(int id)
        {
            return _kategorijaRepository.GetKategorija(id);
        }

        public async Task<IEnumerable<Kategorija>> ListAllKategorijeAsync()
        {
            return await _kategorijaRepository.ListAllKategorijeAsync();
        }

        public async Task<SaveKategorijaResponse> SaveAsync(Kategorija kategorija)
        {
            try{
                var kategorijaResponse=await _kategorijaRepository.AddAsync(kategorija);
                return new SaveKategorijaResponse(true,"Uspesno je ubacena  kategorija u bazu",kategorijaResponse);
            }
            catch(Exception ex){
                return new SaveKategorijaResponse(false,$"Dogodila se greska pri ucitavanju kategorije {ex.Message}",kategorija);
            }
        }
    }
}