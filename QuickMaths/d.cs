using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMaths
{
     class d
    {
        public int Dd(string s,int pr,int dr)
        {//kanei tis praksis analoga me to simvolo kai epistrefei to apotelesma
            if (s == "/") 
            {
                return pr / dr;
            }
            else if (s == "+")
            {
                return pr + dr;
            }
            else if (s == "-")
            {
                return  pr - dr;
            }
            else
            {
                return pr * dr;
            }
        }
    }
}
