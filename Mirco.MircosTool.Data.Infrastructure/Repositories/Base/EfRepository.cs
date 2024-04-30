using FluentResults;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mirco.MircosTool.Models.Entities.Base;
using Mirco.MircosTool.Data.Infrastructure.Context.Base;

namespace Mirco.MircosTool.Data.Infrastructure.Repositories.Base
{
    public abstract class EfRepository<TContext, TEntity, TKey>
     : IRepository<TEntity, TKey>
     where TContext : EfContext<TContext>
     where TEntity : EfEntity
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSetEntity;
        private bool _disposedValue;

        protected EfRepository(TContext context)
        {
            _context = context;
            _dbSetEntity = _context.Set<TEntity>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code.
            // Put cleanup code in 'Dispose(bool disposing)' method.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public virtual Task<TEntity?> ReadAsync(
            Expression<Func<TEntity, bool>> predicate
        )
        {
            return _dbSetEntity.FirstOrDefaultAsync(predicate);
        }
       

        public virtual TEntity? Create(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = _dbSetEntity.Add(entity);
            return entityEntry.Entity;
        }

        public virtual async Task<TEntity?> CreateAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await _dbSetEntity.AddAsync(entity);

            return entityEntry.Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = _dbSetEntity.Update(entity);
            return entityEntry.Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSetEntity.Remove(entity);
        }

        public void Delete(TKey key)
        {
            TEntity? e = _dbSetEntity.Find(key);
            if (e is null)
                return;

            _dbSetEntity.Remove(e);
        }

        public virtual int Save()
        {
            return _context.SaveChanges();
        }

        public virtual Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// <inheritdoc cref="SaveAsync"/>.
        /// Also log the Ex.
        /// </summary>
        public virtual async Task<Result<int>> TrySaveAsync()
        {
            try
            {
                int saved = await _context.SaveChangesAsync();
                if (saved == 0)
                {
                    return Result.Fail("Not saved");
                }

                return Result.Ok(saved);
            }
            catch (Exception ex)
            {
                return Result.Fail($"{ex.Message}");
            }
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _dbSetEntity.AsQueryable();
        }

        public virtual ValueTask<TEntity?> ReadAsync(TKey key)
        {
            return _dbSetEntity.FindAsync(key);
        }

        public virtual TEntity? Read(TKey key)
        {
            return _dbSetEntity.Find(key);
        }

        public virtual void CreateRange(IEnumerable<TEntity> entity)
        {
            _dbSetEntity.AddRange(entity);
        }

        public void DeleteRange(IEnumerable<TKey> keys)
        {
            foreach (TKey key in keys)
            {
                TEntity? e = _dbSetEntity.Find(key);
                if (e is null)
                    continue;
                _dbSetEntity.Remove(e);
            }
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSetEntity.RemoveRange(entities);
        }
    }

}
