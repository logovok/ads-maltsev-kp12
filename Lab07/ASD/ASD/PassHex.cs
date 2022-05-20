using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ASD
{
    class comVal {
        public string name1, name2;
        public comVal(string fname, string sname)
        {
            name1 = fname;
            name2 = sname;
        }
    }

    class keyPass {
        public string pass;
        public keyPass(string password)
            {
                pass = password;
            }
        }

        class theE {
            public keyPass kp;
        public comVal cv;
        public theE(keyPass kpp, comVal cvv) {
            kp = kpp; cv = cvv;
        }
        }
    internal class PassHex
    {
        public theE[] hexMatrix;
        int hugeLoad = 0;
        int size;
        List<int> usedHexes;
      public  void initHashtable(hexTable hT)
        {
            hexMatrix = new theE[hT.hexMatrix.Length];
            for (int i = 0; i < hexMatrix.Length; i++)
            {
                hexMatrix[i] = null;
            }
            size = hexMatrix.Length;
            usedHexes = new List<int>();
           
        }

        void upd(hexTable hT) {
            usedHexes.Clear();
            theE[] hexMatrixer = new theE[hT.size];
            size = hT.size;
            for (int i = 0; i < hT.hexMatrix.Length; i++)
            {
                InsertEnt(hT.hexMatrix[i].currentValue.passord,hT.hexMatrix[i].currentKey.FirstName, hT.hexMatrix[i].currentKey.LastName, ref hexMatrixer);
            }
            hexMatrix = hexMatrixer;
        }
        public void InsertEnt(string pass,string fName, string sName, ref theE[] HeMa)
        {
            int hex = hexx(pass);
            while (hexMatrix[hex] != null)
            {
                hex = (hex + 1) % size;
            }
            HeMa[hex] = new theE(new keyPass(pass),new comVal(fName,sName));
            hugeLoad++;
            EmergencyRecreateIFF();
        }

        void EmergencyRecreateIFF()
        {
            if (((double)hugeLoad) / size < 0.5)
            {
                return;
            }
            size *= 2;
            theE[] newHM = new theE[size];
            for (int i = 0; i < hexMatrix.Length; i++)
            {
                if (hexMatrix[i]!=null)
                {
                    int hex = hexx(hexMatrix[i].kp.pass);
                    while (newHM[hex] != null)
                    {
                        hex = (hex + 1) % size;
                    }
                    newHM[hex] = hexMatrix[i];
                }
               

            }
            hexMatrix = (theE[])newHM.Clone();
        }
        int findOut(string pass)
        {
            try
            {
                int hex = hexx(pass);
                if (hexMatrix[hex] == null)
                {
                    return -1;
                }
                while ((hexMatrix[hex] != null? !(hexMatrix[hex].kp.pass.Equals(pass)) : true))
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
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                MessageBox.Show(exc.StackTrace);
                return -1;
            }
            
        }

        public void delByKey(string pass)
        {
            int ind = findOut(pass);
            if (ind == -1)
            {
                // not contains
                return;
            }
            usedHexes.Add(ind);
            hexMatrix[ind] = null;
            hugeLoad--;
        }

        public comVal valByKey(string pass)
        {
            int ind = findOut(pass);
            if (ind == -1)
            {
                // not contains
                return null;
            }
            return hexMatrix[ind].cv;
        }
        int hexx(KyVal kv1)
        {
            string s1 = kv1.FirstName, s2 = kv1.LastName;
            return ((str2int(s1) + str2int(s2)) % size);
        }

        int hexx(string s1)
        {
            return (str2int(s1) % size);
        }

        int str2int(string s)
        {
            int sum = 0;
            foreach (char item in s.ToCharArray())
            {
                sum += (int)item % size;
            }
            return sum;
        }

       
    }
}
