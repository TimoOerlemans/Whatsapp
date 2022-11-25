using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataConnect.Business;
namespace DataConnect
{
    public class Account
    {
        public int AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }

        public Account()
        {

        }

        public Account(int accountID, string firstName, string lastName, string password, Roles role, string displayName, string description, string Email)
        {
            this.AccountID = accountID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
            this.DisplayName = displayName;
            this.Description = description;
            this.Email = Email;
        }

        public Account(int accountID, string firstName, string lastName, string password, Roles role, string displayName, string Email)
        {
            this.AccountID = accountID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
            this.DisplayName = displayName;
            this.Email = Email;
        }

        public Account(int accountID, string firstName, string lastName, Roles role, string displayName)
        {
            this.AccountID = accountID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            this.DisplayName = displayName;
        }

        public Account(int accountID, string firstName, string lastName, Roles role, string displayName, string Email)
        {
            this.AccountID = accountID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            this.DisplayName = displayName;
            this.Email = Email;
        }

        public Account(int id, string displayname)
        {
            this.AccountID = id;
            this.DisplayName = displayname;
        }

        public Account(int id, Roles role)
        {
            this.AccountID = id;
            this.Role = role;
        }
        public Account(int id, string FirstName, string LastName, string Description, string DisplayName)
        {
            this.AccountID= id;
            this.FirstName = FirstName;
            this.LastName = LastName;   
            this.Description = Description;
            this.DisplayName = DisplayName;
        }
    }
}
