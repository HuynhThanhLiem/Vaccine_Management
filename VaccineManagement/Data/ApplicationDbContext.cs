using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VaccineManagement.Models.Entities;

namespace VaccineManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Vaccine_Batch> Vaccine_Batches { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Batch_City> Batch_Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Medical_Staff> Medical_Staffs { get; set; }
        public DbSet<Health_Declaration> Health_Declarations { get; set; }
        public DbSet<Anamnesis> Anamneses { get; set; }
        public DbSet<Vaccine_Registration> Vaccine_Registrations { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            modelBuilder.Entity<Vaccine>().ToTable("VACCINE").HasKey(c => c.vaccineId);
            modelBuilder.Entity<Vaccine_Batch>().ToTable("VACCINE_BATCH").HasKey(c => c.batchId);
            modelBuilder.Entity<City>().ToTable("CITY").HasKey(c => c.cityId);

            modelBuilder.Entity<Batch_City>().ToTable("BATCH_CITY").HasKey(c => new { c.cityId, c.batchId });
            modelBuilder.Entity<Batch_City>().ToTable("BATCH_CITY").HasOne<City>(e => e.City).WithMany(p => p.Batch_Cities);
            modelBuilder.Entity<Batch_City>().ToTable("BATCH_CITY").HasOne<Vaccine_Batch>(e => e.Vaccine_Batch).WithMany(p => p.Batch_Cities);


            modelBuilder.Entity<District>().ToTable("DISTRICT").HasKey(c => c.districtId);
            modelBuilder.Entity<Ward>().ToTable("WARD").HasKey(c => c.wardId);
            modelBuilder.Entity<Citizen>().ToTable("CITIZEN").HasKey(c => c.citizenId);
            modelBuilder.Entity<Medical_Staff>().ToTable("MEDICAL_STAFF").HasKey(c => c.staffId);
            modelBuilder.Entity<Health_Declaration>().ToTable("HEALTH_DECLARATION").HasKey(c => c.healthDeclarId);
            modelBuilder.Entity<Anamnesis>().ToTable("ANAMNESIS").HasKey(c => c.anamnesisId);
            modelBuilder.Entity<Vaccine_Registration>().ToTable("VACCINE_REGISTRATION").HasKey(c => c.registrationId);
            modelBuilder.Entity<Vaccination>().ToTable("VACCINATION").HasKey(c => c.vaccinationId);
        }
    }
}
