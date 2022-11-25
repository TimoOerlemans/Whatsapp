using System;
using System.Collections.Generic;
using System.Text;
using InterfaceLayer;

namespace LogicLayer
{
    public class AccountContainer
    {
        private IAccountContainer IAccountContainer;

        public bool CreateAccount(Account account)
        {
            AccountDTO accountDTO = new AccountDTO();
            accountDTO.AccountID = account.AccountID;
            accountDTO.Description = account.Description;
            accountDTO.DisplayName = account.DisplayName;
            accountDTO.Email = account.Email;
            accountDTO.FirstName = account.FirstName;
            accountDTO.LastName = account.LastName;
            accountDTO.Password = account.Password;
            accountDTO.Role = account.Role;
            return IAccountContainer.CreateAccount(accountDTO);
        }
        public string GetDisplayname(int ID)
        {
            return IAccountContainer.GetDisplayname(ID);
        }
        public int GetRole(int ID)
        {
            return IAccountContainer.GetRole(ID);
        }
        public int GetAccount(string Email, string password)
        {
            return IAccountContainer.GetAccount(Email, password);
        }
        public bool EditAccount(Account account)
        {
            AccountDTO accountDTO = new AccountDTO();
            accountDTO.AccountID = account.AccountID;
            accountDTO.Description = account.Description;
            accountDTO.DisplayName = account.DisplayName;
            accountDTO.Email = account.Email;
            accountDTO.FirstName = account.FirstName;
            accountDTO.LastName = account.LastName;
            accountDTO.Password = account.Password;
            accountDTO.Role = account.Role;
            return IAccountContainer.EditAccount(accountDTO);
        }
        public List<Account> AllAccounts(string connection)
        {
            List<AccountDTO> AccountTemp = IAccountContainer.AllAccounts();
            List<Account> accounts = new List<Account>();
            foreach(AccountDTO accountDTO in AccountTemp)
            {
                accounts.Add(new Account(accountDTO));
            }
            return (accounts);
        }
        public bool Delete(int id)
        {
            return IAccountContainer.Delete(id);
        }
    }
}
