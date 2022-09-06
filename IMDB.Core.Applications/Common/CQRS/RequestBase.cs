
namespace IMDB.Core.Applications.Common.CQRS
{
    public abstract class RequestBase
    {
        public Enums.Languages Language { get; set; }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
