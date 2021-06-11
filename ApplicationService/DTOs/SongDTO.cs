using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
   
  public  class SongDTO
    {
        public int Id { get; set; }
        public string songName { get; set; }
        public int Year { get; set; }
        public string Singer { get; set; }
       // public string SongStyleName { get; set; }
        public int SongStyleId { get; set; } //основно поле - ключ
       // public int SingerId { get; set; }
        public virtual SongStyleDTO SongStyle { get; set; } //virtual Object - ще работим с SongStyle
       // public virtual SingerDTO SingerDto { get; set; }
    }
}
