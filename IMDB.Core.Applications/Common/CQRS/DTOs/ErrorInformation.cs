using System.Collections.Generic;

namespace IMDB.Core.Applications.Common.CQRS.DTOs
{
    public class ErrorInformation
    {
        public string ErrorMessage { get; private set; }
        public IDictionary<string, List<string>> Errors { get; private set; }

        public ErrorInformation(string message, IDictionary<string, List<string>> errors = null)
        {
            ErrorMessage = message;
            Errors = errors;
        }
    }
}
