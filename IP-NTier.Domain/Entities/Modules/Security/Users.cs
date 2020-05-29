using System;
using System.Collections.Generic;

namespace IP_NTier.Domain.Entities.Modules.Security
{
    public class Users : IEntity
    {
        #region Ctor.
        public Users()
        {
            Id = Guid.NewGuid().ToString();
            UserClaims = new HashSet<UserClaims>();
            UserLogins = new HashSet<UserLogins>();
            UserRoles = new HashSet<UserRole>();
        }
        #endregion

        #region Properties
        public string Id { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public string UserName { get; set; }
        #endregion

        #region Navigation_Properties
        public virtual ICollection<UserClaims> UserClaims { get; set; }

        public virtual ICollection<UserLogins> UserLogins { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}
