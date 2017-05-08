using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBike
{
    public class clsData
    {
        static public List<clsBike> Bikes = new List<clsBike>();
        static public bool isExist(string pID)
        {
            foreach (clsBike t in Bikes)
                if (t.ID == pID) return true;
            return false;
        }
    }  
}
