using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LoginModel obj = new LoginModel();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Index(LoginModel objuserlogin)
        {
            IList<Student> students = StuDbAccessor.SelectAll();
            bool b = students.Any(x =>
            x.Name.TrimEnd() == objuserlogin.UserName
            && x.Pwd.TrimEnd() == objuserlogin.UserPassword);
            if (b)
            {
                ViewBag.Status = "恭喜您登录成功！";
            }
            else
            {
                ViewBag.Status = "用户名或密码错误！";
            }
            return View(objuserlogin);
        }
    }
}
