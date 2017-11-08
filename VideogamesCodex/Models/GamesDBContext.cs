namespace VideogamesCodex.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GamesDBContext : DbContext
    {
        public GamesDBContext()
            : base("name=GamesDBContext")
        {
        }

        public virtual DbSet<Videogames> Videogames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
