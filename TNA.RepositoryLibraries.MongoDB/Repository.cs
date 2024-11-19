using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Threading.Tasks;
using TNA.RepositoryLibraries.MongoDBEntities;

namespace TNA.RepositoryLibraries.MongoDB
{
    /// <summary>
    /// Implements <see cref="IRepository{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        #region MongoSpecific

        /// <summary>
        /// Repository settings from config object.
        /// <para>Use [ConnectionName] and [CollectionName] attributes on the data object to read configurations from configuration file.</para>
        /// <para>Connection string URL parameters and options can be found here: <see href="https://docs.mongodb.com/manual/reference/connection-string/"/>  </para>
        /// </summary>
        /// <param name="config">Config interface to read default settings</param>
        public Repository(IConfiguration config)
        {
            Collection = Database<T>.GetCollection(config);
        }

        /// <summary>
        /// Repository setting where collection name is determined from type attribute or type name
        /// <para>Connection string URL parameters and options can be found here: <see href="https://docs.mongodb.com/manual/reference/connection-string/"/>  </para>
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        public Repository(string connectionString)
        {
            Collection = Database<T>.GetCollectionFromConnectionString(connectionString);
        }

        /// <summary>
        /// Repository custom settings
        /// <para>Connection string URL parameters and options can be found here: <see href="https://docs.mongodb.com/manual/reference/connection-string/"/>  </para>
        /// </summary>
        /// <param name="connectionString">connection string</param>
        /// <param name="collectionName">collection name</param>
        public Repository(string connectionString, string collectionName)
        {
            Collection = Database<T>.GetCollectionFromConnectionString(connectionString, collectionName);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Collection"/>
        /// </summary>
        public IMongoCollection<T> Collection
        {
            get;
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.FilterDefinition"/>
        /// </summary>
        public FilterDefinitionBuilder<T> FilterDefinition => Builders<T>.Filter;

        /// <summary>
        /// Implements <see cref="IRepository{T}.FindOptions"/>
        /// </summary>
        public FindOptions<T> FindOptions => new FindOptions<T>();

        /// <summary>
        /// Implements <see cref="IRepository{T}.ProjectionDefinition"/>
        /// </summary>
        public ProjectionDefinitionBuilder<T> ProjectionDefinition => Builders<T>.Projection;

        /// <summary>
        /// Implements <see cref="IRepository{T}.SortDefinition"/>
        /// </summary>
        public SortDefinitionBuilder<T> SortDefinition => Builders<T>.Sort;

        /// <summary>
        /// Implements <see cref="IRepository{T}.UpdateDefinition"/>
        /// </summary>
        public UpdateDefinitionBuilder<T> UpdateDefinition => Builders<T>.Update;

        private IFindFluent<T, T> Query(Expression<Func<T, bool>> filter)
        {
            return Collection.Find(filter);
        }

        private IFindFluent<T, T> Query()
        {
            return Collection.Find(FilterDefinition.Empty);
        }

        #endregion MongoSpecific

        #region CRUD

        #region Delete

        /// <summary>
        /// Implements <see cref="IRepository{T}.Delete(T)"/>
        /// </summary>
        public bool Delete(T entity)
        {
            return Delete(entity.Id);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Delete(string)"/>
        /// </summary>
        public virtual bool Delete(string id)
        {
            return Retry(() =>
            {
                return Collection.DeleteOne(i => i.Id == id).IsAcknowledged;
            });
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Delete(Expression{Func{T, bool}})"/>
        /// </summary>
        public bool Delete(Expression<Func<T, bool>> filter)
        {
            return Retry(() => Collection.DeleteMany(filter).IsAcknowledged);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.DeleteAll"/>
        /// </summary>
        public virtual bool DeleteAll()
        {
            return Retry(() => Collection.DeleteMany(FilterDefinition.Empty).IsAcknowledged);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.DeleteAllAsync"/>
        /// </summary>
        public virtual Task<bool> DeleteAllAsync()
        {
            return Retry(() =>
            {
                return Task.Run(() => DeleteAll());
            });
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.DeleteAsync(T)"/>
        /// </summary>
        public Task<bool> DeleteAsync(T entity)
        {
            return Task.Run(() => Delete(entity));
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.DeleteAsync(string)"/>
        /// </summary>
        public virtual Task<bool> DeleteAsync(string id)
        {
            return Retry(() =>
            {
                return Task.Run(() => Delete(id));
            });
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.DeleteAsync(Expression{Func{T, bool}})"/>
        /// </summary>
        public Task<bool> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            return Retry(() =>
            {
                return Task.Run(() => Delete(filter));
            });
        }

        #endregion Delete

        #region Find

        /// <summary>
        /// Implements <see cref="IRepository{T}.Find(Expression{Func{T, bool}})"/>
        /// </summary>
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            return Query(filter).ToEnumerable();
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Find(Expression{Func{T, bool}}, int, int)"/>
        /// </summary>
        public IEnumerable<T> Find(Expression<Func<T, bool>> filter, int pageIndex, int size)
        {
            return Find(filter, i => i.Id, pageIndex, size);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Find(Expression{Func{T, bool}}, Expression{Func{T, object}}, int, int)"/>
        /// </summary>
        public IEnumerable<T> Find(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, int pageIndex, int size)
        {
            return Find(filter, order, pageIndex, size, true);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Find(Expression{Func{T, bool}}, Expression{Func{T, object}}, int, int, bool)"/>
        /// </summary>
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, int pageIndex, int size, bool isDescending)
        {
            return Retry(() =>
            {
                var query = Query(filter).Skip(pageIndex * size).Limit(size);
                return (isDescending ? query.SortByDescending(order) : query.SortBy(order))?.ToEnumerable();
            });
        }

        /// <summary>
        ///Implements <see cref="IRepository{T}.FindSync(FilterDefinition{T}, FindOptions{T, T})"/>
        /// </summary>
        public IEnumerable<T> FindSync(FilterDefinition<T> filter, FindOptions<T, T> findOptions)
        {
            return Retry(() => Collection.FindSync(filter, findOptions)?.ToEnumerable());
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.FindAsync(FilterDefinition{T}, FindOptions{T, T})"/>
        /// </summary>
        public async Task<IEnumerable<T>> FindAsync(FilterDefinition<T> filter, FindOptions<T, T> findOptions)
        {
            IAsyncCursor<T> result = await Collection.FindAsync(filter, findOptions);

            return result?.ToEnumerable();
        }

        #endregion Find

        #region FindAll

        /// <summary>
        /// Implements <see cref="IRepository{T}.FindAll()"/>
        /// </summary>
        public virtual IEnumerable<T> FindAll()
        {
            return Retry(() => Query().ToEnumerable());
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.FindAll(int, int)"/>
        /// </summary>
        public IEnumerable<T> FindAll(int pageIndex, int size)
        {
            return FindAll(i => i.Id, pageIndex, size);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.FindAll(Expression{Func{T, object}}, int, int)"/>
        /// </summary>
        public IEnumerable<T> FindAll(Expression<Func<T, object>> order, int pageIndex, int size)
        {
            return FindAll(order, pageIndex, size, false);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.FindAll(Expression{Func{T, object}}, int, int, bool)"/>
        /// </summary>
        public virtual IEnumerable<T> FindAll(Expression<Func<T, object>> order, int pageIndex, int size, bool isDescending)
        {
            return Retry(() =>
            {
                var query = Query().Skip(pageIndex * size).Limit(size);
                return (isDescending ? query.SortByDescending(order) : query.SortBy(order)).ToEnumerable();
            });
        }

        #endregion FindAll

        #region First

        /// <summary>
        /// Implements <see cref="IRepository{T}.First()"/>
        /// </summary>
        public T First()
        {
            return FindAll(i => i.Id, 0, 1, false).FirstOrDefault();
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.First(Expression{Func{T, bool}})"/>
        /// </summary>
        public T First(Expression<Func<T, bool>> filter)
        {
            return First(filter, i => i.Id);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.First(Expression{Func{T, bool}}, Expression{Func{T, object}})"/>
        /// </summary>
        public T First(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order)
        {
            return First(filter, order, false);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.First(Expression{Func{T, bool}}, Expression{Func{T, object}}, bool)"/>
        /// </summary>
        public T First(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, bool isDescending)
        {
            return Find(filter, order, 0, 1, isDescending).FirstOrDefault();
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.First(FilterDefinition{T}, FindOptions{T, T})"/>
        /// </summary>
        public T First(FilterDefinition<T> filter, FindOptions<T, T> findOptions)
        {
            IAsyncCursor<T> result = Collection.FindSync(filter, findOptions);

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.FirstAsync(FilterDefinition{T}, FindOptions{T, T})"/>
        /// </summary>
        public async Task<T> FirstAsync(FilterDefinition<T> filter, FindOptions<T, T> findOptions)
        {
            var result = await Collection.FindAsync(filter, findOptions);

            return await result.FirstOrDefaultAsync();
        }

        #endregion First

        #region Get

        /// <summary>
        /// Implements <see cref="IRepository{T}.Get(string)"/>
        /// </summary>
        public virtual T Get(string id)
        {
            return Retry(() =>
            {
                return Find(i => i.Id == id).FirstOrDefault();
            });
        }

        #endregion Get

        #region Insert

        /// <summary>
        /// Implements <see cref="IRepository{T}.Insert(T)"/>
        /// </summary>
        public virtual bool Insert(T entity)
        {
            return Retry(() =>
             {
                 Collection.InsertOne(entity);
                 return true;
             });
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Insert(IEnumerable{T})"/>
        /// </summary>
        public virtual bool Insert(IEnumerable<T> entities)
        {
            return Retry(() =>
             {
                 Collection.InsertMany(entities);
                 return true;
             });
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.InsertAsync(T)"/>
        /// </summary>
        public virtual Task InsertAsync(T entity)
        {
            return Retry(() => Collection.InsertOneAsync(entity));
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.InsertAsync(IEnumerable{T})"/>
        /// </summary>
        public virtual Task InsertAsync(IEnumerable<T> entities)
        {
            return Retry(() => Collection.InsertManyAsync(entities));
        }

        #endregion Insert

        #region Last

        /// <summary>
        /// Implements <see cref="IRepository{T}.Last()"/>
        /// </summary>
        public T Last()
        {
            return FindAll(i => i.Id, 0, 1, true).FirstOrDefault();
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Last(Expression{Func{T, bool}})"/>
        /// </summary>
        public T Last(Expression<Func<T, bool>> filter)
        {
            return Last(filter, i => i.Id);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Last(Expression{Func{T, bool}}, Expression{Func{T, object}})"/>
        /// </summary>
        public T Last(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order)
        {
            return Last(filter, order, false);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Last(Expression{Func{T, bool}}, Expression{Func{T, object}}, bool)"/>
        /// </summary>
        public T Last(Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, bool isDescending)
        {
            return First(filter, order, !isDescending);
        }

        #endregion Last

        #region Replace

        /// <summary>
        /// Implements <see cref="IRepository{T}.Replace(T)"/>
        /// </summary>
        public virtual bool Replace(T entity)
        {
            return Retry(() =>
            {
                return Collection.ReplaceOne(i => i.Id == entity.Id, entity).IsAcknowledged;
            });
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Replace(IEnumerable{T})"/>
        /// </summary>
        public void Replace(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                Replace(entity);
            }
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.ReplaceAsync(T)"/>
        /// </summary>
        public virtual Task<bool> ReplaceAsync(T entity)
        {
            return Retry(() =>
            {
                return Task.Run(() => Replace(entity));
            });
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.ReplaceAsync(Expression{Func{T, bool}}, T, UpdateOptions)"/>
        /// </summary>
        public bool Replace(Expression<Func<T, bool>> filter, T entity, UpdateOptions options = null)
        {
            return Retry(() => Collection.ReplaceOne(filter, entity, options).IsAcknowledged);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Replace(Expression{Func{T, bool}}, T, UpdateOptions)"/>
        /// </summary>
        public virtual Task<bool> ReplaceAsync(Expression<Func<T, bool>> filter, T entity, UpdateOptions options = null)
        {
            return Retry(() =>
            {
                return Task.Run(() => Collection.ReplaceOneAsync(filter, entity, options).Result.IsAcknowledged);
            });
        }

        #endregion Replace

        #region Update

        /// <summary>
        /// Implements <see cref="IRepository{T}.Update{TField}(T, Expression{Func{T, TField}}, TField)"/>
        /// </summary>
        public bool Update<TField>(T entity, Expression<Func<T, TField>> field, TField value)
        {
            return Update(entity, UpdateDefinition.Set(field, value));
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Update(string, UpdateDefinition{T}[])"/>
        /// </summary>
        public virtual bool Update(string id, params UpdateDefinition<T>[] updates)
        {
            return Update(FilterDefinition.Eq(i => i.Id, id), updates);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Update(T, UpdateDefinition{T}[])"/>
        /// </summary>
        public virtual bool Update(T entity, params UpdateDefinition<T>[] updates)
        {
            return Update(entity.Id, updates);
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Update{TField}(FilterDefinition{T}, Expression{Func{T, TField}}, TField)"/>
        /// </summary>
        public bool Update<TField>(FilterDefinition<T> filter, Expression<Func<T, TField>> field, TField value)
        {
            return Update(filter, UpdateDefinition.Set(field, value));
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Update(FilterDefinition{T}, UpdateDefinition{T}[])"/>
        /// </summary>
        public bool Update(FilterDefinition<T> filter, params UpdateDefinition<T>[] updates)
        {
            return Retry(() =>
            {
                var update = UpdateDefinition.Combine(updates).CurrentDate(i => i.ModifiedOn);
                return Collection.UpdateMany(filter, update.CurrentDate(i => i.ModifiedOn)).IsAcknowledged;
            });
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Update(Expression{Func{T, bool}}, UpdateDefinition{T}[])"/>
        /// </summary>
        public bool Update(Expression<Func<T, bool>> filter, params UpdateDefinition<T>[] updates)
        {
            return Retry(() =>
            {
                var update = UpdateDefinition.Combine(updates).CurrentDate(i => i.ModifiedOn);
                return Collection.UpdateMany(filter, update).IsAcknowledged;
            });
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.UpdateAsync{TField}(T, Expression{Func{T, TField}}, TField)"/>
        /// </summary>
        public Task<bool> UpdateAsync<TField>(T entity, Expression<Func<T, TField>> field, TField value)
        {
            return Task.Run(() => Update(entity, UpdateDefinition.Set(field, value)));
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.UpdateAsync(string, UpdateDefinition{T}[])"/>
        /// </summary>
        public virtual Task<bool> UpdateAsync(string id, params UpdateDefinition<T>[] updates)
        {
            return Task.Run(() =>
            {
                return Update(FilterDefinition.Eq(i => i.Id, id), updates);
            });
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.UpdateAsync(T, UpdateDefinition{T}[])"/>
        /// </summary>
        public virtual Task<bool> UpdateAsync(T entity, params UpdateDefinition<T>[] updates)
        {
            return Task.Run(() => Update(entity.Id, updates));
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.UpdateAsync{TField}(FilterDefinition{T}, Expression{Func{T, TField}}, TField)"/>
        /// </summary>
        public Task<bool> UpdateAsync<TField>(FilterDefinition<T> filter, Expression<Func<T, TField>> field, TField value)
        {
            return Task.Run(() => Update(filter, UpdateDefinition.Set(field, value)));
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.UpdateAsync{TField}(FilterDefinition{T}, Expression{Func{T, TField}}, TField)"/>
        /// </summary>
        public Task<bool> UpdateAsync(FilterDefinition<T> filter, params UpdateDefinition<T>[] updates)
        {
            return Retry(() =>
            {
                return Task.Run(() => Update(filter, updates));
            });
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.UpdateAsync(Expression{Func{T, bool}}, UpdateDefinition{T}[])"/>
        /// </summary>
        public Task<bool> UpdateAsync(Expression<Func<T, bool>> filter, params UpdateDefinition<T>[] updates)
        {
            return Retry(() =>
            {
                return Task.Run(() => Update(filter, updates));
            });
        }

        #endregion Update

        #endregion CRUD

        #region Utils

        /// <summary>
        /// Implements <see cref="IRepository{T}.Any(Expression{Func{T, bool}})"/>
        /// </summary>
        public bool Any(Expression<Func<T, bool>> filter)
        {
            return Retry(() => First(filter) != null);
        }

        #region Count

        /// <summary>
        /// Implements <see cref="IRepository{T}.Count(Expression{Func{T, bool}})"/>
        /// </summary>
        public long Count(Expression<Func<T, bool>> filter)
        {
            return Retry(() => Collection.Count(filter));
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.Count()"/>
        /// </summary>
        public long Count()
        {
            return Retry(() => Collection.Count(FilterDefinition.Empty));
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.CountAsync(Expression{Func{T, bool}})"/>
        /// </summary>
        public Task<long> CountAsync(Expression<Func<T, bool>> filter)
        {
            return Retry(() => Collection.CountAsync(filter));
        }

        /// <summary>
        /// Implements <see cref="IRepository{T}.CountAsync()"/>
        /// </summary>
        public Task<long> CountAsync()
        {
            return Retry(() => Collection.CountAsync(FilterDefinition.Empty));
        }

        #endregion Count

        #endregion Utils

        #region RetryPolicy

        /// <summary>
        /// Retry operation for three times if IOException occurs
        /// </summary>
        /// <typeparam name="TResult">Return type</typeparam>
        /// <param name="action">Action</param>
        /// <returns>Action result</returns>
        /// <example>
        /// return Retry(() =>
        /// {
        ///     do_something;
        ///     return something;
        /// });
        /// </example>
        protected virtual TResult Retry<TResult>(Func<TResult> action)
        {
            return Policy
                .Handle<MongoConnectionException>(i => i?.InnerException?.GetType() == typeof(IOException) ||
                                                       i?.InnerException?.GetType() == typeof(SocketException))
                .Retry(3)
                .Execute(action);
        }

        #endregion RetryPolicy
    }
}