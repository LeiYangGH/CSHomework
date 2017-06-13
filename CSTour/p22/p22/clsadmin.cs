using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p22
{
    [Serializable ]
    class clsadmin
    {
        private string ID;
        string name;
        string password;
        public bool verify(string pID, string pPsw)
        {
            if (pID ==ID &&pPsw ==password )return true ;
            else return false ;
    }
        public clsadmin (string pID,string pname,string pPsw)
        {
            ID=pID;
            name =pname ;
            password =pPsw;
        }

}
