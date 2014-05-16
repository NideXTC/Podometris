using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podometris
{
    public class Stats
    {
        private int km;
        private int time;
        private DateTime date;

        public int Km { get { return km; } set { this.km = value; } }
        public int Time { get { return time; } set { this.time = value; } }
        public DateTime Date { get { return date; } set { this.date = value; } }

    }
}
