using System;
using System.Collections.Generic;
using System.Text;

namespace ASD
{
    internal class Vl
    {
        public string passord { get; set; }
        public string email { get; set; }

        public List<KyVal> FriendZona;

        public Vl(string email, string passord)
        {
            this.email = email;
            this.passord = passord;
            FriendZona = new List<KyVal>();
        }

        public void AddFriend(string fName, string Surname)
        {
            KyVal kv = new KyVal(fName, Surname);
            FriendZona.Add(kv);
        }

        public void DemolishFriend(string fName, string Surname)
        {
            foreach (KyVal kv in FriendZona)
            {
                if (kv.FirstName == fName && kv.LastName == Surname)
                {
                    FriendZona.Remove(kv);
                    return;
                }
            }
        }

    }
}
