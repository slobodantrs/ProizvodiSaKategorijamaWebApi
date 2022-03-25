using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProizvodiSaKategorijamaWebApi.Models;
using ProizvodiSaKategorijamaWebApi.Models.Resources;
using ProizvodiSaKategorijamaWebApi.Services.IServices;

namespace ProizvodiSaKategorijamaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KategorijeController : ControllerBase
    {
        private readonly IKategorijaService _kategorijaService;
        private readonly IMapper _mapper;
        public KategorijeController(IKategorijaService kategorijaService, IMapper mapper)
        {
            _kategorijaService = kategorijaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<KategorijaResource>> GetAllKategorije()
        {
            var kategorije = await _kategorijaService.ListAllKategorijeAsync();

            var resources = _mapper.Map<IEnumerable<Kategorija>, IEnumerable<KategorijaResource>>(kategorije);
            return resources.AsList<KategorijaResource>();

            /*Varijanta sa vracanjem kao Json*/
            /*  var podaciJSON=Json(new {data=products.AsList<Product>()});
              return podaciJSON;*/


        }

        [HttpGet("{id}")]
        public async Task<Kategorija> GetKategorija(int id)
        {
            var product = await _kategorijaService.GetKategorija(id);
            return product;

        }

        [HttpPost("create")]
        public async Task<ActionResult> PostAsync([FromBody] Kategorija resource)
        {
           
            if (!ModelState.IsValid)
                return BadRequest();
          //  var kategorija = _mapper.Map<SaveKategorijaResource, Kategorija>(resource);
            var kategorijaSaved = await _kategorijaService.SaveAsync(resource);
            if (!kategorijaSaved.Success)
            {
                return BadRequest(kategorijaSaved.Message);
            }
            var kategorijaResource = _mapper.Map<Kategorija, KategorijaResource>(kategorijaSaved.Kategorija);
           return Ok(kategorijaResource);
         //   return CreatedAtRoute("KategorijaById",new{id=kategorijaResource.KategorijaId},kategorijaResource);
        }
    }

}