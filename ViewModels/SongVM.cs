
using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class SongVM
    {
        public int Id { get; set; }
        [Required]

        [Display(Name = "Song")]
        public string songName { get; set; }
        public string Singer { get; set; }
        public int Year { get; set; }
        [Display(Name = "Song Style")]
        public int SongStyleId { get; set; }
        
       
        //[NotMapped]
        //public string SongStyleName { get; set; }
        public   SongStyleVM styleVM { get; set; }

        public SongVM() { }

        public SongVM(SongDTO song)
        {
            Id = song.Id;
            songName = song.songName;
            Singer = song.Singer;
            Year = song.Year;
            SongStyleId = song.SongStyleId;
            styleVM = new SongStyleVM
            {
                Id = song.SongStyleId,
                Title = song.SongStyle.Title
            };
        }
    }

}