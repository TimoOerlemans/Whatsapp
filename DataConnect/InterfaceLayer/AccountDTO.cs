using System;


namespace InterfaceLayer
{
    public class AccountDTO
    {
        public int AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
    }
}
