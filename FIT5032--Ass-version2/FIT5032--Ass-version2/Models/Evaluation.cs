namespace FIT5032__Ass_version2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Evaluation")]
    public partial class Evaluation
    {
        public int Id { get; set; }

        [Required]
        public string Rate { get; set; }

        public int Rate_num { get; set; }
    }
}
