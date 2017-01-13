namespace MobileSAPSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrafficViolations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrafficFineModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        OffenceType = c.Int(nullable: false),
                        Reference = c.String(),
                        Legislation = c.String(),
                        Penalty = c.String(),
                        AuditDte = c.DateTime(nullable: false),
                        AuditUsr = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrafficFineModels");
        }
    }
}
