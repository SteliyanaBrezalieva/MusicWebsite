using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SingerController : Controller
    {
        // GET: Singer
        public ActionResult Index(string Search_Data = "")
        {
            List<SingerVM> singerVM = new List<SingerVM>();
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                foreach (var item in service.GetSingers(Search_Data))
                {
                    singerVM.Add(new SingerVM(item));
                }
            }
            return View(singerVM);

        }

        public ActionResult Details(int id)
        {
            SingerVM singerVM = new SingerVM();
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                var singerDTO = service.GetSingerById(id);
                singerVM = new SingerVM(singerDTO);
            }
            return View(singerVM);
        }

        public ActionResult Create()
        {

            ViewBag.Styles = Helpers.LoadData.LoadDataStyles();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //взимаме данни от VM, прехвърляме към DTO и изпращаме към SOAPService
        public ActionResult Create(SingerVM singerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SoapService.Service1Client service = new SoapService.Service1Client())
                    {
                        SingerDTO singerDTO = new SingerDTO
                        {

                            Name = singerVM.Name,
                            SongStyleId = singerVM.SongStyleId,
                            SongStyle = new SongStyleDTO
                            {
                                Id = singerVM.SongStyleId,

                            }
                        };

                        service.PostSinger(singerDTO); //send request to SoapService

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


        public ActionResult Delete(int id)
        {
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                service.DeleteSinger(id);
            }

            return RedirectToAction("Index");
        }
    }
}