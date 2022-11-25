using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataConnect.Business;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DataConnect.Models
{
    public class AccountViewModel
    {
        public int AccountID { get; set; }

        [Required(ErrorMessage ="Firstname is required!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }


        public Roles Role { get; set; }

        [Required(ErrorMessage = "DisplayName is required!")]
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        public AccountViewModel(Account account)
        {
            this.AccountID = account.AccountID;
            this.FirstName = account.FirstName;
            this.LastName = account.LastName;
            this.Password = account.Password;
            this.Role = account.Role;
            this.DisplayName = account.DisplayName;
            this.Description = account.Description;
            this.Email = account.Email;
        }
        public AccountViewModel()
        {

        }
    }
}
