
using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{

    public class SingerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Style")]
        public int SongStyleId { get; set; }
        public SongStyleVM styleVM { get; set; }
        public SingerVM() { }

        public SingerVM(SingerDTO singer)
        {
            Id = singer.Id;
            Name = singer.Name;
            SongStyleId = singer.SongStyleId;
            styleVM = new SongStyleVM
            {
                Id = singer.SongStyleId,
                Title = singer.SongStyle.Title
            };


        }
    }
}