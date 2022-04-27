using System;
using System.Collections.Generic;
using System.Text;

namespace ASD6
{
    internal class StkCell
    {
     public   string value;
        public StkCell next;

        public StkCell(string value, StkCell next)
        {
            this.value = value;
            this.next = next;
        }
    }
}
