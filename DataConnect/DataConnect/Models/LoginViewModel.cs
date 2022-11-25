using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataConnect.Business;

namespace DataConnect.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter an Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter an password")]
        public string Password { get; set; }
        public Roles Role {get; set;}
        public int AccountID { get; set; }
    }
}
