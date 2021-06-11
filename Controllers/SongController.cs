using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SongController : Controller
    {
        // GET: PlayList
        public ActionResult Index(string Search_Data = "")
        {

            List<SongVM> songVM = new List<SongVM>();
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                foreach (var item in service.GetSongs(Search_Data))//достъпваме DTO и добавяме към модела
                {
                    songVM.Add(new SongVM(item));

                }
            }
            return View(songVM);
        }

        public ActionResult Details(int id)
        {
            SongVM songVM = new SongVM();
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                var songDTO = service.GetSongById(id);
                songVM = new SongVM(songDTO);
            }

            return View(songVM);

        }
        //public ActionResult Share (int id)
        //{
        //    SongVM songVM = new SongVM();

        //}

        public ActionResult Create()
        {
            ViewBag.Styles = Helpers.LoadData.LoadDataStyles();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //взимаме данни от VM, прехвърляме към DTO и изпращаме към SOAPService
        public ActionResult Create(SongVM songVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SoapService.Service1Client service = new SoapService.Service1Client())
                    {
                        SongDTO songDTO = new SongDTO
                        {

                            songName = songVM.songName,
                            Singer = songVM.Singer,
                            Year = songVM.Year,
                            SongStyleId = songVM.SongStyleId,
                            SongStyle = new SongStyleDTO
                            {
                                Id = songVM.SongStyleId,


                            }
                        };

                        service.PostSong(songDTO); //send request to SoapService

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
                service.DeleteSong(id);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            using (var ctx = new MyDBContext())
            {

                // Use of lambda expression to access
                // particular record from a database
                var data = ctx.Songs.FirstOrDefault(x => x.Id == id);

                //// Checking if any such record exist 
                //if (data != null)
                //{
                //    data.songName = model.songName;
                //    data.Singer = model.Singer;
                //    data.Year = model.Year;


                //    ctx.SaveChanges();

                //    // It will redirect to 
                //    // the Read method
                //    return RedirectToAction("Index");
                //}
                //else

                return View(data);
            }
        }
        [HttpPost]
        public ActionResult Edit(Song song)
        {
            //update student in DB using EntityFramework in real-life application
            using (var ctx = new MyDBContext())
            {
                //update list by removing old student and adding updated student for demo purpose
                Song item = ctx.Songs.Find(song);
                ctx.Songs.Remove(song);
                ctx.Songs.Add(song);
            }
            return RedirectToAction("Index");
        }
    }
}