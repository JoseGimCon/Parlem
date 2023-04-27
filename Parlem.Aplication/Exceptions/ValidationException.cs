using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parlem.Aplication.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() :base("Errores de validaciones")
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }

        public ValidationException(IEnumerable<ValidationFailure> failures)
        {
            if(failures.Any())
            {
                Errors = failures.Select(f => f.ErrorMessage).ToList();
            }
        }

    }
}
