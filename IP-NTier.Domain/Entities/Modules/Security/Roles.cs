using System.Collections.Generic;

namespace IP_NTier.Domain.Entities.Modules.Security
{
    public class Roles : IEntity
    {
        #region Ctor.
        public Roles()
        {
            UserRole = new HashSet<UserRole>();
        }
        #endregion

        #region Properties
        public string Id { get; set; }

        public string Name { get; set; }
        #endregion
        
        #region Navigation_Properties
        public virtual ICollection<UserRole> UserRole { get; set; }
        #endregion
    }
}
