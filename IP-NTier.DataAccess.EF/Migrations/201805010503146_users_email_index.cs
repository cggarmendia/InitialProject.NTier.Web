namespace IP_NTier.DataAccess.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users_email_index : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 256));
            CreateIndex("dbo.Users", "Email", unique: true, name: "EmailIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "EmailIndex");
            AlterColumn("dbo.Users", "Email", c => c.String());
        }
    }
}
