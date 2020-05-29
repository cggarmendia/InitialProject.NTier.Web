using System.Data.Entity;
using IP_NTier.DataAccess.EF.Identity.Context;

namespace IP_NTier.Common.InitializeDatabase
{
    public interface IIpNTierSecurityInitializer
    {
        void InitializeDatabase();
    }

    public class IpNTierSecurityInitializer : IIpNTierSecurityInitializer
    {
        public void InitializeDatabase()
        {
            using (var context = new IpNTierSecurityContext())
            {
                if (!context.Database.Exists())
                    context.Database.CreateIfNotExists();
            }
        }
    }
}
