using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p22
{
    [Serializable ]
    class clstourist
    {
         string flag;

        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        string nID;
        public string ID
        {
            get { return ID; }
            set { ID = value; }
        }
        DateTime nDOP;
        public DateTime DOP
        {
            get {return nDOP; }
            set {nDOP = value; }
        }
        float price;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        public clstourist(string pid, DateTime pdop, float pp)
        {
            ID = pid;
            nDOP = pdop;
            price = pp;
            flag = "ready";
        }
    }
}
