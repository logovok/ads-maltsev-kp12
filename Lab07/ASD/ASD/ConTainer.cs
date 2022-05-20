using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ASD
{
    public class ConTainer
    {
        hexTable ht;
        PassHex ph;
        public ConTainer()
        {
            ht = new hexTable();
            ph = new PassHex();
            ht.initHashtable();
            ph.initHashtable(ht);
        }

        public void reg(string name1, string name2, string pass, string amaEE)
        {
            if (ph.valByKey(pass) != null || ht.valByKey(new KyVal(name1, name2)) != null)
            {
                MessageBox.Show("User already exists");
                return;
            }
           // MessageBox.Show(name1 + " " + name2 + " " + pass + " " + amaEE);
            ht.InsertEnt(name1, name2, pass, amaEE);
            ph.InsertEnt(pass, name1, name2, ref ph.hexMatrix);
       
        }

        public bool login(string name1, string name2, string pass)
        {
            comVal cvv = ph.valByKey(pass);
            if (cvv == null)
            {
                return false;
            }
            return (cvv.name1.Equals(name1) && cvv.name2.Equals(name2));

        }

        public void dellA(string pass)
        {

            ht.delByKey(new KyVal(ph.valByKey(pass).name1, ph.valByKey(pass).name2));
            ph.delByKey(pass);
            deleteRelated(pass);
        }

        public List<string> observeUsers()
        {
            List<string> users = new List<string>();
            foreach (Enterenur en in ht.hexMatrix)
            {
                users.Add(en.currentKey.FirstName + " " + en.currentKey.LastName);
            }
            return users;
        }

        public List<KyVal> getFriends(string n1, string n2)
        {
            List<KyVal> users = ht.valByKey(new KyVal(n1, n2)).FriendZona;

            return users;
        }

        public void frP(KyVal k1, KyVal k2)
        {
            ht.friendPP(k1, k2);
        }

        public void frM(KyVal k1, KyVal k2)
        {
            ht.friendMM(k1, k2);
        }
        public void generateVelues() {

            reg("Jack", "Sparrow", "qwerty", "jack@sparrow.co");
            reg("Jacky", "Chan", "123456", "jacky@chan.io");
            reg("Jack", "Daniels", "321456", "jd@whisky.gg");
            reg("Donald", "Verhniy", "qazwsx", "dona@ver.co");
            reg("Ivan", "Trump", "palyanycia", "golova@gov.us");

            frP(new KyVal("Jack", "Sparrow"), new KyVal("Jacky", "Chan"));
            frP(new KyVal("Jack", "Sparrow"), new KyVal("Jack", "Daniels"));
            

        }



        public void observeTables() {
            string ouSing = "";
            for (int i = 0; i < ht.hexMatrix.Length; i++)
            {
                if (ht.hexMatrix[i]!=null)
                {
                    ouSing += (i + 1) + ". - " + ht.hexMatrix[i].currentKey.FirstName + " " + ht.hexMatrix[i].currentKey.LastName + " " +
                    ht.hexMatrix[i].currentValue.email + "  Pass:" + ht.hexMatrix[i].currentValue.passord + "\n";
                }
                
            }
            MessageBox.Show(ouSing);
        }

        void deleteRelated(string pass) {

            foreach (Enterenur en in ht.hexMatrix)
            {
                if (en != null)
                {
                    if (en.currentValue.FriendZona.Contains(new KyVal(ph.valByKey(pass).name1, ph.valByKey(pass).name2)))
                    {
                        en.currentValue.FriendZona.Remove(new KyVal(ph.valByKey(pass).name1, ph.valByKey(pass).name2));
                    }
                }

            }

        }
        
        public void dslinb(string n1, string n2) {
            string str = "";
            foreach (KyVal cave in getFriends(n1, n2)) {
                str += cave.FirstName + " " + cave.LastName;
            }
            MessageBox.Show(str);
        }

        public List<KyVal> getFolks() {
            List<KyVal> folks = new List<KyVal>();
            foreach (Enterenur en in ht.hexMatrix)
            {
                if (en!=null)
                {
                    folks.Add(en.currentKey);
                }
                
            }
            return folks;
        
        }

    }
}
