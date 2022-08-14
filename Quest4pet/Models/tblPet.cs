namespace Quest4pet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblPet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPet()
        {
            tblFeedbacks = new HashSet<tblFeedback>();
            tblOrderProducts = new HashSet<tblOrderProduct>();
        }

        [Key]
        public int Pets_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Pets_Name { get; set; }

        [StringLength(300)]
        public string Pets_Image { get; set; }

        [Required]
        public string Pets_Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Pets_Price { get; set; }

        public int Category_FID { get; set; }

        public virtual tblCategory tblCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFeedback> tblFeedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderProduct> tblOrderProducts { get; set; }
    }
}
