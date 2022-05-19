using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizador.Models
{
    public class GlobalResources
    {
        public static string GetResource(string File, string Key, string Default)
        {
            try
            {
                return HttpContext.GetGlobalResourceObject(File, Key).ToString();
            }
            catch (Exception)
            {

                return Default;
            }
        }
    }
}