using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class SongStyle : BaseEntity
    {

        public string Title { get; set; }
        public virtual ICollection<Song> Songs { get; set; } // 
        public virtual ICollection<Singer> Singers { get; set; } // 
       
    }
}
