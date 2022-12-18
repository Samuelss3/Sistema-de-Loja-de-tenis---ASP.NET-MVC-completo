using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoASP.Controllers
{
    public class AdiministrativoController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}