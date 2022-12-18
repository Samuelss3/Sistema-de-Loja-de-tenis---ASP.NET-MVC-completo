using MySql.Data.MySqlClient;
using ProjetoASP.Acoes;
using ProjetoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoASP.Controllers
{
    public class AdministrativoController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Project()
        {
            return View();
        }        
        public ActionResult Calendar()
        {
            return View();
        }        
        
        public ActionResult index2()
        {
            return View();
        }        
        
        public ActionResult E404()
        {
            return View();
        }
        public ActionResult Blq()
        {
            return View();
        }
     
    }
}