namespace IMDB.Core.Applications.Common.CQRS.DTOs
{
    public class Result : IResult
    {
        public bool CallSuccedded
        {
            get;
            private set;
        }

        public Result()
        {
            CallSuccedded = true;
        }
    }

    public class Result<T> : IResult
    {
        public bool CallSuccedded
        {
            get;
            protected set;
        }

        public T ResultData { get; set; }

        public Result(bool callSuccedded = true)
        {
            CallSuccedded = callSuccedded;
        }

        public Result(T data)
        {
            CallSuccedded = true;
            ResultData = data;
        }
    }
}
