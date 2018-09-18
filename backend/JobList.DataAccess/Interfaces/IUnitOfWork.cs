using JobList.DataAccess.Interfaces.Repositories;
using System.Threading.Tasks;

namespace JobList.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        ISamplesRepository SamplesRepository { get; }

        Task<bool> SaveAsync();
    }
}
