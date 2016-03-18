// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2016.03.16
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// description      : code sample to compliment http://blog.sextondjc.com/2016/03/better-unit-test-structures.html
// ============================================================================================================================= 
using System;
using System.ComponentModel.DataAnnotations;

namespace Example
{
    /// <summary>
    /// Represents a simple POCO model which is passed 
    /// to/from the <see cref="IRepository{T}"/>
    /// </summary>
    public class Model
    {
        /// <summary>
        /// A unique identifier for the model. 
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// A friendly name for the model. 
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        /// <summary>
        /// A simple nullable type for the model. 
        /// </summary>
        public int? Quantity { get; set; }
    }
}
