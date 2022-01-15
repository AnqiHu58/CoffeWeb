namespace FIT5032__Ass_version2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        public int ItemId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string ItemPrice { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? Date { get; set; }
    }
}
