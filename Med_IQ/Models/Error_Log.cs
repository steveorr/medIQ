namespace Med_IQ.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Error_Log
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string ErrorMsg { get; set; }

        [Required]
        public string StackTrace { get; set; }

        public DateTime ErrorDate { get; set; }
    }
}
