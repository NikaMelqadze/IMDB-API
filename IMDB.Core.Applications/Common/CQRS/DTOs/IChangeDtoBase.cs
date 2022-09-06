namespace IMDB.Core.Applications.Common.CQRS.DTOs
{
    public interface IChangeDtoBase
    {
        public int Id { get; set; }
    }

    public interface ChangeDtoBase<T> : IChangeDtoBase, Mappings.IMapTo<T>
        where T : Domains.Common.BaseEntity
    {
    }
}