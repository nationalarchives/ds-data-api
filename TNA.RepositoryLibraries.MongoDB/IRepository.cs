using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TNA.RepositoryLibraries.MongoDBEntities;

namespace TNA.RepositoryLibraries.MongoDB
{
    /// <summary>
    /// MongoDB repository contract
    /// </summary>
    /// <typeparam name="T">Type of the database object</typeparam>
    public interface IRepository<T> where T : IEntity
    {
        /// <summary>
        /// MongoDB collection
        /// </summary>
        IMongoCollection<T> Collection { get; }

        /// <summary>
        /// Filter definition for collection
        /// </summary>
        FilterDefinitionBuilder<T> FilterDefinition { get; }

        /// <summary>
        /// FindOption for collection
        /// </summary>
        FindOptions<T> FindOptions { get; }

        /// <summary>
        /// Projection definition for collection
        /// </summary>
        ProjectionDefinitionBuilder<T> ProjectionDefinition { get; }

        /// <summary>
        /// Sort definition for collection
        /// </summary>
        SortDefinitionBuilder<T> SortDefinition { get; }

        /// <summary>
        /// Update definition for collection
        /// </summary>
        UpdateDefinitionBuilder<T> UpdateDefinition { get; }

        /// <summary>
        /// Validate if filter result exists
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <returns><b>true</b> if exists, otherwise <b>false</b>></returns>

