using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentalShopRepository.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using RentalShopRepository.Context;

namespace RentalShopRepository.Entity.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class;

        RentalShopContext Context { get; }
        Task<int> SaveAsync();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
    }

    public class UnitOfWork : IUnitOfWork
    {
        public RentalShopContext Context { get; }

        private Dictionary<Type, object> _repositoriesAsync;
        private bool _disposed;

        public UnitOfWork(RentalShopContext context)
        {
            Context = context;
            _disposed = false;
        }

        public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class
        {
            if (_repositoriesAsync == null)
            {
                _repositoriesAsync = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!_repositoriesAsync.ContainsKey(type))
            {
                _repositoriesAsync[type] = new RepositoryAsync<TEntity>(this);
            }

            return (IRepositoryAsync<TEntity>)_repositoriesAsync[type];
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return -1;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        virtual protected void Dispose(bool isDisposing)
        {
            if (!_disposed && isDisposing)
            {
                Context.Dispose();
            }
            _disposed = true;
        }
    }
}
