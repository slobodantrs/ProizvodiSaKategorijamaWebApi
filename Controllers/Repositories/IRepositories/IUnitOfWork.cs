using System.Threading.Tasks;

namespace ProizvodiSaKategorijamaWebApi.Repositories.IRepositories{

    public interface IUnitOfWork{
        Task CompleteAsync();
    }
}