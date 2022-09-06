namespace IMDB.Core.Applications.Common.CQRS.DTOs
{
    public interface ICreateDtoBase
    {
    }

    public interface CreateDtoBase<T> : ICreateDtoBase, Mappings.IMapTo<T>
        where T : Domains.Common.BaseEntity
    {
    }

}

