namespace FIT5032__Ass_version2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Coffeecourse")]
    public partial class Coffeecourse
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
