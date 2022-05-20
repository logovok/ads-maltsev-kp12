using System;
using System.Collections.Generic;
using System.Text;

namespace ASD
{
    public class KyVal
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public KyVal(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }
    }
}
