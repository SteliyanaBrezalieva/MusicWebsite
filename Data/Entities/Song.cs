using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
       public class Song : BaseEntity
    {
      
        public string songName { get; set; }
        public string Singer { get; set; }

        public int Year { get; set; }
       // public string SongStyleName { get; set; }
        public int SongStyleId { get; set; } //основно поле - ключ

        public virtual SongStyle SongStyle { get; set; } //virtual Object - ще работим с SongStyle
    }
}
