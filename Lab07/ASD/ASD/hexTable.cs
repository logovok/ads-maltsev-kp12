using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ASD
{
    internal class hexTable
    {
        public Enterenur[] hexMatrix;
        int hugeLoad;
        public int size;
        List<int> usedHexes;
        public void initHashtable() {
            hexMatrix = new Enterenur[12];
            for (int i = 0; i < hexMatrix.Length; i++)
            {
                hexMatrix[i] = null;
                    
            }
            size = hexMatrix.Length;
            usedHexes = new List<int>();
        }

        void EmergencyRecreateIFF() {
            if (((double)hugeLoad)/size<0.5)
            {
                return;
            }
            size *= 2;
            Enterenur[] newHM = new Enterenur[size];
            for (int i = 0; i < hexMatrix.Length; i++)
            {
                if (hexMatrix[i]!=null)
                {
                    int hex = hexx(hexMatrix[i].currentKey.FirstName, hexMatrix[i].currentKey.LastName);
                    while (newHM[hex] != null)
                    {
                        hex = (hex + 1) % size;
                    }
                    newHM[hex] = hexMatrix[i];
                }
               
                
            }
            hexMatrix = (Enterenur[])newHM.Clone();
        }
        public void InsertEnt(string fName, string sName, string pass, string amaEE) {
            int hex = hexx(fName, sName);
            while (hexMatrix[hex]!=null)
            {
                hex = (hex + 1) % size;
            }
            hexMatrix[hex] = new Enterenur(new KyVal(fName,sName),new Vl(amaEE,pass));
            hugeLoad++;
            EmergencyRecreateIFF();
        }

        public int findOut(string fName, string sName) {
            int hex = hexx(fName, sName);
            while (((hexMatrix[hex]== null && hexMatrix[hex]==null)?true: (!(hexMatrix[hex].currentKey.FirstName.Equals(fName) && hexMatrix[hex].currentKey.LastName.Equals(sName)))))
            {
                if ((hexMatrix[hex] == null) && (!usedHexes.Contains(hex)))
                {
                    // not contained
                    return -1;
                }
                hex = (hex + 1) % size;
            }
            return hex;
        }

        public void delByKey(KyVal kv) {
            int ind = findOut(kv.FirstName,kv.LastName);
            if (ind==-1)
            {
                // not contains
                return;
            }
            usedHexes.Add(ind);
            hexMatrix[ind] = null;
            hugeLoad--;
            
        }

        
        public Vl valByKey(KyVal kv) {
            int ind = findOut(kv.FirstName, kv.LastName);
            if (ind == -1)
            {
                // not contains
                return null;
            }
            return hexMatrix[ind].currentValue;
        }
        int hexx(KyVal kv1) {
            string s1 = kv1.FirstName, s2 = kv1.LastName;
            return ((str2int(s1)+str2int(s2))%size);
        }

        int hexx(string s1, string s2) {
            return ((str2int(s1) + str2int(s2)) % size);
        }

        int str2int(string s) {
            int sum = 0;
            foreach (char item in s.ToCharArray())
            {
                sum += (int)item % size;
            }
            return sum;
        }

       public void friendPP(KyVal Key1, KyVal KeyOfFriend)
        {
            
            int ind1 = findOut(Key1.FirstName, Key1.LastName), ind2 = findOut(KeyOfFriend.FirstName, KeyOfFriend.LastName);
            if (ind1 == -1)
            {
                MessageBox.Show("NOT CONTAINS CURRENT USER");
                return;
            }
            if (ind2 == -1)
            {
                MessageBox.Show("NOT CONTAINS TARGET USER");
                return;
            }
            hexMatrix[ind1].currentValue.AddFriend(KeyOfFriend.FirstName, KeyOfFriend.LastName);

        }

       public void friendMM(KyVal Key1, KyVal KeyOfFriend)
        {
            int ind1 = findOut(Key1.FirstName, Key1.LastName), ind2 = findOut(KeyOfFriend.FirstName, KeyOfFriend.LastName);
            if (ind1 == -1)
            {
                // not contains user
                return;
            }
            if (ind2 == -1)
            {
                // not contains friend
                return;
            }
            hexMatrix[ind1].currentValue.DemolishFriend(KeyOfFriend.FirstName, KeyOfFriend.LastName);

        }
    }
}
