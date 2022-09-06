namespace IMDB.Core.Applications.Common.Exceptions
{
    public class ExceptionBase : System.Exception
    {
        public string Code { get; private set; }

        public ExceptionBase(string code, System.Exception innerException = null) : base(code, innerException)
        {
            Code = code;
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
