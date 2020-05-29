using IP_NTier.Business.DomainServices.Modules.Security;
using IP_NTier.Domain.Entities.Modules.Security;

namespace IP_NTier.Business.DomainServices.Mapper
{
    internal class DomainServicesMapper
    {
        #region User - UserDto
        internal static UserDto MapToUserDto(Users domain)
        {
            var dto = new UserDto();
            if (domain != null)
                dto = new UserDto()
                {
                    Email = domain.Email,
                    Id = domain.Id,
                    PhoneNumber = domain.PhoneNumber,
                    UserName = domain.UserName
                };
            return dto;
        }

        internal static void MapToUser(UserDto dto, Users domain = null)
        {
            if (domain == null)
                domain = new Users();

            domain.Email = dto.Email;
            domain.EmailConfirmed = dto.EmailConfirmed;
            domain.PhoneNumber = dto.PhoneNumber;
            domain.UserName = dto.UserName;
            domain.PasswordHash = dto.PasswordHash;
            domain.PhoneNumberConfirmed = dto.PhoneNumberConfirmed;
        }
        #endregion

        #region Role - RoleDto
        internal static RoleDto MapToRoleDto(Roles domain)
        {
            var dto = new RoleDto();
            if (domain != null)
                dto = new RoleDto()
                {
                    Name = domain.Name,
                    Id = domain.Id
                };
            return dto;
        }

        internal static void MapToRole(RoleDto dto, Roles domain = null)
        {
            if (domain == null)
                domain = new Roles();

            domain.Name = dto.Name;
        }
        #endregion
    }
}
