namespace test
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Info")]
    public partial class Info
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        [StringLength(20)]
        public string TelNo { get; set; }

        [StringLength(20)]
        public string CellNo { get; set; }

        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [StringLength(100)]
        public string AddressLine2 { get; set; }

        [StringLength(100)]
        public string AddressLine3 { get; set; }

        [StringLength(10)]
        public string AddressCode { get; set; }

        [StringLength(100)]
        public string PostalAddress1 { get; set; }

        [StringLength(100)]
        public string PostalAddress2 { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }
    }
}
