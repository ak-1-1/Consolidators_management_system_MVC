using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using flight_inventory.Models;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
//in case of returning many objects,we should use list
namespace flight_inventory.Controllers
{
    public class loginController:Controller
    {
        static int get_hash(string s)
        {
            int total = 0;
            char[] c;
            c = s.ToCharArray();

            // Summing up all the ASCII values
            // of each alphabet in the string
            for (int k = 0; k <= c.GetUpperBound(0); k++)
                total += (int)c[k];

            return total % (10007);
        }
        private readonly Ace42023Context db;
        private readonly ISession session;
        public loginController(Ace42023Context _db,IHttpContextAccessor httpContextAccessor)
        {
            db=_db;
            session=httpContextAccessor.HttpContext.Session;
        }

        

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginAwa u)
        {
            int val=get_hash(u.Pword);
            System.Console.WriteLine(val+"   idhar dkho na!!");
            u.Pword=val.ToString();
            var result=(from i in db.LoginAwas
                where i.Userid==u.Userid && i.Pword==u.Pword
                select i).SingleOrDefault();
                if(result!=null)
                {
                    HttpContext.Session.SetString("username",result.Username);

                    return RedirectToAction("Showflight","flight");
                }
                else
                {
                    return View();
                }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ActionName("Register")]
        public ActionResult RegisterConfirmed(LoginAwa a)
        {
            int val=get_hash(a.Pword);
            a.Pword=val.ToString();
            db.LoginAwas.Add(a);
            db.SaveChanges();
            return RedirectToAction("Showflight","flight");
        }
    }
}