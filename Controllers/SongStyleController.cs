using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SongStyleController : Controller
    {
        // GET: SongStyle

        public ActionResult Index()
        {

            List<SongStyleVM> styleVM = new List<SongStyleVM>();
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                foreach (var item in service.GetSongStyle())//достъпваме DTO и добавяме към модела
                {
                    styleVM.Add(new SongStyleVM(item));

                }
            }
            return View(styleVM);
        }

        public ActionResult Details(int id)
        {
            SongStyleVM styleVM = new SongStyleVM();
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                var styleDTO = service.GetSongStyleById(id);
                styleVM = new SongStyleVM(styleDTO);
            }

            return View(styleVM);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //взимаме данни от VM, прехвърляме към DTO и изпращаме към SOAPService
        public ActionResult Create(SongStyleVM styleVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SoapService.Service1Client service = new SoapService.Service1Client())
                    {
                        SongStyleDTO styleDTO = new SongStyleDTO
                        {

                            Title = styleVM.Title
                        };

                        service.PostSongStyle(styleDTO); //send request to SoapService

                    }

                    return RedirectToAction("Index");

                }
                return View();
            }
            catch
            {
                return View();
            }


        }


        public ActionResult Delete(int id)
        {
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                service.DeleteSongStyle(id);
            }

            return RedirectToAction("Index");
        }
    }
}