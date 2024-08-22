using FAN.Infrastructure.Persistence.Repositories;
using FAN.Model.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace FAN.Infrastructure.Persistence.UOW;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> GetRepository<T>() where T : Base;
    Task<IDbContextTransaction> BeginNewTransaction();
    Task<bool> RollBackTransaction(IDbContextTransaction? transaction);
    Task TransactionCommit(IDbContextTransaction? transaction);
    Task<int> SaveChangesAsync();
}