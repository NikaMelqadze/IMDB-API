namespace IMDB.Core.Applications.Common.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public NotFoundException(string message = "ITEM_NOT_FOUND") : base(message) { }
    }
}
