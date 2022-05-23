using Cotizador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cotizador.Controllers
{
    public class SettingController : Controller
    {
        #region Attributes    
        private readonly DBCotizador _db;
        #endregion

        #region Builder
        public SettingController()
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
        #endregion        
    }
}