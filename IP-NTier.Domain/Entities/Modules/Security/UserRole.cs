using System;

namespace IP_NTier.Domain.Entities.Modules.Security
{
    public class UserRole : IEntity
    {
        #region Properties
        public string UserId { get; set; }

        public string RoleId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string CreatedUser { get; set; }
        #endregion

        #region Navigation_Properties
        public virtual Roles Role { get; set; }

        public virtual Users User { get; set; }
        #endregion
    }
}
