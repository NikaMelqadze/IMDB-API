using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace IMDB.Core.Applications.Common.Exceptions
{
    public class ValidationException : ExceptionBase
    {
        public ValidationException(string message = "VALIDATION_ERRORS")
            : base(message)
        {
            Errors = new Dictionary<string, List<string>>();
        }

        public ValidationException(string message, IDictionary<string, List<string>> errors)
            : base(message)
        {
            Errors = errors ?? new Dictionary<string, List<string>>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToList());
        }

        public IDictionary<string, List<string>> Errors { get; }
    }
}
