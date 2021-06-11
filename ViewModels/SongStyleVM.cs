
using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class SongStyleVM
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public SongStyleVM() { }

        public SongStyleVM(SongStyleDTO style)
        {
            Id = style.Id;
            Title = style.Title;
        }
    }
}