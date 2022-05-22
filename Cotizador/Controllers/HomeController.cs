using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cotizador.Models;
namespace Cotizador.Controllers
{
    public class HomeController : Controller
    {
        #region Attributes        
        private readonly DBCotizador _db;
        #endregion

        #region Builder
        public HomeController()
        {
            _db = new DBCotizador();
        }
        #endregion

        #region Methods
        public JsonResult InitialSetting()
        {
            List<Setting> lstConfig = _db.Settings.ToList();
            return Json(new { data = lstConfig }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}