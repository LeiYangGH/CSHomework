using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Users
    {
        //定义字段

        private string userid; //用户名
        private string userpwd; //密码
        
        //默认的构造方法
        public Users()
        {
        }
        //定义有参的构造方法；
        public Users(string userid, string userpwd)
        {           
            this.userid = userid;
            this.userpwd = userpwd;
            
        }
        //定义属性
      
        public string Userid
        {
            get
            {
                return this.userid;
            }
        }

        public string Userpwd
        {
            get
            {
                return this.userpwd;
            }
        }

        

    }
}

