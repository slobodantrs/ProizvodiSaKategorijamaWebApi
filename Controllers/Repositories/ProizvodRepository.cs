using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using ProizvodiSaKategorijamaWebApi.Models;
using ProizvodiSaKategorijamaWebApi.Repositories.IRepositories;

namespace ProizvodiSaKategorijamaWebApi.Repositories{
    public class ProizvodRepository : BaseRepository, IProizvodRepository
    {
        public ProizvodRepository(IDbConnection conn) : base(conn)
        {
        }

        public async Task<IEnumerable<Proizvod>> getProizvodiKategorije(int katId)
        {
            string querry = "SELECT * FROM Proizvod WHERE KategorijaID=" + katId;
            var proizvodiKat = await  _conn.QueryAsync<Proizvod>(querry);
            return proizvodiKat.AsList<Proizvod>();
        }

        public async Task<Proizvod> getProizvod(int id)
        {
            string querry = "SELECT * FROM Proizvod WHERE ProizvodID="+id;
            var product = await _conn.QuerySingleOrDefaultAsync<Proizvod>(querry);
            return product;
        }

        public async Task<IEnumerable<Proizvod>> getSviProizvodi()
        {
            string querry = "SELECT * FROM Proizvod";
            var proizvodi = await _conn.QueryAsync<Proizvod>(querry);
            return proizvodi.AsList<Proizvod>();
        }
    }
}