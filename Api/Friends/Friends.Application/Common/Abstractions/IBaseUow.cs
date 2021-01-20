using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Friends.Application.Common.Abstractions
{
    public interface IBaseUow : IDisposable
    {
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        int Save();
        Task<int> SaveAsync();
    }
}
