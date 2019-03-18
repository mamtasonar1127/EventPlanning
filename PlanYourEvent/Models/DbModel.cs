namespace PlanYourEvent.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<EventDesp> EventDesps { get; set; }
        public virtual DbSet<Eventtype> Eventtypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventDesp>()
                .Property(e => e.ED_Name)
                .IsUnicode(false);

            modelBuilder.Entity<EventDesp>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<EventDesp>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EventDesp>()
                .Property(e => e.Photo)
                .IsUnicode(false);

            modelBuilder.Entity<Eventtype>()
                .Property(e => e.Event_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Eventtype>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Eventtype>()
                .Property(e => e.Photo)
                .IsUnicode(false);

            modelBuilder.Entity<Eventtype>()
                .HasMany(e => e.EventDesps)
                .WithRequired(e => e.Eventtype)
                .WillCascadeOnDelete(false);
        }
    }
}
