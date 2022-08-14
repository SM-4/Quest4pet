namespace Quest4pet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrderProduct")]
    public partial class tblOrderProduct
    {
        [Key]
        public int OrderProduct_ID { get; set; }

        public int Order_Quantity { get; set; }

        public int Order_FID { get; set; }

        public int? Pets_FID { get; set; }

        public int? Accessories_FID { get; set; }

        public virtual tblAccessory tblAccessory { get; set; }

        public virtual tblOrder tblOrder { get; set; }

        public virtual tblPet tblPet { get; set; }
    }
}
