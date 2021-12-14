using System;
using System.Collections.Generic;
using System.Text;

namespace _4ASD
{
    class DualLList
    {
        public void dsplay() {
            DLNode temp = head;
            int c = 0;
            while (true)
            {
                Console.WriteLine("№ " + c + " " + temp.data);
                ++c;
                if (temp.next!=null)
                {
                    temp = temp.next;
                }
                else
                {
                    break;
                }
                

            } 
        }
        public DLNode head;
        public class DLNode {
            public DLNode prev;
            public int data;
            public DLNode next;
            
            public DLNode(DLNode pr, int dt, DLNode nxt) {
                prev = pr;
                data = dt;
                next = nxt;
            }
            public DLNode(int dt, DLNode nxt)
            { 
                data = dt;
                next = nxt;
            }
            public DLNode(DLNode pr, int dt)
            {
                prev = pr;
                data = dt;
            }
            public DLNode(int dt)
            {
                data = dt;
            }
        }

        public DualLList(DLNode headOflist) {
            head = headOflist;
        }

        public void AddFirst(int data) {
            DLNode temp = new DLNode(data,head);
            head.prev = temp;                    
            head = temp;   
        }

        public void DelFirst() {
            head = head.next;
            head.prev = null;
        }
         

        public void Add2Pos(int pos, int dat)
        {
            
            DLNode temp = head;
            while (true)
            {
                if (pos == 0)
                {
                    DLNode t2 = new DLNode(temp.prev,dat,temp);
                    temp.prev.next = t2;
                    temp.prev = t2;
                    
                    break;
                }
                if (temp.next != null)
                {
                    temp = temp.next;
                }
                else
                {
                    break;
                }
                pos--;

            }
        }

        public void Del2Pos(int pos)
        {

            DLNode temp = head;
            while (true)
            {
                if (pos == 0)
                {
                    temp.prev.next = temp.next;
                    temp.next.prev = temp.prev;

                    break;
                }
                if (temp.next != null)
                {
                    temp = temp.next;
                }
                else
                {
                    break;
                }
                pos--;

            }
        }

        public void AddLust(int dta)
        {
            DLNode temp = head;
            while (true)
            {

                if (temp.next != null)
                {
                    temp = temp.next;
                }
                else
                {
                    temp.next = new DLNode(temp, dta);

                    break;
                }

            }
        }

        public void DelLust()
        {
            DLNode temp = head;
            while (true)
            {
                if (temp.next != null)
                {
                    temp = temp.next;
                }
                else
                {
                    temp.prev.next = null;
                    break;
                }

            }
        }

        
    }
}
