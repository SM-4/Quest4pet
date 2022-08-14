namespace Quest4pet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrder")]
    public partial class tblOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblOrder()
        {
            tblOrderProducts = new HashSet<tblOrderProduct>();
        }

        [Key]
        public int Order_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Order_Date { get; set; }

        public TimeSpan Order_Time { get; set; }

        [Required]
        [StringLength(50)]
        public string Order_Status { get; set; }

        [Required]
        [StringLength(50)]
        public string Payment_Mode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrderProduct> tblOrderProducts { get; set; }
    }
}