        bool Any(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Get number of documents in collection
        /// </summary>
        /// <returns>Number of documents</returns>
        long Count();

        /// <summary>
        /// Get number of filtered documents
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <returns>Number of documents</returns>
        long Count(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Get number of documents in collection
        /// </summary>
        /// <returns>Number of documents</returns>
        Task<long> CountAsync();

        /// <summary>
        /// Get number of filtered documents
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <returns>Number of documents</returns>
        Task<long> CountAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Delete items with filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        bool Delete(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Delete by MongoDB id
        /// </summary>
        /// <param name="id">Id (MongoDB "_id" field) of record to be deleted.</param>
        bool Delete(string id);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        bool Delete(T entity);

        /// <summary>
        /// Delete all documents
        /// </summary>
        bool DeleteAll();

        /// <summary>
        /// Delete all documents
        /// </summary>
        Task<bool> DeleteAllAsync();

        /// <summary>
        /// Delete items with filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        Task<bool> DeleteAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Delete by MongoDB id
        /// </summary>
        /// <param name="id">Id ("_id" MongoDB field) of record to be deleted.</param>
        Task<bool> DeleteAsync(string id);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity to be deleted</param>
        Task<bool> DeleteAsync(T entity);

        /// <summary>
        /// Find entities
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <returns>Collection of entities</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Find entities with paging and ordering
        /// default ordering is ascending
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="order">Ordering parameters</param>
        /// <param name="pageIndex">Page index, based on 0</param>
        /// <param name="size">Number of items in page</param>
        /// <returns>Collection of entities</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, int pageIndex, int size);

        /// <summary>
        /// Find entities with paging and sorting
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="order">Ordering parameters</param>
        /// <param name="pageIndex">Page index, based on 0</param>
        /// <param name="size">Number of items in page</param>
        /// <param name="isDescending">Ordering direction</param>
        /// <returns>Collection of entity</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, int pageIndex, int size, bool isDescending);

        /// <summary>
        /// Find entities with paging but no sorting
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="pageIndex">Page index, based on 0</param>
        /// <param name="size">Number of items in page</param>
        /// <returns>Collection of entities</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> filter, int pageIndex, int size);

        /// <summary>
        /// Finds entities with filter and option definitions
        /// </summary>
        /// <param name="filter">Filter definition</param>
        /// <param name="findOptions">Find options definition</param>
        /// <returns>Collection of entities</returns>
        IEnumerable<T> FindSync(FilterDefinition<T> filter, FindOptions<T, T> findOptions);

        /// <summary>
        /// Find entities with filter and option definitions
        /// </summary>
        /// <param name="filter">Filter definition</param>
        /// <param name="findOptions">Find options definition</param>
        /// <returns>Collection of entities</returns>
        Task<IEnumerable<T>> FindAsync(FilterDefinition<T> filter, FindOptions<T, T> findOptions);

        /// <summary>
        /// Get all items in collection
        /// </summary>
        /// <returns>Collection of entities</returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// Get all items in collection with paging and ordering
        /// default ordering is descending
        /// </summary>
        /// <param name="order">Ordering parameters</param>
        /// <param name="pageIndex">Page index, based on 0</param>
        /// <param name="size">Number of items in page</param>
        /// <returns>Collection of entities</returns>
        IEnumerable<T> FindAll(Expression<Func<T, object>> order, int pageIndex, int size);

        /// <summary>
        /// Get all items in collection with paging and ordering in direction
        /// </summary>
        /// <param name="order">Ordering parameters</param>
        /// <param name="pageIndex">Page index, based on 0</param>
        /// <param name="size">Number of items in page</param>
        /// <param name="isDescending">Ordering direction</param>
        /// <returns>Collection of entities</returns>
        IEnumerable<T> FindAll(Expression<Func<T, object>> order, int pageIndex, int size, bool isDescending);

        /// <summary>
        /// Get all items in collection with paging
        /// </summary>
        /// <param name="pageIndex">Page index, based on 0</param>
        /// <param name="size">Number of items in page</param>
        /// <returns>Collection of entities</returns>
        IEnumerable<T> FindAll(int pageIndex, int size);

        /// <summary>
        /// Get first item in collection
        /// </summary>
        /// <returns>Entity of <typeparamref name="T"/></returns>
        T First();

        /// <summary>
        /// Get first item in query
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <returns>Entity of <typeparamref name="T"/></returns>
        T First(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Get first item in query with order
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="order">Ordering parameters</param>
        /// <returns>Entity of <typeparamref name="T"/></returns>
        T First(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order);

        /// <summary>
        /// Get first item in query with order and direction
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="order">Ordering parameters</param>
        /// <param name="isDescending">Ordering direction</param>
        /// <returns>Entity of <typeparamref name="T"/></returns>
        T First(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, bool isDescending);

        /// <summary>
        /// Finds first entity which satisfy given filter and find options
        /// </summary>
        /// <param name="filter">Filter definition</param>
        /// <param name="findOptions">Find options</param>
        /// <returns>An entity if found</returns>
        T First(FilterDefinition<T> filter, FindOptions<T, T> findOptions);

        /// <summary>
        /// Finds first entity which satisfy given filter and find options
        /// </summary>
        /// <param name="filter">Filter definition</param>
        /// <param name="findOptions">Find options</param>
        /// <returns>A document if found</returns>
        Task<T> FirstAsync(FilterDefinition<T> filter, FindOptions<T, T> findOptions);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Id (MongoDb "_id") value</param>
        /// <returns>Entity of <typeparamref name="T"/></returns>
        T Get(string id);

        /// <summary>
        /// Insert entity collection
        /// </summary>
        /// <param name="entities">Collection of entities</param>
        bool Insert(IEnumerable<T> entities);

        /// <summary>
        /// Insert new entity
        /// </summary>
        /// <param name="entity">Entity which would be inserted</param>
        bool Insert(T entity);

        /// <summary>
        /// Insert entity collection
        /// </summary>
        /// <param name="entities">Collection of entities</param>
        Task InsertAsync(IEnumerable<T> entities);

        /// <summary>
        /// Insert new entity
        /// </summary>
        /// <param name="entity">entity</param>
        Task InsertAsync(T entity);

        /// <summary>
        /// Get last item in collection
        /// </summary>
        /// <returns>Entity of <typeparamref name="T"/></returns>
        T Last();

        /// <summary>
        /// Get last item in query
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <returns>Entity of <typeparamref name="T"/></returns>
        T Last(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Get last item in query with order
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="order">Ordering parameters</param>
        /// <returns>Entity of <typeparamref name="T"/></returns>
        T Last(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order);

        /// <summary>
        /// Get last item in query with order and direction
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="order">Ordering parameters</param>
        /// <param name="isDescending">Ordering direction</param>
        /// <returns>Entity of <typeparamref name="T"/></returns>
        T Last(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, bool isDescending);

        /// <summary>
        /// Replace collection of entities.
        /// The search criteria of the entity to be replaced is based on entity <b>"Id"</b> field value.
        /// </summary>
        /// <param name="entities">Collection of entities</param>
        void Replace(IEnumerable<T> entities);

        /// <summary>
        /// Replace an existing entity.
        /// The search criteria of the entity to be replaced is based on entity <b>"Id"</b> field value.
        /// </summary>
        /// <param name="entity">Entity to replace</param>
        /// <returns>Acknowledged operation result</returns>
        bool Replace(T entity);

        /// <summary>
        /// Replace an existing entity.
        /// The search criteria of the entity to be replaced is based on entity <b>"Id"</b> field value.
        /// </summary>
        /// <param name="entity">Entity to replace</param>
        /// <returns>Acknowledged operation result</returns>
        Task<bool> ReplaceAsync(T entity);

        /// <summary>
        /// Replace the first entity found using <paramref name="filter"/> parameter.
        /// </summary>
        /// <param name="filter">Collection filter to find a record to replace</param>
        /// <param name="entity">Entity to replace</param>
        /// <param name="options">Update options</param>
        /// <returns>Acknowledged operation result</returns>
        bool Replace(Expression<Func<T, bool>> filter, T entity, UpdateOptions options = null);

        /// <summary>
        /// Replace the first entity found using <paramref name="filter"/> parameter.
        /// </summary>
        /// <param name="filter">Collection filter to find a record to replace</param>
        /// <param name="entity">Entity to replace</param>
        /// <param name="options">Update options</param>
        /// <returns>Acknowledged operation result</returns>
        Task<bool> ReplaceAsync(Expression<Func<T, bool>> filter, T entity, UpdateOptions options = null);

        /// <summary>
        /// Update found entities by filter with updated fields
        /// </summary>
        /// <param name="filter">Collection filter</param>
        /// <param name="updates">Updated field(s) definition</param>
        /// <returns><b>true</b> if successful, otherwise <b>false</b></returns>
        bool Update(Expression<Func<T, bool>> filter, params UpdateDefinition<T>[] updates);

        /// <summary>
        /// Update all entities which satisfy filter and update definition parameters
        /// </summary>
        /// <param name="filter">Collection filter</param>
        /// <param name="updates">Updated field(s) definition</param>
        /// <returns><b>true</b> if successful, otherwise <b>false</b></returns>
        bool Update(FilterDefinition<T> filter, params UpdateDefinition<T>[] updates);

        /// <summary>
        /// Update an entity with updated fields
        /// </summary>
        /// <param name="id">Entity Id (MongoDB "_id" field)</param>
        /// <param name="updates">Updated field(s) definition</param>
        /// <returns><b>true</b> if successful, otherwise <b>false</b></returns>
        bool Update(string id, params UpdateDefinition<T>[] updates);

        /// <summary>
        /// Update an entity with updated fields
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <param name="updates">Updated field(s) definition</param>
        /// <returns><b>true</b> if successful, otherwise <b>false</b></returns>
        bool Update(T entity, params UpdateDefinition<T>[] updates);

        /// <summary>
        /// Update a property field in entities
        /// </summary>
        /// <typeparam name="TField">Field type</typeparam>
        /// <param name="filter">Filter definition</param>
        /// <param name="field">Field to update</param>
        /// <param name="value">New value of the <paramref name="field"/></param>
        bool Update<TField>(FilterDefinition<T> filter, Expression<Func<T, TField>> field, TField value);

        /// <summary>
        /// Update a property field in an entity
        /// </summary>
        /// <typeparam name="TField">Field type</typeparam>
        /// <param name="entity">Entity which field would be updated</param>
        /// <param name="field">Filed</param>
        /// <param name="value">New value of the <paramref name="field"/></param>
        /// <returns><b>true</b> if successful, otherwise <b>false</b></returns>
        bool Update<TField>(T entity, Expression<Func<T, TField>> field, TField value);

        /// <summary>
        /// Update found entities by filter with updated fields
        /// </summary>
        /// <param name="filter">Collection filter</param>
        /// <param name="updates">Update field(s) definition</param>
        /// <returns><b>true</b> if successful, otherwise <b>false</b></returns>
        Task<bool> UpdateAsync(Expression<Func<T, bool>> filter, params UpdateDefinition<T>[] updates);

        /// <summary>
        /// Update found entities by filter with updated fields
        /// </summary>
        /// <param name="filter">Collection filter</param>
        /// <param name="updates">Updated field(s) definitions</param>
        /// <returns><b>true</b> if successful, otherwise <b>false</b></returns>
        Task<bool> UpdateAsync(FilterDefinition<T> filter, params UpdateDefinition<T>[] updates);

        /// <summary>
        /// Update an entity with updated fields
        /// </summary>
        /// <param name="id">Entity Id (MongoDb "_id" field)</param>
        /// <param name="updates">Updated field(s) definitions</param>
        /// <returns><b>true</b> if successful, otherwise <b>false</b></returns>
        Task<bool> UpdateAsync(string id, params UpdateDefinition<T>[] updates);

        /// <summary>
        /// Update an entity with updated fields
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="updates">Updated field(s) definitions</param>
        /// <returns><b>true</b> if successful, otherwise <b>false</b></returns>
        Task<bool> UpdateAsync(T entity, params UpdateDefinition<T>[] updates);

        /// <summary>
        /// Update a property field in entities
        /// </summary>
        /// <typeparam name="TField">Field type</typeparam>
        /// <param name="filter">Filter definition</param>
        /// <param name="field">Field to be updated</param>
        /// <param name="value">New value of the <paramref name="field"/></param>
        Task<bool> UpdateAsync<TField>(FilterDefinition<T> filter, Expression<Func<T, TField>> field, TField value);

        /// <summary>
        /// Update a property field in an entity
        /// </summary>
        /// <typeparam name="TField">Field type</typeparam>
        /// <param name="entity">Entity to be updated</param>
        /// <param name="field">Field to be updated</param>
        /// <param name="value">New value of the <paramref name="field"/></param>
        /// <returns><b>true</b> if successful, otherwise <b>false</b></returns>
        Task<bool> UpdateAsync<TField>(T entity, Expression<Func<T, TField>> field, TField value);
    }
}