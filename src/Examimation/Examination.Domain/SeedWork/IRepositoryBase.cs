using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examination.Domain.SeedWork
{
  public interface IRepositoryBase<T> where T : IAggregateRoot
  {
    Task InsertAsync(T obj);
    Task UpdateAsync(T obj);
    Task DeleteAsync(string id);
    void StartTransaction();
    Task CommitTracsactionAsync(T entity, CancellationToken cancellationToken = default);
    Task AbortTracsactionAsync(CancellationToken cancellationToken = default);
  }
}