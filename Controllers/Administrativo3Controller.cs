using ProjetoASP.Acoes;
using ProjetoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoASP.Controllers
{
    public class Administrativo3Controller : Controller
    {
        ModelCategoria usuario = new ModelCategoria();
        acCategoria acCat = new acCategoria();


        ModelTamanho UsuTamanho = new ModelTamanho();
        acTamanho acTam = new acTamanho();


        //--------------------------------------------------CRUD CATEGORIA--------------------------------------------------
        public ActionResult CategoriaInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoriaInsert(ModelCategoria cm)
        {
            if (!ModelState.IsValid)
            {
                return View(cm);
            }
            
            acCat.InsertCategoria(cm);
            return RedirectToAction("CategoriaList", "Administrativo3");
        }

        public ActionResult CategoriaList()
        {
            return View(acCat.Categoria());
        }

        public ActionResult CategoriaUpdate(string ID)
        {
            usuario = acCat.SelecionarIdCat(ID);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult CategoriaUpdate(ModelCategoria cm)
        {

            acCat.updateCategoria(cm);

            return RedirectToAction("CategoriaList", "Administrativo3");
        }

        public ActionResult CategoriaDelete(string ID)
        {
            usuario = acCat.SelecionarIdCat(ID);
            return View(usuario);
        }

        [HttpPost, ActionName("CategoriaDelete")]

        public ActionResult ConfirmaDelete(string Id)
        {
            acCat.deleteCategoria(Id);
            return RedirectToAction("CategoriaList", "Administrativo3");
        }

        //--------------------------------------------------CRUD CATEGORIA------------------------------------------------
       
        //--------------------------------------------------CRUD TAMANHO--------------------------------------------------

        public ActionResult TamanhoInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TamanhoInsert(ModelTamanho cm)
        {
            if (!ModelState.IsValid)
            {
                return View(cm);
            }

            acTam.InsertTamanho(cm);
            return RedirectToAction("TamanhoList", "Administrativo3");
        }

        public ActionResult TamanhoList()
        {
            return View(acTam.Tamanho());
        }

        public ActionResult TamanhoUpdate(string ID)
        {
            UsuTamanho = acTam.SelecionarIdtam(ID);
            return View(UsuTamanho);
        }

        [HttpPost]
        public ActionResult TamanhoUpdate(ModelTamanho cm)
        {

            acTam.updateTamanho(cm);

            return RedirectToAction("TamanhoList", "Administrativo3");
        }

        public ActionResult TamanhoDelete(string ID)
        {
            UsuTamanho = acTam.SelecionarIdtam(ID);
            return View(UsuTamanho);
        }

        [HttpPost, ActionName("TamanhoDelete")]

        public ActionResult ConfirmaDeleteTam(string Id)
        {
            acTam.deleteTamanho(Id);
            return RedirectToAction("TamanhoList", "Administrativo3");
        }
        //--------------------------------------------------CRUD TAMANHO--------------------------------------------------


    }
}