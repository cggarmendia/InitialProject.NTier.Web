using System;
using IP_NTier.Domain.Entities;
using IP_NTier.Domain.Entities.Modules.Security;
using IP_NTier.Domain.SecurityServices;

namespace IP_NTier.DataAccess.EF.SecurityServices
{
    public class AuthenticationServices : IAuthenticationService
    {
        public Users AuthenticateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
