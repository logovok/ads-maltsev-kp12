using System;
using System.Collections.Generic;
using System.Text;

namespace ASD6
{
    internal class Stk
    {
        private StkCell top;

        public Stk()
        {
            top = null;
        }

        public void Push(string value)
        {
            top = new StkCell(value, top);
        }

        public string Pop()
        {
            if (top!=null)
            {
                string tmp = top.value;
                top = top.next;
                return tmp;
            }
            else
            {
                return null;
            }
        }
        public string Peek()
        {
            if (top != null)
            {
                return top.value;
            }
            else
            {
                return null;
            }
        }

        public bool IsEmpty()
        {
            return top == null;
        }

        
        public string[] GetAll()
        {
            List<string> list = new List<string>();
            StkCell tmp = top;
            while (tmp != null)
            {
                list.Add(tmp.value);
                tmp = tmp.next;
            }
            return list.ToArray();
        }

    }
}
