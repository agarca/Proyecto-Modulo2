namespace VideogamesCodex.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Videogames
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string publisher { get; set; }

        public int year { get; set; }

        public int genre { get; set; }
        public Genres Genre
        {
            get
            {
                return (Genres)genre;
            }
            set
            {
                genre = (int)value;
            }
        }

        public int platform { get; set; }
        public Platforms Platform
        {
            get
            {
                return (Platforms)platform;
            }
            set
            {
                platform = (int)value;
            }
        }

        public int score { get; set; }

        public bool online { get; set; }

        public int pegi { get; set; }
        public PEGI Pegi
        {
            get
            {
                return (PEGI)pegi;
            }
            set
            {
                pegi = (int)value;
            }
        }

        public static List<Videogames> SelectAll()
        {
            List<Videogames> videogames = new List<Videogames>();

            try
            {
                GamesDBContext context = new GamesDBContext();
                videogames = context.Videogames.OrderBy(x => x.name).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return videogames;
        }

        public static List<Videogames> SelectRanking()
        {
            List<Videogames> videogames = new List<Videogames>();

            try
            {
                GamesDBContext context = new GamesDBContext();
                videogames = context.Videogames.OrderByDescending(x => x.score).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return videogames;
        }

        public static Videogames Get(int id)
        {
            Videogames videogames = new Videogames();

            try
            {
                GamesDBContext context = new GamesDBContext();
                videogames = context.Videogames.Where(x => x.id == id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return videogames;
        }

        public void Save()
        {
            bool create = this.id == 0;
            try
            {
                GamesDBContext context = new GamesDBContext();
                if (create)
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Added;
                }
                else
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete()
        {
            try
            {
                GamesDBContext context = new GamesDBContext();
                context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
