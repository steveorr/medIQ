namespace Med_IQ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medical_Facility
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medical_Facility()
        {
            Procedures = new HashSet<Procedures>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string FacilityName { get; set; }

        [Required]
        [StringLength(1000)]
        public string FacilityAddress { get; set; }

        [Required]
        [StringLength(10)]
        public string FacilityZip { get; set; }

        [Required]
        [StringLength(10)]
        public string FacilityNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Procedures> Procedures { get; set; }
    }
}
