namespace Med_IQ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reviews
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int ProcedureID { get; set; }

        public decimal? Cost { get; set; }

        public string ReviewComments { get; set; }

        public int ReviewRating { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReviewDate { get; set; }

        public virtual Procedures Procedures { get; set; }
    }
}
