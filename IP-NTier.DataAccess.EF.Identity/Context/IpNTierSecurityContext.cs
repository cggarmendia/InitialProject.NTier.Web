using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using IP_NTier.DataAccess.EF.Identity.Entities;

namespace IP_NTier.DataAccess.EF.Identity.Context
{
    public class IpNTierSecurityContext : IdentityDbContext<SecurityUser>
    {
        public IpNTierSecurityContext()
            : base("name=IpNTierContext")
        {
        }

        public static IpNTierSecurityContext Create()
        {
            return new IpNTierSecurityContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<SecurityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
