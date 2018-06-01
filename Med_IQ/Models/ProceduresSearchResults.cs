namespace Med_IQ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProceduresSearchResults
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProceduresSearchResults()
        {
            Reviews = new HashSet<Reviews>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string ProcedureName { get; set; }

        public string DoctorName { get; set; }

        public string FacilityName { get; set; }

        public string InsurerName { get; set; }

        public int? RecoveryDuration { get; set; }

        public int? ProcedureDuration { get; set; }

        [Column(TypeName = "date")]
        public DateTime ProcedureDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientEmail { get; set; }

        public bool WasSuccess { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
