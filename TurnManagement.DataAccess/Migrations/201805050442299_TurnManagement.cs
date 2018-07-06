namespace TurnManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TurnManagement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Professional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        SurName = c.String(nullable: false, maxLength: 256),
                        Dni = c.String(maxLength: 8),
                        Genre = c.String(),
                        RegistrationNumber = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(),
                        CellPhone = c.String(maxLength: 25),
                        Phone = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Professional_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professional", t => t.Professional_Id)
                .Index(t => t.Professional_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specialty", "Professional_Id", "dbo.Professional");
            DropIndex("dbo.Specialty", new[] { "Professional_Id" });
            DropTable("dbo.Specialty");
            DropTable("dbo.Professional");
            DropTable("dbo.ApplicationUser");
        }
    }
}
