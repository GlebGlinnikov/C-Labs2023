using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class dbmark
    {
        public int id { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }

        public dbmark() { }

        public dbmark(Mark m) {
            a = m.a;
            b = m.b;
            c = m.c;
        }

        public Mark toMark()
        {
            Mark m = new Mark(a,b,c);
            return m;
        }
    }
}
