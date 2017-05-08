using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBike
{
    public class clsBike
    {
        string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        DateTime _DOP;
        public DateTime DOP
        {
            get { return _DOP; }
            set { _DOP = value; }
        }
        float _price;
        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public clsBike(string pid, DateTime pdop, float pp)
        {
            _ID = pid;
            _DOP = pdop;
            _price = pp;
        }
    }
}
