namespace Risk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProjectDescription")]
    public partial class ProjectDescription
    {
        [Key]
        public int CN { get; set; }

        [StringLength(50)]
        public string USERID { get; set; }

        [StringLength(50)]
        public string PROJECTNAME { get; set; }

        [StringLength(10)]
        public string COUNTRY { get; set; }

        [StringLength(10)]
        public string LATITUDE { get; set; }

        [StringLength(10)]
        public string LONGITUDE { get; set; }

        [StringLength(100)]
        public string POSTALADDRESS { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? PROJECTSTARTDATE { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TIMESTAMP { get; set; }

        public DateTime DATEUPDATED { get; set; }
    }
}
