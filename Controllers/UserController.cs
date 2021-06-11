using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{

    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserVM> userVM = new List<UserVM>();
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                foreach (var item in service.GetUsers())
                {
                    userVM.Add(new UserVM(item));
                }
            }
            return View(userVM);

        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserVM user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SoapService.Service1Client service = new SoapService.Service1Client())
                    {
                        UserDTO userDTO = new UserDTO
                        {

                            Name = user.Name,
                            Username = user.Username,
                            Password = user.Password,
                            ConfPassword = user.ConfPassword,
                            Email = user.Email,

                        };

                        service.PostUser(userDTO); //send request to SoapService

                    }

                    return RedirectToAction("Index");

                }
                return View();
            }
            catch
            {
                ViewBag.Styles = Helpers.LoadData.LoadDataStyles();
                return View();
            }



        }

        public ActionResult Details(int id)
        {
            UserVM userVM = new UserVM();
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                var userDTO = service.GetUserById(id);
                userVM = new UserVM(userDTO);
            }

            return View(userVM);

        }

        public ActionResult Delete(int id)
        {
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                service.DeleteUser(id);
            }

            return RedirectToAction("Index");
        }


        //public ActionResult Edit(UserVM item)
        //{
        //    MyDataBaseContex ctx = new MyDataBaseContex();

        //    //User item = ctx.Users
        //    //                    .Where(u => u.Id == id)
        //    //                    .FirstOrDefault();

        //    //if (item == null)
        //    //    return RedirectToAction("Index", "User");

        //    UserVM model = new UserVM();
        //    model.Id = item.Id;
        //    model.Name = item.Name;
        //    model.Username = item.Username;
        //    model.Password = item.Password;
        //    model.Email = item.Email;


        //    ctx.Users.Update(model);
        //    ctx.SaveChanges();

        //    return RedirectToAction("Index","User");

        //}
    }
}