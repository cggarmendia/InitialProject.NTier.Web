using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IP_NTier.Business.DomainServices.Mapper;
using IP_NTier.Common.DomainServices;
using IP_NTier.Domain.Entities.Modules.Security;

namespace IP_NTier.Business.DomainServices.Modules.Security
{
    public interface IRoleDomainServices : IDtoDomainService<RoleDto>
    {
        RoleDto GetByName(string name);
    }

    public class RoleDomainServices : DomainServiceBase<Roles>, IRoleDomainServices
    {
        #region Public_Methods

        public RoleDto GetByName(string name)
        {
            return GetDtoByFilters(r => r.Name.Equals(name));
        }

        public RoleDto GetByIds(params object[] ids)
        {
            var domain = repository.GetByPKs(ids);
            return DomainServicesMapper.MapToRoleDto(domain);
        }

        public void Add(RoleDto dto)
        {
            var domain = new Roles();
            DomainServicesMapper.MapToRole(dto, domain);
            repository.Add(domain);
        }

        public void Update(RoleDto dto)
        {
            var domain = repository.GetByPKs(dto.Id);
            DomainServicesMapper.MapToRole(dto, domain);
            repository.Update(domain);
        }

        public void Delete(RoleDto dto)
        {
            var domain = repository.GetByPKs(dto.Id);
            repository.Delete(domain);
        }

        public IEnumerable<RoleDto> GetAll()
        {
            return repository.GetAll().Select(DomainServicesMapper.MapToRoleDto).ToList();
        }

        #endregion

        #region Private_Methods
        private RoleDto GetDtoByFilters(
            Expression<Func<Roles, bool>> filter = null,
            Func<IQueryable<Roles>, IOrderedQueryable<Roles>> orderBy = null,
            string includeProperties = null)
        {
            var domain = GetByFilters(filter, orderBy, includeProperties).SingleOrDefault();
            return DomainServicesMapper.MapToRoleDto(domain);
        }
        #endregion
    }

    #region Dtos.

    public class RoleDto : DtoBase
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    #endregion
}
