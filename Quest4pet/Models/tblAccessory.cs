namespace Quest4pet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblAccessory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAccessory()
        {
            tblFeedbacks = new HashSet<tblFeedback>();
            tblOrderProducts = new HashSet<tblOrderProduct>();
        }

        [Key]
        public int Accessories_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Accessories_Name { get; set; }

        [Required]
        [StringLength(300)]
        public string Accessories_Image { get; set; }

        [Required]
        [StringLength(50)]
        public string Accessories_Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Accessories_Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFeedback> tblFeedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderProduct> tblOrderProducts { get; set; }
    }
}
