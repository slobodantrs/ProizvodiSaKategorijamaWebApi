using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using ProizvodiSaKategorijamaWebApi.Models;
using Microsoft.AspNetCore.Cors;
using ProizvodiSaKategorijamaWebApi.Services.IServices;

namespace ProizvodiSaKategorijamaWebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProizvodiController : ControllerBase
    {
        private readonly IProizvodService _proizvodiService;
        public ProizvodiController(IProizvodService proizvodiService)
        {
            _proizvodiService = proizvodiService;
        }

        [HttpGet]
        public async Task<IEnumerable<Proizvod>> getSviProizvodi()
        {
            return await _proizvodiService.getSviProizvodi();
        }

        [HttpGet("kat/{katId}")]
        public async Task<IEnumerable<Proizvod>> getPrioizvodikategorije(int katId)
        {
            return await _proizvodiService.getProizvodiKategorije(katId);
        }
        [HttpGet("{id}")]
        public async Task<Proizvod> getProizvod(int id)
        {
            return await _proizvodiService.getProizvod(id);
        }
    }

}