namespace IP_NTier.Domain.Entities.Modules.Security
{
    public class UserClaims : IEntity
    {
        #region Properties
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        #endregion

        #region Navigation_Properties
        public virtual Users Users { get; set; }
        #endregion
    }
}
