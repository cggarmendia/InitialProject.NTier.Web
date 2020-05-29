using IP_NTier.Domain.Entities;
using IP_NTier.Domain.Entities.Modules.Security;

namespace IP_NTier.Domain.SecurityServices
{
    public interface IAuthenticationService
    {
        Users AuthenticateUser(string username, string password);
    }
}
