// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2016.03.16
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// description      : code sample to compliment http://blog.sextondjc.com/2016/03/better-unit-test-structures.html
// ============================================================================================================================= 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static System.ComponentModel.DataAnnotations.Validator;

namespace Example
{
    public sealed class Validator
    {
        public static void Validate<T>(T item)
        {
            var context = new ValidationContext(item, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = TryValidateObject(
                item,
                context,
                results,
                validateAllProperties: true
            );

            if (!isValid)
            {
                // build up the validation error message. 
                var builder = new StringBuilder();
                builder.Append("Validation errors were encountered. Please correct the list of errors below. ");

                foreach (var result in results)
                {
                    builder.Append($"{result.ErrorMessage}\r\n");
                }

                throw new ValidationException(builder.ToString());
            }
        }
    }
}
