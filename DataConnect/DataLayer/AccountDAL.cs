using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using InterfaceLayer;
using Helper;

namespace DataConnect.Data 
{
    public class AccountDAL : IAccountContainer
    {
        static string ConnectionString = "Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;";
        public SqlConnection conn = new SqlConnection(ConnectionString);
        public bool CreateAccount(AccountDTO accountDTO)
        {
            string queryString = "INSERT INTO Account (Firstname, Lastname, Password, Role, Displayname, Email) VALUES (@Firstname, @Lastname, @Password, @Role, @Displayname, @Email)";
            using (conn)
            {
                try
                {
                    string Password = Encryption.ComputeSha256Hash(accountDTO.Password);
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Firstname", accountDTO.FirstName);
                    cmd.Parameters.AddWithValue("@Lastname", accountDTO.LastName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@Role", accountDTO.Role);
                    cmd.Parameters.AddWithValue("@Displayname", accountDTO.DisplayName);
                    cmd.Parameters.AddWithValue("@Email", accountDTO.Email);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public string GetDisplayname(int ID)
        {
            string queryString = "SELECT Displayname FROM Account WHERE AccountID = @AccountID";
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@AccountID", ID);

                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();

                bool returnValue = dataReader.HasRows;
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                conn.Close();
                if (returnValue)
                {
                    return dataTable.Rows[0]["Displayname"].ToString();
                }
                return null;
            }
        }

        public int GetRole(int ID)
        {
            string queryString = "SELECT Role FROM Account WHERE AccountID = @AccountID";
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@AccountID", ID);

                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();

                bool returnValue = dataReader.HasRows;
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                conn.Close();
                if (returnValue)
                {

                    return Convert.ToInt32(dataTable.Rows[0]["Role"]);
                }
                return 0;
            }
        }

        public int GetAccount(string Email, string password)
        {
            string queryString = "SELECT * FROM Account WHERE Email = @Email AND Password = @Password";
            using (conn)
            {
                string Password = Encryption.ComputeSha256Hash(password);
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);

                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();

                bool returnValue = dataReader.HasRows;
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                conn.Close();
                if (returnValue)
                {

                    return Convert.ToInt32(dataTable.Rows[0]["AccountID"]);
                }
                return 0;           
            }
        }

        public AccountDTO GetRoleById(int id)
        {
            AccountDTO account = new AccountDTO();

            string queryString = "SELECT * FROM Account WHERE AccountID = @AccountID";
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@AccountID", id);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    account.Role = (Roles)rdr["Role"];
                    account.AccountID = (int)rdr["AccountID"];
                }
                return account;
            }
        }
        
        public bool EditAccount(AccountDTO account)
        {
            string queryString = "UPDATE Account SET Role = @Ro WHERE AccountID = @Id";
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Ro", account.Role);
                cmd.Parameters.AddWithValue("@Id", account.AccountID);
                cmd.ExecuteNonQuery();
            }
            
            return true;
        }
        public List<AccountDTO> AllAccounts()
        {
            List<AccountDTO> accounts = new List<AccountDTO>();

            string queryString = "SELECT * FROM Account;";
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AccountDTO account = new AccountDTO();
                    account.AccountID = (int)rdr["AccountID"];
                    account.FirstName = (string)rdr["FirstName"];
                    account.LastName = (string)rdr["LastName"];
                    account.Role = (Roles)rdr["Role"];
                    account.DisplayName = (string)rdr["Displayname"];
                    account.Email = (string)rdr["Email"];
                    accounts.Add(account);
                }
            }
            return accounts;
        }

        public bool Delete(int id)
        {
            string queryString = "DELETE FROM Account WHERE AccountID = @AccountID";
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@AccountID", id);
                cmd.ExecuteNonQuery();
            }
            return true;
        }
        public bool UpdateAccount(AccountDTO account)
        {
            string queryString = "UPDATE Account SET Firstname = @Firstname, Lastname = @Lastname, Displayname = @Displayname, Description = @Description WHERE AccountID = @Id";
            using (conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Firstname", account.FirstName);
                    cmd.Parameters.AddWithValue("@Lastname", account.LastName);
                    cmd.Parameters.AddWithValue("@Displayname", account.DisplayName);
                    cmd.Parameters.AddWithValue("@Description", account.Description);
                    cmd.Parameters.AddWithValue("@Id", account.AccountID);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
