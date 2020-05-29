namespace IP_NTier.Domain.Entities.Modules.Security
{
    public class UserLogins : IEntity
    {
        #region Properties
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
        #endregion

        #region Navigation_Properties
        public virtual Users Users { get; set; }
        #endregion
    }
}
