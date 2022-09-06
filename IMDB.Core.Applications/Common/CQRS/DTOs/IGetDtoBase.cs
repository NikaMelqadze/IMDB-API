namespace IMDB.Core.Applications.Common.CQRS.DTOs
{
    public interface IGetDtoBase
    {
        public int Id { get; set; }
    }

    public abstract class GetDtoBase<T> : IGetDtoBase, Mappings.IMapFrom<T>
       where T : Domains.Common.BaseEntity
    {
        public int Id { get; set; }
    }
}
