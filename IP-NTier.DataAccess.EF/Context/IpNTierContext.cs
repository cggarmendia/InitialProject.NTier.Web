using System;
using System.Data.Entity.ModelConfiguration;
using IP_NTier.Common.DataAccess.EF.Context;
using IP_NTier.Domain.Entities.Modules.Security;

namespace IP_NTier.DataAccess.EF.Context
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Linq;
    using Common.DataAccess.EF.Configuration;

    public class IpNTierContext : DBContextBase
    {
        public IpNTierContext()
            : base("name=IpNTierContext")
        {

        }

        #region Security
        public virtual DbSet<Roles> Role { get; set; }
        public virtual DbSet<Users> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserClaims> UserClaims { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Carga todas las EntityTypeConfiguration por reflection.
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                               type != typeof(DbContextBaseConfiguration<>) &&
                               (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>) ||
                                type.BaseType.GetGenericTypeDefinition() == typeof(DbContextBaseConfiguration<>) ) );

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic)configurationInstance);
            }

        }
    }
}