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
        public ActionResult Index()
        {            
            ViewBag.CatMarca = _db.Brands.ToList();
            return View();
        }        

        [HttpPost]
        public ActionResult PayOff(float price, float hitch)
        {            
            Setting deadlines = _db.Settings.Where(x => x.Id == (int)Settings.Plazos).FirstOrDefault();
            Setting iva = _db.Settings.Where(x => x.Id == (int)Settings.Iva).FirstOrDefault();
            Setting percentInteres = _db.Settings.Where(x => x.Id == (int)Settings.TazaInteres).FirstOrDefault();
            List<Pay> payments = new List<Pay>();
            foreach (var item in deadlines.Value.Split(','))
            {
                Pay pay = new Pay();
                pay.Deadline = Convert.ToInt32(item);
                pay.IVA = Convert.ToDouble(iva.Value);
                pay.Rate = Convert.ToDouble(percentInteres.Value);
                pay.Sum = price - hitch;
                payments.Add(pay);                
            }
            ViewBag.payment = payments;
            return PartialView();
        }

        [HttpPost]
        public ActionResult TablePay(double sum, int deadline)
        {
            Setting iva = _db.Settings.Where(x => x.Id == (int)Settings.Iva).FirstOrDefault();
            Setting percentInteres = _db.Settings.Where(x => x.Id == (int)Settings.TazaInteres).FirstOrDefault();
            Pay payment = new Pay();
            Pay pay = new Pay();
            pay.Deadline = deadline;
            pay.IVA = Convert.ToDouble(iva.Value);
            pay.Rate = Convert.ToDouble(percentInteres.Value);
            pay.Sum = sum;
            ViewBag.payment = pay;
            ViewBag.sum = sum;
            ViewBag.deadline = deadline;            
            return View();
        }
        #endregion
    }
}