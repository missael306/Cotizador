using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizador.Models
{
    public class Pay
    {
        #region Attributes    
        public int Deadline { get; set; }
        public double Rate { get; set; }
        public float Sum { get; set; }
        public double IVA { get; set; }
        #endregion

        #region Methods
        public string Payment()
        {
            double percentInterest = Math.Round((Rate / 12) / 100, 4);
            double mounthPay = Sum * percentInterest;
            double interestPay = (Sum * percentInterest)  / (1- Math.Pow((1 + percentInterest), -Deadline));
            double payIva = (Sum * percentInterest) * IVA / 100;
            return string.Format("{0:C}", Math.Round(interestPay + payIva, 2));
        }
        #endregion
    }
}