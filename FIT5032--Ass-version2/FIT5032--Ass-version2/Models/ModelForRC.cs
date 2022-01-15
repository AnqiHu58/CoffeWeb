using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FIT5032__Ass_version2.Models
{
    public partial class ModelForRC : DbContext
    {
        public ModelForRC()
            : base("name=ModelForRC")
        {
        }

        public virtual DbSet<Coffeecourse> Coffeecourse { get; set; }
        public virtual DbSet<Evaluation> Evaluation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coffeecourse>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluation>()
                .Property(e => e.Rate)
                .IsUnicode(false);
        }
    }
}
