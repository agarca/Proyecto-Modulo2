using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideogamesCodex.Models
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Videogames> videogames = Videogames.SelectAll();
            return View(videogames);
        }

        public ActionResult Ranking()
        {
            List<Videogames> videogames = Videogames.SelectRanking();
            return View(videogames);
        }

        public ActionResult Show(int id)
        {
            Videogames videogames = Videogames.Get(id);
            if (videogames != null)
            {
                return View(videogames);
            }
            else
            {
                return Redirect("~/");
            }

        }

        public ActionResult Create()
        {
            Videogames videogames = new Videogames();
            return View("~/Views/Home/VideogamesForm.cshtml", videogames);
        }

        public ActionResult Modify(int id = 0)
        {
            Videogames videogames = Videogames.Get(id);
            if (videogames == null)
            {
                return Redirect("~/Home/create");
            }
            else
            {
                return View("~/Views/Home/VideogamesForm.cshtml", videogames);
            }
        }

        public ActionResult Save(Videogames videogames)
        {
            videogames.Save();
            return Redirect("~/Home/show/" + videogames.id);
        }

        public ActionResult Remove(int id = 0)
        {
            Videogames videogames = Videogames.Get(id);
            if (videogames != null)
            {
                videogames.Delete();
            }
            return Redirect("~/");
        }

        public ActionResult Search(string word)
        {
            IEnumerable<Videogames> videogames;

            using (var bd = new GamesDBContext())
            {
                videogames = bd.Videogames;
                if (!string.IsNullOrEmpty(word))
                {
                    videogames = videogames.Where(x => x.name.ToLower().Contains(word.ToLower()));
                    videogames = videogames.ToList();
                    return View(videogames);
                }
                else
                {
                    return Redirect("~/");
                }
            }
        }

    }
}