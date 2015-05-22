using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace PagoElectronico.Model
{
    class Dia
    {
        public DateTime Hoy()
        {

            var value = ConfigurationSettings.AppSettings["DateKey"];
            var appDate = DateTime.Parse(value);

            return appDate;
            /*return FechaDeHoy;*/

        }
    }
}
