using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaMoraviaWebService.Logical
{
    public class CalculateTimeAgo
    {
        public static string Calculate(DateTime fecha)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.Now.Ticks - fecha.Ticks);

            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
            {
                return ts.Seconds == 1 ? "hace un segundo" : "hace " + ts.Seconds + " segundos";
            }
            if (delta < 2 * MINUTE)
            {
                return "hace un minuto";
            }
            if (delta < 45 * MINUTE)
            {
                return "hace " + ts.Minutes + " minutos";
            }
            if (delta < 90 * MINUTE)
            {
                return "hace una hora";
            }
            if (delta < 24 * HOUR)
            {
                return "hace " + ts.Hours + " horas";
            }
            if (delta < 48 * HOUR)
            {
                return "ayer";
            }
            if (delta < 30 * DAY)
            {
                return "hace " + ts.Days + " días";
            }
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));

                return months <= 1 ? "hace un mes" : "hace " + months + " meses";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "hace un año" : "hace " + years + " años";
            }
        }
    }
}