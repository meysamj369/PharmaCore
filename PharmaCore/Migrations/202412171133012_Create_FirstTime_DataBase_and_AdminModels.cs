namespace PharmaCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_FirstTime_DataBase_and_AdminModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentTitle = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Tbl_Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Family = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        RePassword = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Tbl_Department", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Tbl_Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleTitle = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Tbl_UserAccessModual",
                c => new
                    {
                        UserAccessModuleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ModualId = c.Int(nullable: false),
                        CanEnter = c.Boolean(),
                    })
                .PrimaryKey(t => t.UserAccessModuleId)
                .ForeignKey("dbo.Tbl_Modual", t => t.ModualId)
                .ForeignKey("dbo.Tbl_Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ModualId);
            
            CreateTable(
                "dbo.Tbl_Modual",
                c => new
                    {
                        ModualId = c.Int(nullable: false, identity: true),
                        ModualName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ModualId);
            
            CreateTable(
                "dbo.Tbl_Section",
                c => new
                    {
                        SectionCode = c.String(nullable: false, maxLength: 50),
                        SectionId = c.Int(nullable: false, identity: true),
                        ModualId = c.Int(nullable: false),
                        SectionName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SectionCode)
                .ForeignKey("dbo.Tbl_Modual", t => t.ModualId, cascadeDelete: true)
                .Index(t => t.ModualId);
            
            CreateTable(
                "dbo.Tbl_UserAccessModualSection",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ModualId = c.Int(nullable: false),
                        SectionCode = c.String(nullable: false, maxLength: 50),
                        UserAccessModulaSectionId = c.Int(nullable: false, identity: true),
                        CanEnter = c.Boolean(),
                        CanRead = c.Boolean(),
                        CanCreate = c.Boolean(),
                        CanEdit = c.Boolean(),
                        CanDelete = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.UserId, t.ModualId, t.SectionCode })
                .ForeignKey("dbo.Tbl_Modual", t => t.ModualId)
                .ForeignKey("dbo.Tbl_Section", t => t.SectionCode)
                .ForeignKey("dbo.Tbl_Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ModualId)
                .Index(t => t.SectionCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tbl_UserAccessModual", "UserId", "dbo.Tbl_Users");
            DropForeignKey("dbo.Tbl_UserAccessModual", "ModualId", "dbo.Tbl_Modual");
            DropForeignKey("dbo.Tbl_UserAccessModualSection", "UserId", "dbo.Tbl_Users");
            DropForeignKey("dbo.Tbl_UserAccessModualSection", "SectionCode", "dbo.Tbl_Section");
            DropForeignKey("dbo.Tbl_UserAccessModualSection", "ModualId", "dbo.Tbl_Modual");
            DropForeignKey("dbo.Tbl_Section", "ModualId", "dbo.Tbl_Modual");
            DropForeignKey("dbo.Tbl_Users", "RoleId", "dbo.Tbl_Role");
            DropForeignKey("dbo.Tbl_Users", "DepartmentId", "dbo.Tbl_Department");
            DropIndex("dbo.Tbl_UserAccessModualSection", new[] { "SectionCode" });
            DropIndex("dbo.Tbl_UserAccessModualSection", new[] { "ModualId" });
            DropIndex("dbo.Tbl_UserAccessModualSection", new[] { "UserId" });
            DropIndex("dbo.Tbl_Section", new[] { "ModualId" });
            DropIndex("dbo.Tbl_UserAccessModual", new[] { "ModualId" });
            DropIndex("dbo.Tbl_UserAccessModual", new[] { "UserId" });
            DropIndex("dbo.Tbl_Users", new[] { "RoleId" });
            DropIndex("dbo.Tbl_Users", new[] { "DepartmentId" });
            DropTable("dbo.Tbl_UserAccessModualSection");
            DropTable("dbo.Tbl_Section");
            DropTable("dbo.Tbl_Modual");
            DropTable("dbo.Tbl_UserAccessModual");
            DropTable("dbo.Tbl_Role");
            DropTable("dbo.Tbl_Users");
            DropTable("dbo.Tbl_Department");
        }
    }
}
