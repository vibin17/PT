using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L22
{
    class Order : IComparable<Order>
    {
        public int n;
        public int dur;
        public int pen;
        public Order(int n, int dur, int pen)
        {
            this.n = n;
            this.dur = dur;
            this.pen = pen;
        }
        public int CompareTo(Order b)
        {
            return (dur * b.pen).CompareTo(b.dur * pen) == 0 ? n.CompareTo(b.n) : (dur * b.pen).CompareTo(b.dur * pen);
        }
    }
}
