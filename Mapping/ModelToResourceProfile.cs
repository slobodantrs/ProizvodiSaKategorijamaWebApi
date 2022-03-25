using AutoMapper;
using ProizvodiSaKategorijamaWebApi.Models;
using ProizvodiSaKategorijamaWebApi.Models.Resources;


namespace ProizvodiSaKategorijamaWebApi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Kategorija, KategorijaResource>();
        }
    }

}