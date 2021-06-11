using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
   public  class Singer : BaseEntity
    {
        public string Name { get; set; }

        public int SongStyleId { get; set; } //основно поле - ключ
        public virtual SongStyle SongStyle { get; set; } //virtual Object - ще работим с SongStyle
    }
}
