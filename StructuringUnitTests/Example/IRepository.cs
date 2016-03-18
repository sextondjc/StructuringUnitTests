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
    public interface IRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// Represents a persistence operation which saves a new 
        /// instance of the model to the underlying data store. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        T Create<T>(T model);

        /// <summary>
        /// Represents a persistence operation which updates
        /// an existing instance of the model on underlying 
        /// data store. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        T Update<T>(T model);

        /// <summary>
        /// Represents a delete operation where an existing 
        /// instance of the model is removed from the underlying 
        /// data store. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        T Delete<T>(T model);

        /// <summary>
        /// Retrieves a single instance of the model from the 
        /// underlying data store.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The unique identifier of the object. </param>
        /// <returns></returns>
        T Retrieve<T>(Guid id);

        /// <summary>
        /// Returns a collection of all instances of the model
        /// from the underlying data store. 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> RetrieveAll();
    }
}
