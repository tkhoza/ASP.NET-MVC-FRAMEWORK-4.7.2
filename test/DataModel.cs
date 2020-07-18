namespace test
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DB_Entities")
        {
        }

        public virtual DbSet<Info> Infoes { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Info>()
                .Property(e => e.TelNo)
                .IsUnicode(false);

            modelBuilder.Entity<Info>()
                .Property(e => e.CellNo)
                .IsUnicode(false);

            modelBuilder.Entity<Info>()
                .Property(e => e.AddressLine1)
                .IsUnicode(false);

            modelBuilder.Entity<Info>()
                .Property(e => e.AddressLine2)
                .IsUnicode(false);

            modelBuilder.Entity<Info>()
                .Property(e => e.AddressLine3)
                .IsUnicode(false);

            modelBuilder.Entity<Info>()
                .Property(e => e.AddressCode)
                .IsUnicode(false);

            modelBuilder.Entity<Info>()
                .Property(e => e.PostalAddress1)
                .IsUnicode(false);

            modelBuilder.Entity<Info>()
                .Property(e => e.PostalAddress2)
                .IsUnicode(false);

            modelBuilder.Entity<Info>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
