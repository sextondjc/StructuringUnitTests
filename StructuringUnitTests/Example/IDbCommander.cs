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
    /// A simple interface which represents a CQRS-esque implementation
    /// against an underlying data store. Used for demonstration purposes 
    /// only.
    /// </summary>
    public interface IDbCommander : IDisposable
    {
        /// <summary>
        /// Performs create/update/delete operations.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Command<T>(T model);

        /// <summary>
        /// Returns a single instance of an object. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Query<T>(Guid id);

        /// <summary>
        /// Returns a collection of {T}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> Query<T>();
    }
}