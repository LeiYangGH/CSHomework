using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p22
{
    [Serializable ]
    class clsuser
    {
        string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        string _uName;
        public string UName
        {
            get { return _uName; }
            set { _uName = value; }
        }
        decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            //set { _balance = value; }
        }

        public clsuser(string pID,string pName)
        {
            _ID = pID;
            _uName = pName;
        }
        public clsuser()
        {
        }

        public decimal deposite(decimal amount)
        {
            _balance += amount;
            return amount;
        }

        public decimal pay(decimal amount)
        {
            if (_balance < amount) return -1;
            else {_balance -= amount; return amount;}
        }

    }
}
