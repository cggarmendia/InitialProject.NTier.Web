using IP_NTier.Common.DataAccess.EF.Configuration;
using IP_NTier.Domain.Entities.Modules.Security;

namespace IP_NTier.DataAccess.EF.Configuration
{
    public class UserLoginsConfiguration : DbContextBaseConfiguration<UserLogins>
    {
        #region Ctor.
        public UserLoginsConfiguration()
            : base()
        {
            ToTable("UserLogins");

            HasKey(ul => new { ul.LoginProvider, ul.ProviderKey, ul.UserId });

            HasRequired(ul => ul.Users)
                .WithMany(u => u.UserLogins)
                .HasForeignKey(ur => ur.UserId);
        }
        #endregion
    }
}
