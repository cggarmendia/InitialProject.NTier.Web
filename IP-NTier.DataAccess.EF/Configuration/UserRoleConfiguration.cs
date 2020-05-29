using IP_NTier.Common.DataAccess.EF.Configuration;
using IP_NTier.Domain.Entities.Modules.Security;

namespace IP_NTier.DataAccess.EF.Configuration
{
    public class UserRoleConfiguration : DbContextBaseConfiguration<UserRole>
    {
        #region Ctor.
        public UserRoleConfiguration()
            : base()
        {
            ToTable("UserRoles");

            HasKey(ur => new {ur.UserId, ur.RoleId });

            HasRequired(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            HasRequired(ur => ur.Role)
                .WithMany(u => u.UserRole)
                .HasForeignKey(ur => ur.RoleId);

            Property(p => p.CreatedUser).HasMaxLength(128)
                                        .IsRequired();
        }
        #endregion
    }
}
