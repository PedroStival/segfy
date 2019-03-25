using System;
using System.Threading.Tasks;
using Insurance.Domain.Interfaces.Repository;

namespace Insurance.Domain.Interfaces
{
    public interface IContext : IDisposable
    {
        int Save();
        Task<int> SaveAsync();
    }
}
