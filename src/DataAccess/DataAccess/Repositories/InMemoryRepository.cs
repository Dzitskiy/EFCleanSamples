using Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected IList<T> Data { get; set; }

        public InMemoryRepository(IList<T> data) {
            Data = data;
        }

        public Task<IList<T>> GetAllAsync(CancellationToken token)
        {
           return Task.FromResult(Data);
        }
                
        public Task<T> GetByIdAsync(Guid id, CancellationToken token)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public Task CreateAsync(T entity, CancellationToken token)
        {
            Data.Add(entity);
            return Task.CompletedTask;
        }
        public Task UpdateAsync(T entity, CancellationToken token)
        {
            Data[Data.IndexOf(Data.FirstOrDefault(x => x.Id == entity?.Id))] = entity;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id, CancellationToken token)
        {
            Data.Remove(Data.FirstOrDefault(x => x.Id == id));
            return Task.CompletedTask;
        }
    }
}
