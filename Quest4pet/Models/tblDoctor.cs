namespace Quest4pet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDoctor")]
    public partial class tblDoctor
    {
        [Key]
        public int Doctor_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Doctor_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Doctor_Contact { get; set; }

        [Required]
        public string Doctor_Address { get; set; }
    }
}
