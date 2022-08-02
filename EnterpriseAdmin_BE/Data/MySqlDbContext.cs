using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EnterpriseAdmin_BE.Data
{
    public partial class MySqlDbContext : DbContext
    {
        private IConfiguration _configuration;

        public MySqlDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public MySqlDbContext(DbContextOptions<MySqlDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DepartmentsEmployee> DepartmentsEmployees { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Enterprise> Enterprises { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_configuration.GetConnectionString("server=localhost;user=root;database=dev_enterprise_administration;password=Metallicajr.3;port=3306"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("departments");

                entity.HasIndex(e => e.IdEnterprise, "FK_EnterprisesDepartments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.IdEnterprise).HasColumnName("id_enterprise");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(25)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdEnterpriseNavigation)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.IdEnterprise)
                    .HasConstraintName("FK_EnterprisesDepartments");
            });

            modelBuilder.Entity<DepartmentsEmployee>(entity =>
            {
                entity.ToTable("departments_employees");

                entity.HasIndex(e => e.IdDepartment, "FK_Departments");

                entity.HasIndex(e => e.IdEmployee, "FK_Emmployees");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.IdDepartment).HasColumnName("id_department");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(25)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.DepartmentsEmployees)
                    .HasForeignKey(d => d.IdDepartment)
                    .HasConstraintName("FK_Departments");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.DepartmentsEmployees)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_Emmployees");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(25)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Position)
                    .HasMaxLength(30)
                    .HasColumnName("position");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<Enterprise>(entity =>
            {
                entity.ToTable("enterprises");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(75)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(25)
                    .HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
