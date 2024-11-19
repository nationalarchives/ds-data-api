using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Core.Servers;
using System;
using System.Reflection;
using TNA.RepositoryLibraries.MongoDBEntities;

namespace TNA.RepositoryLibraries.MongoDB
{
    internal class Database<T> where T : IEntity
    {
        private static Type _entityType = typeof(T);

        private Database()
        {
        }

        /// <summary>
        /// Creates and returns a MongoCollection from specified type or [CollectionName] attribute.
        /// </summary>
        /// <param name="config">Configuration interface</param>
        /// <returns></returns>
        internal static IMongoCollection<T> GetCollection(IConfiguration config)
        {
            return GetCollectionFromConnectionString(GetDefaultConnectionString(config));
        }

        /// <summary>
        /// Creates and returns a MongoCollection from the specified type and connection string.
        /// </summary>
        /// <typeparam name="T">The type to get the collection of.</typeparam>
        /// <param name="connectionString">The connection string to use to get the collection from.</param>
        /// <returns>Returns a MongoCollection from the specified type and connection string.</returns>
        internal static IMongoCollection<T> GetCollectionFromConnectionString(string connectionString)
        {
            return GetCollectionFromConnectionString(connectionString, GetCollectionName());
        }

        /// <summary>
        /// Creates and returns a MongoCollection from the connection string name and collection name
        /// </summary>
        /// <typeparam name="T">The type to get the collection of.</typeparam>
        /// <param name="connectionString">The connection string to use to get the collection from.</param>
        /// <param name="collectionName">The name of the collection to use.</param>
        /// <returns>Returns a MongoCollection from the specified type and connection string.</returns>
        internal static IMongoCollection<T> GetCollectionFromConnectionString(string connectionString, string collectionName)
        {
            var mongoUrlBuilder = new MongoUrlBuilder(connectionString);
            var mongoUrl = mongoUrlBuilder.ToMongoUrl();
            return GetCollectionFromUrl(mongoUrl, collectionName);
        }

        /// <summary>
        /// Creates and returns a MongoCollection from the specified type and URL.
        /// </summary>
        /// <typeparam name="T">The type to get the collection of.</typeparam>
        /// <param name="url">The URL to use to get the collection from.</param>
        /// <returns>Returns a MongoCollection from the specified type and URL.</returns>
        internal static IMongoCollection<T> GetCollectionFromUrl(MongoUrl url)
        {
            return GetCollectionFromUrl(url, GetCollectionName());
        }

        /// <summary>
        /// Creates and returns a MongoCollection from the specified type and URL.
        /// </summary>
        /// <typeparam name="T">The type to get the collection of.</typeparam>
        /// <param name="url">The URL to use to get the collection from.</param>
        /// <param name="collectionName">The name of the collection to use.</param>
        /// <returns>Returns a MongoCollection from the specified type and URL.</returns>
        internal static IMongoCollection<T> GetCollectionFromUrl(MongoUrl url, string collectionName)
        {
            return GetDatabaseFromUrl(url).GetCollection<T>(collectionName);
        }

        /// <summary>
        /// Creates and returns a MongoDatabase from the specified URL.
        /// </summary>
        /// <param name="url">The URL to use to get the database from.</param>
        /// <returns>Returns a MongoDatabase from the specified URL.</returns>
        private static IMongoDatabase GetDatabaseFromUrl(MongoUrl url)
        {
            var client = new MongoClient(url);
            return client.GetDatabase(url.DatabaseName);
        }

        #region Collection Name

        /// <summary>
        /// Determines the collection name for T and assures it is not empty
        /// </summary>
        /// <typeparam name="T">The type to determine the collection name for.</typeparam>
        /// <returns>Returns the collection name for T.</returns>
        private static string GetCollectionName()
        {
            var collectionName = _entityType.GetTypeInfo().BaseType == typeof(object) ?
                                        GetCollectionNameFromInterface() :
                                        GetCollectionNameFromType();

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = typeof(T).Name;
            }
            return collectionName;
        }

        /// <summary>
        /// Determines the collection name from the specified type.
        /// </summary>
        /// <typeparam name="T">The type to get the collection name from.</typeparam>
        /// <returns>Returns the collection name from the specified type.</returns>
        private static string GetCollectionNameFromInterface()
        {
            // Check to see if the object (inherited from Entity) has a CollectionName attribute
            var att = _entityType.GetTypeInfo().GetCustomAttribute<CollectionNameAttribute>();

            return att?.Name ?? _entityType.Name;
        }

        /// <summary>
        /// Determines the collection name from the specified type.
        /// </summary>
        /// <returns>Returns the collection name from the specified type.</returns>
        private static string GetCollectionNameFromType()
        {
            // Check to see if the object (inherited from Entity) has a CollectionName attribute
            var att = _entityType.GetTypeInfo().GetCustomAttribute<CollectionNameAttribute>();

            return att != null ? att.Name : _entityType.Name;
        }

        #endregion Collection Name

        #region Connection Name

        /// <summary>
        /// Determines the connection name for T and assures it is not empty
        /// </summary>
        /// <typeparam name="T">The type to determine the connection name for.</typeparam>
        /// <returns>Returns the connection name for T.</returns>
        private static string GetConnectionName()
        {
            var connectionName = _entityType.GetTypeInfo().BaseType == typeof(object) ?
                                      GetConnectionNameFromInterface() :
                                      GetConnectionNameFromType();

            if (string.IsNullOrEmpty(connectionName))
            {
                connectionName = _entityType.Name;
            }
            return connectionName;
        }

        /// <summary>
        /// Determines the connection name from the specified type.
        /// </summary>
        /// <typeparam name="T">The type to get the connection name from.</typeparam>
        /// <returns>Returns the connection name from the specified type.</returns>
        private static string GetConnectionNameFromInterface()
        {
            // Check to see if the object (inherited from Entity) has a ConnectionName attribute
            var att = _entityType.GetTypeInfo().GetCustomAttribute<ConnectionNameAttribute>();
            return att?.Name ?? _entityType.Name;
        }

        /// <summary>
        /// Determines the connection name from the specified type.
        /// </summary>
        /// <returns>Returns the connection name from the specified type.</returns>
        private static string GetConnectionNameFromType()
        {
            string collectionname;

            // Check to see if the object (inherited from Entity) has a ConnectionName attribute
            var att = _entityType.GetTypeInfo().GetCustomAttribute<ConnectionNameAttribute>();
            if (att != null)
            {
                // Return the value specified by the ConnectionName attribute
                collectionname = att.Name;
            }
            else
            {
                if (typeof(Entity).GetTypeInfo().IsAssignableFrom(_entityType))
                {
                    // No attribute found, get the base type
                    while (_entityType.GetTypeInfo().BaseType != typeof(Entity))
                    {
                        _entityType = _entityType.GetTypeInfo().BaseType;
                    }
                }
                collectionname = _entityType?.Name;
            }

            return collectionname;
        }

        #endregion Connection Name

        #region Connection String

        /// <summary>
        /// Retrieves the default connection string from the App.config or Web.config file.
        /// </summary>
        /// <returns>Returns the default connection string from the App.config or Web.config file.</returns>
        internal static string GetDefaultConnectionString(IConfiguration config)
        {
            return config.GetConnectionString(GetConnectionName());
        }

        #endregion Connection String
    }
}