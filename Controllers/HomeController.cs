using Data.Context;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(UserVM model)
        {
            using (var ctx = new MyDBContext())
            {
                bool isValid = ctx.Users.Any(x => x.Username == model.Username
                                                  && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index", "Home");
                }


                ModelState.AddModelError("AuthenticationFailed", "Wrong Username or Password");
                return View(model);
            }
            //ModelState.AddModelError("", "Invalid username or password!");
            //  return View(model);
        
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        //  if (!ModelState.IsValid)
        //  {
        //      return View(model);
        //  }

        //  bool isAuthenticated = false;

        //  if (model.Username == "stelinna" && model.Password == "123")
        //  {
        //      isAuthenticated = true;
        //  }

        //  if (!isAuthenticated)
        //  {
        //      ModelState.AddModelError("AuthenticationFailed", "Wrong Username or Password");
        //      return View(model);
        //  }
        ////  this.HttpContext.Session.SetString("loggedUser", model.Username);


        //      return RedirectToAction("Index","Home");
        //MyDataBaseContex ctx = new MyDataBaseContex();

        //var dataItem = ctx.Users.Where(u => u.Username == model.Username
        //                                    && u.Password == model.Password).First();


        //if(dataItem != null)
        //{
        //    FormsAuthentication.SetAuthCookie(dataItem.Username, false);
        //    if(Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
        //        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}
        //else
        //{
        //    ModelState.AddModelError("", "Invalid username or Password");
        //    return View();
        //}

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        //SecurityService securytyService = new SecurityService();
        //Boolean success = securytyService.Authenticate(userModel);

        //if (success)
        //{
        //    return RedirectToAction("Index","Home");
        //}else
        //{
        //    return View(userModel);
        //}

        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    bool isAuthenticated = false;

        //    if(model.Username == "stelinna" && model.Password == "123")
        //    {
        //        isAuthenticated = true;
        //    }

        //    if (!isAuthenticated)
        //    {
        //        ModelState.AddModelError("AuthenticationaFailed", "Wrong Username or Password");
        //        return View(model);
        //    }
        // <div class="row">
        // <div class="col-3">@Html.ValidationMessage("AuthenticationFailed")</div>
        //  </div>

        //    return RedirectToAction("Index","Home");


        //[HttpPost]
        //public ActionResult Login(UserModel userModel)
        //{
        //    if (userModel.Username == "stelinna" && userModel.Password == "123")
        //    {

        //        return View("LoginSucess", userModel);
        //    } else
        //    {
        //        return View("LoginFailure", userModel);
        //    }



        //}
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}