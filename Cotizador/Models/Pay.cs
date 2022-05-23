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
        public double Sum { get; set; }
        public double IVA { get; set; }

        public double outstandingBalance { get; set; }
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

        public double PaymentWithOutIVA(double initialCapital)
        {
            double percentInterest = Math.Round((Rate / 12) / 100, 4);
            double mounthPay = initialCapital * percentInterest;
            double interestPay = (initialCapital * percentInterest) / (1 - Math.Pow((1 + percentInterest), -Deadline));            
            return Math.Round(interestPay, 2);
        }

        public double PayInterest()
        {
            double percentInterest = Math.Round((Rate / 12) / 100, 4);
            double mounthPay = Sum * percentInterest;
            return Math.Round(mounthPay);
        }

        public double PayIva()
        {
            double percentInterest = Math.Round((Rate / 12) / 100, 4);
            double payIva = (Sum * percentInterest) * IVA / 100;
            return Math.Round(payIva, 2);
        }

        public double PayCapital(double initialCapital)
        {
            double pay = this.PaymentWithOutIVA(initialCapital);
            double interest = this.PayInterest();
            return Math.Round(pay-interest, 2);
        }
        #endregion
    }
}