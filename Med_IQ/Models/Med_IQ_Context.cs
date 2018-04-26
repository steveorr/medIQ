namespace Med_IQ.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Med_IQ_Context : DbContext
    {
        public Med_IQ_Context()
            : base("name=Med_IQ_Context")
        {
        }

        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Insurance_Providers> Insurance_Providers { get; set; }
        public virtual DbSet<Medical_Facility> Medical_Facility { get; set; }
        public virtual DbSet<Procedure_Types> Procedure_Types { get; set; }
        public virtual DbSet<Procedures> Procedures { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctors>()
                .Property(e => e.DoctorName)
                .IsUnicode(false);

            modelBuilder.Entity<Doctors>()
                .Property(e => e.DoctorAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Doctors>()
                .Property(e => e.DoctorZip)
                .IsUnicode(false);

            modelBuilder.Entity<Doctors>()
                .Property(e => e.LicenseNo)
                .IsUnicode(false);

            modelBuilder.Entity<Doctors>()
                .HasMany(e => e.Procedures)
                .WithRequired(e => e.Doctors)
                .HasForeignKey(e => e.DoctorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Insurance_Providers>()
                .Property(e => e.ProviderName)
                .IsUnicode(false);

            modelBuilder.Entity<Insurance_Providers>()
                .Property(e => e.ProviderAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Insurance_Providers>()
                .Property(e => e.ProviderZip)
                .IsUnicode(false);

            modelBuilder.Entity<Insurance_Providers>()
                .Property(e => e.ProviderNo)
                .IsUnicode(false);

            modelBuilder.Entity<Insurance_Providers>()
                .HasMany(e => e.Procedures)
                .WithRequired(e => e.Insurance_Providers)
                .HasForeignKey(e => e.InsurerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medical_Facility>()
                .Property(e => e.FacilityName)
                .IsUnicode(false);

            modelBuilder.Entity<Medical_Facility>()
                .Property(e => e.FacilityAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Medical_Facility>()
                .Property(e => e.FacilityZip)
                .IsUnicode(false);

            modelBuilder.Entity<Medical_Facility>()
                .Property(e => e.FacilityNo)
                .IsUnicode(false);

            modelBuilder.Entity<Medical_Facility>()
                .HasMany(e => e.Procedures)
                .WithRequired(e => e.Medical_Facility)
                .HasForeignKey(e => e.FacilityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Procedure_Types>()
                .Property(e => e.ProcedureName)
                .IsUnicode(false);

            modelBuilder.Entity<Procedure_Types>()
                .Property(e => e.ICD10Code)
                .IsUnicode(false);

            modelBuilder.Entity<Procedure_Types>()
                .HasMany(e => e.Procedures)
                .WithRequired(e => e.Procedure_Types)
                .HasForeignKey(e => e.ProcedureTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Procedures>()
                .Property(e => e.PatientEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Procedures>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Procedures)
                .HasForeignKey(e => e.ProcedureID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reviews>()
                .Property(e => e.Cost)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Reviews>()
                .Property(e => e.ReviewComments)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
