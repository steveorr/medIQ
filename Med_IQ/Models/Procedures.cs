namespace Med_IQ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Procedures
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Procedures()
        {
            Reviews = new HashSet<Reviews>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int ProcedureTypeID { get; set; }

        public int DoctorID { get; set; }

        public int FacilityID { get; set; }

        public int InsurerID { get; set; }

        public int? RecoveryDuration { get; set; }

        public int? ProcedureDuration { get; set; }

        [Column(TypeName = "date")]
        public DateTime ProcedureDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientEmail { get; set; }

        public bool WasSuccess { get; set; }

        public virtual Doctors Doctors { get; set; }

        public virtual Insurance_Providers Insurance_Providers { get; set; }

        public virtual Medical_Facility Medical_Facility { get; set; }

        public virtual Procedure_Types Procedure_Types { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
