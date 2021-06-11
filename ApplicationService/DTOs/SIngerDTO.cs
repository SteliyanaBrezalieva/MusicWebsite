using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class SingerDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int SongStyleId { get; set; } //основно поле - ключ
        public virtual SongStyleDTO SongStyle { get; set; } //virtual Object - ще работим с SongStyle
    }
}
