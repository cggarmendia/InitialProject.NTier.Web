using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IP_NTier.Business.DomainServices.Mapper;
using IP_NTier.Common.DomainServices;
using IP_NTier.Domain.Entities.Modules.Security;

namespace IP_NTier.Business.DomainServices.Modules.Security
{
    public interface IUserDomainServices : IDtoDomainService<UserDto>
    {
        UserDto GetByEmail(string email);
        UserDto GetByUserName(string userName);
    }

    public class UserDomainServices : DomainServiceBase<Users>, IUserDomainServices
    {
        #region Public_Methods

        public UserDto GetByEmail(string email)
        {
            return GetDtoByFilters(u => u.Email.Equals(email));
        }

        public UserDto GetByUserName(string userName)
        {
            return GetDtoByFilters(u => u.UserName.Equals(userName));
        }

        public UserDto GetByIds(params object[] ids)
        {
            var domain = repository.GetByPKs(ids);
            return DomainServicesMapper.MapToUserDto(domain);
        }

        public void Add(UserDto dto)
        {
            var domain = new Users();
            DomainServicesMapper.MapToUser(dto, domain);
            repository.Add(domain);
        }

        public void Update(UserDto dto)
        {
            var domain = repository.GetByPKs(dto.Id);
            DomainServicesMapper.MapToUser(dto, domain);
            repository.Update(domain);
        }

        public void Delete(UserDto dto)
        {
            var domain = repository.GetByPKs(dto.Id);
            repository.Delete(domain);
        }

        public IEnumerable<UserDto> GetAll()
        {
            return repository.GetAll().Select(DomainServicesMapper.MapToUserDto).ToList();
        }

        #endregion

        #region Private_Methods
        private UserDto GetDtoByFilters(
            Expression<Func<Users, bool>> filter = null,
            Func<IQueryable<Users>, IOrderedQueryable<Users>> orderBy = null,
            string includeProperties = null)
        {
            var domain = GetByFilters(filter, orderBy, includeProperties).SingleOrDefault();
            return DomainServicesMapper.MapToUserDto(domain);
        }
        #endregion
    }

    #region Dtos.

    public class UserDto : DtoBase
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string UserName { get; set; }
    }

    #endregion
}
