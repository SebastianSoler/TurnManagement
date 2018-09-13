namespace TurnManagement.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        SurnName = c.String(nullable: false, maxLength: 256),
                        Dni = c.String(nullable: false, maxLength: 10),
                        Genre = c.String(nullable: false, maxLength: 10),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 200),
                        HealthInsurance = c.String(maxLength: 60),
                        Plan = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        CellPhone = c.String(maxLength: 30),
                        Phone = c.String(maxLength: 30),
                        Note = c.String(maxLength: 256),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Turn",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfessionalId = c.Int(nullable: false),
                        SpecialityId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        Discount = c.Double(nullable: false),
                        Ammount = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professional", t => t.ProfessionalId)
                .ForeignKey("dbo.Speciality", t => t.SpecialityId)
                .ForeignKey("dbo.Patient", t => t.Patient_Id)
                .Index(t => t.ProfessionalId)
                .Index(t => t.SpecialityId)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Professional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        SurnName = c.String(nullable: false, maxLength: 256),
                        Dni = c.String(maxLength: 10),
                        Genre = c.String(nullable: false, maxLength: 10),
                        RegistrationNumber = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 200),
                        Email = c.String(nullable: false),
                        CellPhone = c.String(maxLength: 30),
                        Phone = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Speciality",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        Professional_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professional", t => t.Professional_Id)
                .Index(t => t.Professional_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Turn", "Patient_Id", "dbo.Patient");
            DropForeignKey("dbo.Turn", "SpecialityId", "dbo.Speciality");
            DropForeignKey("dbo.Turn", "ProfessionalId", "dbo.Professional");
            DropForeignKey("dbo.Speciality", "Professional_Id", "dbo.Professional");
            DropIndex("dbo.Speciality", new[] { "Professional_Id" });
            DropIndex("dbo.Turn", new[] { "Patient_Id" });
            DropIndex("dbo.Turn", new[] { "SpecialityId" });
            DropIndex("dbo.Turn", new[] { "ProfessionalId" });
            DropTable("dbo.Speciality");
            DropTable("dbo.Professional");
            DropTable("dbo.Turn");
            DropTable("dbo.Patient");
            DropTable("dbo.ApplicationUser");
        }
    }
}
