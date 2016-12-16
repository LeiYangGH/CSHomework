using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bank
{
    class User
    {

        private string _account; //账号

        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }



        private string _name;   //用户名

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        private string _mima;  //密码

        public string Mima
        {
            get { return _mima; }
            set { _mima = value; }
        }



        private string _id;   //身份证

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }





        private double _balance;//余额

        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

    }
}
