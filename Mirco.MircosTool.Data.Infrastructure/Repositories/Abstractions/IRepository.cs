using FluentResults;
using Mirco.MircosTool.Data.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mirco.MircosTool.Data.Infrastructure.Repositories.Abstractions
{
    public interface IRepository
    {
        /// <summary>
        /// Commit the changes from context to database.
        /// </summary>
        /// <returns>The number of element saved.</returns>
        int Save();

        /// <summary>
        /// Commit the changes from context to database in async way.
        /// </summary>
        Task<int> SaveAsync();

        /// <summary>
        /// Try to <see cref="SaveAsync"/>.
        /// </summary>
        Task<Result<int>> TrySaveAsync();
    }
}

public interface IRepository<TEntity, TKey> : IDisposable, IRepository
    where TEntity : class
{
    /// <summary>
    /// Get an <see cref="IQueryable{T}"/> to query.
    /// </summary>
    IQueryable<TEntity> AsQueryable();

    /// <summary>
    /// Insert/Create an entity.
    /// </summary>
    /// <param name="entity">The entity that need to be created.</param>
    /// <returns>If the entity was inserted correctly, the inserted
    /// <typeparamref name="TEntity"/> will be returned, otherwise the
    /// <see langword="null"/> will be returned.
    /// </returns>
    TEntity? Create(TEntity entity);

    /// <summary>
    /// Insert/Create multiple entities.
    /// </summary>
    /// <param name="entities">The entities that need to be created.</param>
    /// <returns>If the entity was inserted correctly, the inserted
    /// <typeparamref name="TEntity"/> will be returned, otherwise an empty
    /// <see cref="IEnumerable{T}"/> will be returned.
    /// </returns>
    void CreateRange(IEnumerable<TEntity> entities);

    /// <summary>
    /// Delete the <paramref name="entity"/>.
    /// </summary>
    void Delete(TEntity entity);

    /// <summary>
    /// Delete the entity with that filtered <paramref name="key"/>.
    /// </summary>
    void Delete(TKey key);

    /// <summary>
    /// Delete a set of entities.
    /// </summary>
    /// <param name="entities">Entities to delete.</param>
    void DeleteRange(IEnumerable<TEntity> entities);

    /// <summary>
    /// Delete a set of entities.
    /// </summary>
    /// <param name="keys">The keys</param>
    void DeleteRange(IEnumerable<TKey> keys);

    /// <summary>
    /// Return the first element of a sequence that satisfies
    /// <paramref name="predicate"/>.</summary>
    /// <param name="predicate">The function predicate.</param>
    /// <returns>The entity if found, otherwise <see langword="null"/>.
    /// </returns>
    Task<TEntity?> ReadAsync(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Return the first element of a sequence that satisfies the
    /// <paramref name="key"/>.</summary>
    /// <returns>The entity if found, otherwise <see langword="null"/>.
    /// </returns>
    TEntity? Read(TKey key);

    /// <summary>
    /// Create an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<TEntity?> CreateAsync(TEntity entity);

    /// <summary>
    /// Read an entity by its primary key.
    /// </summary>
    /// <param name="key"></param>
    /// <returns>The entity if found, otherwise <see langword="null"/>.
    ///  </returns>
    ValueTask<TEntity?> ReadAsync(TKey key);

    /// <summary>
    /// Update an entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    TEntity Update(TEntity entity);
}


