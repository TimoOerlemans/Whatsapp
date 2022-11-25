using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLayer
{
    public interface IAccountContainer
    {
        public bool CreateAccount(AccountDTO accountDTO);
        public string GetDisplayname(int ID);
        public int GetRole(int ID);
        public int GetAccount(string Email, string password);
        public bool EditAccount(AccountDTO account);
        public List<AccountDTO> AllAccounts();
        public bool Delete(int id);



    }
}
