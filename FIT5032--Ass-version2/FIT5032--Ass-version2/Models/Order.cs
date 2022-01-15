namespace FIT5032__Ass_version2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderId { get; set; }

        [Required]
        public string UserId { get; set; }

        public int ItemId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string ItemQuantity { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
