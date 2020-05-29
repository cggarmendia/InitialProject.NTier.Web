using System.Linq;

namespace IP_NTier.DataAccess.EF.Migrations
{
    using System.Data.Entity.Migrations;
    using Context;

    public sealed class IpNTierConfiguration : DbMigrationsConfiguration<IpNTierContext>
    {
        public IpNTierConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IpNTierContext context)
        {
            if (!context.Role.Any())
            {
                //ToDo: initial_data
            }
           
        }
    }
}
