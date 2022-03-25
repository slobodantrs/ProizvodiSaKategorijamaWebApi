using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProizvodiSaKategorijamaWebApi.Models;
using ProizvodiSaKategorijamaWebApi.Repositories.IRepositories;

namespace ProizvodiSaKategorijamaWebApi.Repositories{

    public class KategorijaRepository : BaseRepository, IKategorijaRepository
    {
        public KategorijaRepository(IDbConnection conn) : base(conn)
        {
        }

        public async Task<Kategorija>AddAsync(Kategorija kategorija)
        {
            
            
            string querry = @"insert into Kategorija( Naziv, Opis) values(@Naziv,@Opis)"
            +"SELECT CAST(SCOPE_IDENTITY() as int)";
            SqlCommand command = new SqlCommand(querry, (SqlConnection)_conn);
            var katId = await _conn.QuerySingleOrDefaultAsync<int>(querry, kategorija);   
            var createdKategorija=new Kategorija{
                KategorijaID=katId,
                Naziv=kategorija.Naziv,
                Opis=kategorija.Opis
            } ;  
            return createdKategorija;
           
        }

        public async Task<Kategorija> GetKategorija(int id)
        {
            string querry = "SELECT * FROM Kategorija WHERE KategorijaID="+id;
            var kategorija = await _conn.QuerySingleOrDefaultAsync<Kategorija>(querry);
            return kategorija;
        }

        public async Task<IEnumerable<Kategorija>> ListAllKategorijeAsync()
        {
             string querry = "SELECT * FROM Kategorija";
            var kategorije = await _conn.QueryAsync<Kategorija>(querry);
            
            return kategorije.AsList<Kategorija>();
        }

        
    }
}