using System.Collections.Generic;

namespace IP_NTier.Common.DomainServices
{
    public interface IDtoDomainService<TDto>
      where TDto : DtoBase
    {
        TDto GetByIds(params object[] Ids);

        void Add(TDto dto);

        void Update(TDto dto);

        void Delete(TDto dto);

        IEnumerable<TDto> GetAll();
    }
}
