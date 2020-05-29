using IP_NTier.Common.DataAccess.EF.Configuration;
using IP_NTier.Common.DataAccess.EF.Extensions;
using IP_NTier.Domain.Entities.Modules.Security;

namespace IP_NTier.DataAccess.EF.Configuration
{
    public class UserConfiguration : DbContextBaseConfiguration<Users>
    {
        #region Ctor.
        public UserConfiguration()
            : base()
        {
            ToTable("Users");
            HasKey(e => e.Id);

            Property(p => p.UserName).HasMaxLength(256).IsRequired()
                                  .HasUniqueIndexAnnotation("UserNameIndex", 0);

            Property(p => p.Email).HasMaxLength(256).IsRequired()
                                  .HasUniqueIndexAnnotation("EmailIndex", 0);
        }
        #endregion
    }
}
