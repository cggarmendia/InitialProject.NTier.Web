using IP_NTier.Common.DataAccess.EF.Configuration;
using IP_NTier.Domain.Entities.Modules.Security;

namespace IP_NTier.DataAccess.EF.Configuration
{
    public class UserClaimsConfiguration : DbContextBaseConfiguration<UserClaims>
    {
        #region Ctor.
        public UserClaimsConfiguration()
            : base()
        {
            ToTable("UserClaims");

            HasKey(uc => uc.Id );

            HasRequired(ul => ul.Users)
                .WithMany(u => u.UserClaims)
                .HasForeignKey(ur => ur.UserId);
        }
        #endregion
    }
}
