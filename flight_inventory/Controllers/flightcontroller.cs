using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using flight_inventory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
//in case of returning many objects,we should use list
namespace flight_inventory.Controllers
{
    public class flightController:Controller
    {
        private readonly Ace42023Context db;
        static int cnt=0;
        static string str_r="";
        static int cnt_a=0;
        static string str_a="";
        public flightController(Ace42023Context _db)
        {
            db=_db;
        }
        //public static Ace42023Context db=new Ace42023Context();
        [Route("show")]
        public IActionResult Showflight()
        {
            ViewBag.Usernm=HttpContext.Session.GetString("username");
            str_r=ViewBag.Usernm;
            cnt=(from f in db.Flightawas select f.Uid).Max();
            cnt+=1;
            
            if(ViewBag.Usernm=="ADMIN")
            {
                return RedirectToAction("adminview");
            }
            else if(ViewBag.Usernm!=null)
            {
                
                string str=ViewBag.Usernm;
                var result=db.Flightawas.Where(x=>(x.Uname==str)).Select(x=>x).ToList();

                return View(result);
            }
            else
            {
                //System.Console.WriteLine("......................");
                return RedirectToAction("Login","Login");
            }
        }

        [Route("add")]
        public IActionResult addproducts()
        {
            //ViewBag.Usernm=HttpContext.Session.GetString("username");
            //System.Console.WriteLine(ViewBag.Usernm);
            //System.Console.WriteLine("......................");
            var result=db.Companyawas.ToList();
            ViewBag.Companyawas=new SelectList(result,"Cid","Cname");
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult addproducts(Flightawa e)
        {
            //string st=
            e.Uid=cnt;
            cnt+=1;
            e.Uname=str_r;

            db.Flightawas.Add(e);
            db.SaveChanges();
            return RedirectToAction("Showflight");
        }

        [Route("info")]
        public IActionResult Details(int id)
        {
            Flightawa f=db.Flightawas.Find(id);
            return View(f);
        }
        
        [HttpGet]//data annotation--for compiler to know get method
        [Route("makechange")]
        public ActionResult Edit(int id)
        {
            
            var result=db.Companyawas.ToList();
            
            
            ViewBag.Companyawas=new SelectList(result,"Cid","Cname");

            Flightawa ed=db.Flightawas.Where(x=>x.Uid==id).SingleOrDefault();
            cnt_a=ed.Uid;
            str_a=ed.Uname;
            System.Console.WriteLine(cnt_a);
            System.Console.WriteLine(str_a);
            return View(ed);
        }

        [HttpPost]
        [Route("makechange")]
        public ActionResult Edit(Flightawa ed)
        {
            ed.Uid=cnt_a;
            ed.Uname=str_a;
           
            db.Flightawas.Update(ed);
            db.SaveChanges();
            return RedirectToAction("Showflight");
        }

        [HttpGet]
        [Route("erasedata/{id:int}")]
        public ActionResult Delete(int id)
        {
            Flightawa d=db.Flightawas.Find(id);
            return View(d);
        }

        [HttpPost]
        [ActionName("Delete")]//mvc compiler
        [Route("erasedata/{id:int}")]
        public ActionResult DeleteConfirmed(int id)
        {
            
            Flightawa d=db.Flightawas.Find(id);
            db.Flightawas.Remove(d);
            db.SaveChanges();

            return RedirectToAction("Showflight");
        }

        public ActionResult Searchflight(IFormCollection f)
        {
            string keyword=f["keyword"].ToString();
            var result=db.Flightawas.Where(x=>x.Uname.Contains(keyword)).Select(x=>x).ToList();
            
            return View(result);
        }

        public ActionResult adminview()
        {
            return View(db.Flightawas);
        }

        public ActionResult showuserinfo()
        {
            return View(db.LoginAwas);
        }
    }
}