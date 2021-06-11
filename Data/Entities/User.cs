using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        // public string ConfPassword { get; set; }
        public string Email { get; set; }
        //public bool Sex { get; set; }
        public bool isAdmin { get; set; }
    }
}
