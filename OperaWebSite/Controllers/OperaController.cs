using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OperaWebSite.Models; //AGREGAR
using OperaWebSite.Data; //AGREGAR
using System.Data.Entity; //AREGAR

namespace OperaWebSite.Controllers
{
    public class OperaController : Controller
    {
        //Crear instancia del dbcontext
        private OperaDBContext context = new OperaDBContext();

        // GET: Opera o /Opera/Index
        public ActionResult Index()
        {
            //Traer todas las operas usanfo EF
            var operas = context.Operas.ToList(); //--> se puede usar  LIST<Opera> Operas

            //El controller retorna una vista "Index" con la lista de operas
            return View("Index", operas);
        }

        //Creamos dos metodos para la insercion de la opera en la DB

        
        [HttpGet] //es implicito pero si lo quiero especificar no hay problema.
        public ActionResult Create()
        {
            Opera opera = new Opera(); //--> Creamos la instancia en las propiedades sin valores.

            return View("Create", opera);//--> retornamos la vista CREATE que tiene el objeto opera 
        
        
        }//1ER METODO ---> primer create por GET retornar la vista de registro

        [HttpPost]
        public ActionResult Create(Opera opera) 
        {
            if (ModelState.IsValid)
            {
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");

            }

            return View("Create", opera);

        }//2DO METODO ---> Es por POST para insertar la nueva opera en la base


        //GET
        // Opera/Detail/id
        //Opera/Detail/2
        //[HttpGet// opcional pq el default es get]
        public ActionResult Detail(int id)
        {
            Opera opera = context.Operas.Find(id);
            if (opera != null)
            {
                return View("Detail", opera);
            }
            else
            {
                return HttpNotFound();
            }
        }


        public ActionResult Delete(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Delete", opera);
            }
            else
            {
                return HttpNotFound();
            }


        }


        //Opera/Delete
        [HttpPost] //ACA SI DEBE IR

        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Opera opera = context.Operas.Find(id);


            context.Operas.Remove(opera);
            context.SaveChanges();


            return RedirectToAction("Index");
        
        
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Opera opera = context.Operas.Find(id);

            if (opera != null)
            {
                return View("Edit", opera);
            }
            else
                return HttpNotFound();
        }


        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Opera opera)
        {
            if (ModelState.IsValid)
            {
                context.Entry(opera).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Edit", opera);
        }


    }


}
