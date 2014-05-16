using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podometris
{
    public class Stats
    {
        private double km;
        private String time;
        private DateTime date;

        public double Km { get { return km; } set { this.km = value; } }
        public String Time { get { return time; } set { this.time = value; } }
        public DateTime Date { get { return date; } set { this.date = value; } }

    }
}
