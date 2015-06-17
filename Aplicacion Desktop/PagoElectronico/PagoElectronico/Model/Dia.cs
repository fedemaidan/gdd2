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

        public DateTime tiempoHoy()
        {

            var value = ConfigurationSettings.AppSettings["DateKey"];
            DateTime appDate = DateTime.Parse(value);
            DateTime now = DateTime.Now;
            appDate = appDate.AddHours(now.Hour);
            appDate = appDate.AddMinutes(now.Minute);
            appDate = appDate.AddSeconds(now.Second);

            return appDate;
            /*return FechaDeHoy;*/

        }


    }
}
