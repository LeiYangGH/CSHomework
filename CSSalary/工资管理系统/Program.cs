﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 工资管理系统
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if TEST

            frmLogin.GetAllUsers();
            //frmLogin.userID = "20120619001";
            //frmLogin.userName = "张总";
            var firstRow = frmLogin.AllUsersDt[2];
            frmLogin.userID = firstRow.员工编号;
            frmLogin.userName = firstRow.姓名;
            frmLogin.isAdmin = true;
            //Application.Run(new frmSalaryCRUD());
            //Application.Run(new frmAddUser());
            //Application.Run(new frmQuery());
            Application.Run(new frmEditProfile());

#else
            Application.Run(new frmLogin());
#endif

        }
    }
}
