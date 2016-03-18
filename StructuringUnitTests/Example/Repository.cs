// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2016.03.16
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// description      : code sample to compliment http://blog.sextondjc.com/2016/03/better-unit-test-structures.html
// ============================================================================================================================= 
using System;
using System.Collections.Generic;

namespace Example
{
    /// <summary>
    /// Simple generic repository for demonstration purposes only.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Repository<T> : IRepository<T> where T : class
    {
        // A simple interface which represents a CQRS-esque implementation
        // against an underlying data store. Used for demonstration purposes 
        // only.
        private readonly IDbCommander _commander;

        /// <summary>
        /// Creates a new instance of the repository, using DI
        /// to inject a dependency on <see cref="IDbCommander"/>
        /// </summary>
        /// <param name="commander"></param>
        public Repository(IDbCommander commander)
        {
            _commander = commander;
        }

        /// <summary>
        /// Represents a persistence operation which saves a new 
        /// instance of the model to the underlying data store. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public T Create<T>(T model)
        {
            Validator.Validate(model);
            return _commander.Command<T>(model) ? model : default(T);
        }

        /// <summary>
        /// Represents a persistence operation which updates
        /// an existing instance of the model on underlying 
        /// data store. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public T Update<T>(T model)
        {
            Validator.Validate(model);
            return _commander.Command<T>(model) ? model : default(T);
        }

        /// <summary>
        /// Represents a delete operation where an existing 
        /// instance of the model is removed from the underlying 
        /// data store. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public T Delete<T>(T model) 
            => _commander.Command<T>(model) ? model : default(T);

        /// <summary>
        /// Retrieves a single instance of the model from the 
        /// underlying data store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The unique identifier of the object. </param>
        public T Retrieve<T>(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentException("An empty GUID is not allowed.");
            }
            return _commander.Query<T>(id);
        }

        /// <summary>
        /// Returns a collection of all instances of the model
        /// from the underlying data store. 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> RetrieveAll() => _commander.Query<T>();

        public void Dispose()
        {            
        }
    }
}
