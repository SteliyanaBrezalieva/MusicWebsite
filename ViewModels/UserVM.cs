using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{

    public class UserVM
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please,Enter Username!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please,Enter Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please,Confirm Password!")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfPassword { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }
        public UserVM() { }

        public UserVM(UserDTO user)
        {
            Id = user.Id;
            Name = user.Name;
            Username = user.Username;
            Email = user.Email;

        }
    }
}