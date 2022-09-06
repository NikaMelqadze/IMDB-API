using System.Collections.Generic;

namespace IMDB.Core.Applications.Common.CQRS.DTOs
{
    public class FailedResult : Result<ErrorInformation>, IResult
    {
        public FailedResult(string message, IDictionary<string, List<string>> errors = null) : base(false)
        {
            ResultData = new ErrorInformation(message, errors);
        }
    }
}
