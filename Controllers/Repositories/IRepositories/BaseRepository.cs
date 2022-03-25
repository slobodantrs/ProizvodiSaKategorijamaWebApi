using System.Data;

namespace ProizvodiSaKategorijamaWebApi.Repositories.IRepositories{


    public abstract class BaseRepository{
        protected readonly IDbConnection _conn;
        public BaseRepository(IDbConnection conn)
        {
            _conn=conn;
        }
    }
}