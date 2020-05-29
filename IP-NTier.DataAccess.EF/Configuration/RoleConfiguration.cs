using IP_NTier.Common.DataAccess.EF.Configuration;
using IP_NTier.Common.DataAccess.EF.Extensions;
using IP_NTier.Domain.Entities.Modules.Security;

namespace IP_NTier.DataAccess.EF.Configuration
{
    public class RoleConfiguration : DbContextBaseConfiguration<Roles>
    {
        #region Ctor.
        public RoleConfiguration()
            : base()
        {
            ToTable("Roles");
            HasKey(e => e.Id);

            Property(p => p.Name).HasMaxLength(256).IsRequired()
                                  .HasUniqueIndexAnnotation("RoleNameIndex", 0);
        }
        #endregion
    }
}
