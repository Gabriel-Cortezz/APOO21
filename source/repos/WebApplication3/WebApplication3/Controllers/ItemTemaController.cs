using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ItemTemaController : Controller
    {
        private static IList<Itemtema> itens = new List<Itemtema>()
            {
            new Itemtema() { Descricao = "Hola", Nome = "Notebooks"},
            new Itemtema() { Descricao = "OIFoasd", Nome = "Monitores"},
            new Itemtema() { Descricao = " dkisjf", Nome = "Impressoras"},
            new Itemtema() { Descricao = "dfggdg", Nome = "Mouses"},
            new Itemtema() { Descricao = "fsfsdfs", Nome = "Desktops"}
            };
        // GET: ItemTema
        public ActionResult Index()
        {
            return View();
        }
        // GET: 
        public ActionResult Create()
        {
            return View();
        }
        //HTTP POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Itemtema itemtema)
        {
            itens.Add(itemtema);
            itemtema.ItemtemaID = itens.Select(m => m.ItemtemaID).Max() + 1;
            return RedirectToAction("Index");
        }

        //Deleta

        public ActionResult Detele (long id)
        {
            return View(itens.Where(m => m.ItemtemaID == id).First());
        }

        //Deleta do bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Itemtema itemtema)
        {
            itens.Remove(
            itens.Where(c => c.ItemtemaID == itemtema.ItemtemaID).First());
            return RedirectToAction("Index");
        }
    }
}