using Cotizador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cotizador.Controllers
{
    public class CatalogsController : Controller
    {
        #region Attributes        
        private readonly DBCotizador _db;
        #endregion

        #region Builder
        public CatalogsController()
        {
            _db = new DBCotizador();
        }
        #endregion

        #region Methods           
        public JsonResult GetModels(int IdBrand)
        {
            List<Model> lstModels = _db.Mdoels.Where(X => X.BrandId == IdBrand).ToList();
            return Json(new { data = lstModels }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetYears(int IdModel)
        {
            List<Year> lstYears = _db.Years.Where(X => X.ModelId == IdModel).ToList();
            return Json(new { data = lstYears }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}