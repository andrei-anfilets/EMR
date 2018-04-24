namespace EMR.DAL2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.RolePrivileges",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AppRole_Id = c.String(maxLength: 128),
                        Privilege_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetRoles", t => t.AppRole_Id)
                .ForeignKey("dbo.Privileges", t => t.Privilege_Id)
                .Index(t => t.AppRole_Id)
                .Index(t => t.Privilege_Id);
            
            CreateTable(
                "dbo.Privileges",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ActionName = c.String(),
                        ActionCode = c.Int(nullable: false),
                        Menu_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        ParentId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        color = c.String(),
                        CrmPerson_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CrmPersons", t => t.CrmPerson_id)
                .Index(t => t.CrmPerson_id);
            
            CreateTable(
                "dbo.CrmPersons",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 200),
                        phone = c.String(maxLength: 200),
                        email = c.String(maxLength: 200),
                        sex = c.String(maxLength: 20),
                        sex_id = c.Int(nullable: false),
                        discount = c.Int(nullable: false),
                        importance_id = c.Int(nullable: false),
                        importance = c.String(maxLength: 200),
                        card = c.String(maxLength: 200),
                        birth_date = c.String(maxLength: 30),
                        comment = c.String(maxLength: 1000),
                        sms_check = c.Int(nullable: false),
                        sms_not = c.Int(nullable: false),
                        spent = c.Int(nullable: false),
                        paid = c.Int(nullable: false),
                        balance = c.Int(nullable: false),
                        visits = c.Int(nullable: false),
                        Person_Id = c.Long(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BithDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Name = c.String(maxLength: 300),
                        Role_Id = c.String(maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetRoles", t => t.Role_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Klass",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(maxLength: 200),
                        Name2 = c.String(maxLength: 200),
                        Name3 = c.String(maxLength: 200),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUsers", "Role_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.CrmPersons", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Categories", "CrmPerson_id", "dbo.CrmPersons");
            DropForeignKey("dbo.RolePrivileges", "Privilege_Id", "dbo.Privileges");
            DropForeignKey("dbo.Privileges", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.Menus", "ParentId", "dbo.Menus");
            DropForeignKey("dbo.RolePrivileges", "AppRole_Id", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Role_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CrmPersons", new[] { "Person_Id" });
            DropIndex("dbo.Categories", new[] { "CrmPerson_id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Menus", new[] { "ParentId" });
            DropIndex("dbo.Privileges", new[] { "Menu_Id" });
            DropIndex("dbo.RolePrivileges", new[] { "Privilege_Id" });
            DropIndex("dbo.RolePrivileges", new[] { "AppRole_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.Klass");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.People");
            DropTable("dbo.CrmPersons");
            DropTable("dbo.Categories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Menus");
            DropTable("dbo.Privileges");
            DropTable("dbo.RolePrivileges");
            DropTable("dbo.AspNetRoles");
        }
    }
}
