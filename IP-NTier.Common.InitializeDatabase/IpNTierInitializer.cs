using System.Data.Entity;
using IP_NTier.DataAccess.EF.Context;
using IP_NTier.DataAccess.EF.Migrations;

namespace IP_NTier.Common.InitializeDatabase
{
    public interface IIpNTierInitializer
    {
        void InitializeDatabase();
    }

    public class IpNTierInitializer : IIpNTierInitializer
    {
        public void InitializeDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<IpNTierContext, IpNTierConfiguration>());
        }
    }
}
