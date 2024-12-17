using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PharmaCore.Models
{
    public class AdminContext : DbContext
    {


     
            public AdminContext() : base("PharmaCoreDBContext")
            {
            }

            public DbSet<User> Users { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<Department> Departments { get; set; }
            public DbSet<Modual> Moduals { get; set; }
            public DbSet<Section> Sections { get; set; }
            public DbSet<UserAccessModual> UserAccessModuals { get; set; }
            public DbSet<UserAccessModualSection> UserAccessModualSections { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                // تنظیمات Fluent API

                #region User Table

                modelBuilder.Entity<User>()
                    .HasKey(u => u.UserId)
                    .Property(u => u.Name)
                    .HasMaxLength(50);

            modelBuilder.Entity<User>()
                    .Property(u => u.Family)
                    .IsRequired()
                    .HasMaxLength(50);

                modelBuilder.Entity<User>()
                    .Property(u => u.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                modelBuilder.Entity<User>()
                    .Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                modelBuilder.Entity<User>()
                    .Property(u => u.RePassword)
                    .IsRequired()
                    .HasMaxLength(50);

                modelBuilder.Entity<User>()
                    .Property(u => u.Active)
                    .IsRequired();

                modelBuilder.Entity<User>()
                    .Property(u => u.RegDate)
                    .IsRequired();

                modelBuilder.Entity<User>()
                    .Property(u => u.RoleId)
                    .IsRequired();

                modelBuilder.Entity<User>()
                    .Property(u => u.DepartmentId)
                    .IsRequired();

                modelBuilder.Entity<User>()
                    .HasRequired(u => u.Department)
                    .WithMany(d => d.Users)
                    .HasForeignKey(u => u.DepartmentId);

                modelBuilder.Entity<User>()
                    .HasRequired(u => u.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(u => u.RoleId);

                modelBuilder.Entity<User>()
                    .ToTable("Tbl_Users");

                #endregion

                #region Role Table

                modelBuilder.Entity<Role>()
                    .HasKey(r => r.RoleId);

                modelBuilder.Entity<Role>()
                    .Property(r => r.RoleTitle)
                    .HasMaxLength(50);

                modelBuilder.Entity<Role>()
                    .ToTable("Tbl_Role");

                #endregion

                #region Department Table

                modelBuilder.Entity<Department>()
                    .HasKey(d => d.DepartmentId);

                modelBuilder.Entity<Department>()
                    .Property(d => d.DepartmentTitle)
                    .HasMaxLength(50);

                modelBuilder.Entity<Department>()
                    .ToTable("Tbl_Department");

                #endregion

                #region Modual Table

                modelBuilder.Entity<Modual>()
                    .HasKey(m => m.ModualId);

                modelBuilder.Entity<Modual>()
                    .Property(m => m.ModualName)
                    .HasMaxLength(50);

                modelBuilder.Entity<Modual>()
                    .ToTable("Tbl_Modual");

            #endregion

            #region Section Table

            modelBuilder.Entity<Section>()
            .HasKey(s => s.SectionCode); // تعریف SectionCode به عنوان کلید اصلی

            modelBuilder.Entity<Section>()
                .Property(s => s.SectionCode)
                .HasMaxLength(50) // طول ستون
                .IsRequired();    // مقدار اجباری

            modelBuilder.Entity<Section>()
                .Property(s => s.SectionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // مقدار خودکار (Identity)

            modelBuilder.Entity<Section>()
                .Property(s => s.SectionName)
                .HasMaxLength(50) // طول ستون
                .IsRequired();    // مقدار اجباری

            modelBuilder.Entity<Section>()
                .Property(s => s.ModualId)
                .IsRequired();    // مقدار اجباری

            modelBuilder.Entity<Section>()
                .HasRequired(s => s.Modual)
                .WithMany(m => m.Sections)
                .HasForeignKey(s => s.ModualId); // تعریف رابطه با ModualId

            modelBuilder.Entity<Section>()
                .ToTable("Tbl_Section"); // نام جدول در پایگاه داده


            #endregion

            #region UserAccessModual Table

            modelBuilder.Entity<UserAccessModual>()
                    .HasKey(uam => uam.UserAccessModuleId);

                modelBuilder.Entity<UserAccessModual>()
                    .Property(uam => uam.UserId)
                    .IsRequired();

                modelBuilder.Entity<UserAccessModual>()
                    .Property(uam => uam.ModualId)
                    .IsRequired();

                modelBuilder.Entity<UserAccessModual>()
                    .Property(uam => uam.CanEnter);

                modelBuilder.Entity<UserAccessModual>()
                    .HasRequired(uam => uam.User)
                    .WithMany(u => u.UserAccessModuals)
                    .HasForeignKey(uam => uam.UserId)
                    .WillCascadeOnDelete(false);

                modelBuilder.Entity<UserAccessModual>()
                    .HasRequired(uam => uam.Modual)
                    .WithMany(m => m.UserAccessModuals)
                    .HasForeignKey(uam => uam.ModualId)
                    .WillCascadeOnDelete(false);

                modelBuilder.Entity<UserAccessModual>()
                    .ToTable("Tbl_UserAccessModual");

            #endregion
                     
            #region UserAccessModualSection Table

            modelBuilder.Entity<UserAccessModualSection>()
                .HasKey(uams => new { uams.UserId, uams.ModualId, uams.SectionCode }); // تعریف کلید ترکیبی

            modelBuilder.Entity<UserAccessModualSection>()
                .Property(uams => uams.UserAccessModulaSectionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // مقدار Auto Increment برای این ستون

            modelBuilder.Entity<UserAccessModualSection>()
                .Property(uams => uams.UserId)
                .IsRequired();

            modelBuilder.Entity<UserAccessModualSection>()
                .Property(uams => uams.ModualId)
                .IsRequired();

            modelBuilder.Entity<UserAccessModualSection>()
                .Property(uams => uams.SectionCode)
                .IsRequired();

            modelBuilder.Entity<UserAccessModualSection>()
                .Property(uams => uams.CanEnter);

            modelBuilder.Entity<UserAccessModualSection>()
                .Property(uams => uams.CanRead);

            modelBuilder.Entity<UserAccessModualSection>()
                .Property(uams => uams.CanEdit);

            modelBuilder.Entity<UserAccessModualSection>()
                .Property(uams => uams.CanDelete);

            modelBuilder.Entity<UserAccessModualSection>()
                .Property(uams => uams.CanCreate);

            modelBuilder.Entity<UserAccessModualSection>()
                .HasRequired(uams => uams.User)
                .WithMany(u => u.UserAccessModualSections)
                .HasForeignKey(uams => uams.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAccessModualSection>()
                .HasRequired(uams => uams.Modual)
                .WithMany(m => m.UserAccessModualSections)
                .HasForeignKey(uams => uams.ModualId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAccessModualSection>()
                .HasRequired(uams => uams.Section)
                .WithMany(s => s.UserAccessModualSections)
                .HasForeignKey(uams => uams.SectionCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAccessModualSection>()
                .ToTable("Tbl_UserAccessModualSection");

            #endregion


          

            base.OnModelCreating(modelBuilder);
            }
        }
    }







