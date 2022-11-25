using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DataConnect.Business;

namespace DataConnect.Data
{
    public class AccountDAL
    {

        public bool UpdateAccount(Account account)
        {
            string queryString = "UPDATE Account SET Firstname = @Firstname, Lastname = @Lastname, Displayname = @Displayname, Description = @Description WHERE AccountID = @Id";
            using (SqlConnection conn
                = new SqlConnection("Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;"))
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
        public bool CreateAccount(Account account)
        {
            string queryString = "INSERT INTO Account (Firstname, Lastname, Password, Role, Displayname, Email) VALUES (@Firstname, @Lastname, @Password, @Role, @Displayname, @Email)";
            using (SqlConnection conn
                    = new SqlConnection("Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;"))
            {
                try
                {
                    string Password = Encryption.ComputeSha256Hash(account.Password);
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Firstname", account.FirstName);
                    cmd.Parameters.AddWithValue("@Lastname", account.LastName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@Role", account.Role);
                    cmd.Parameters.AddWithValue("@Displayname", account.DisplayName);
                    cmd.Parameters.AddWithValue("@Email", account.Email);
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
            using (SqlConnection conn = new SqlConnection("Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;"))
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
        public Roles GetRole(int ID)
        {
            string queryString = "SELECT Role FROM Account WHERE AccountID = @AccountID";
            using (SqlConnection conn = new SqlConnection("Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;"))
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

                    return (Roles)dataTable.Rows[0]["Role"];
                }
                return 0;
            }
        }
        public int GetAccount(string Email, string password)
        {
            string queryString = "SELECT * FROM Account WHERE Email = @Email AND Password = @Password";
            using (SqlConnection conn = new SqlConnection("Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;"))
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

        public Account GetRoleById(int id)
        {
            Account account = new Account();

            string queryString = "SELECT * FROM Account WHERE AccountID = @AccountID";
            using (SqlConnection conn = new SqlConnection("Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;"))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@AccountID", id);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    account = new Account((int)rdr["AccountID"], (Roles)rdr["Role"]);
                }
                return account;
            }
        }

        public bool EditAccount(Account account)
        {
            string queryString = "UPDATE Account SET Role = @Ro WHERE AccountID = @Id";
            using (SqlConnection conn
                    = new SqlConnection("Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;"))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Ro", account.Role);
                cmd.Parameters.AddWithValue("@Id", account.AccountID);
                cmd.ExecuteNonQuery();
            }
            
            return true;
        }
        public List<Account> AllAccounts(string connection)
        {
            List<Account> accounts = new List<Account>();

            string queryString = "SELECT * FROM Account;";
            using (SqlConnection conn =
                new SqlConnection("Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;"))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Account account = new Account((int)rdr["AccountID"], (string)rdr["FirstName"], (string)rdr["LastName"], (Roles)rdr["Role"], (string)rdr["Displayname"], (string)rdr["Email"]);
                    accounts.Add(account);
                }
            }
            return accounts;
        }
        public bool EditPassword(int id, string password)
        { 
            string encryptpass = Encryption.ComputeSha256Hash(password);
            string queryString = "UPDATE Account SET Password = @Pass WHERE AccountID = @Id";
            using (SqlConnection conn
                = new SqlConnection("Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;"))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Pass", encryptpass);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            return true;
        }
        public bool Delete(string connection, int id)
        {
            string queryString = "DELETE FROM Account WHERE AccountID = @AccountID";
            using (SqlConnection conn
                = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@AccountID", id);
                cmd.ExecuteNonQuery();
            }
            return true;
        }
        public Account GetAccount(int ID)
        {
            string queryString = "SELECT * FROM Account WHERE AccountID = @AccountID";
            using (SqlConnection conn = new SqlConnection("Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;"))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@AccountID", ID);
                Account account = new Account();
                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();

                bool returnValue = dataReader.HasRows;
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    account.Description = rdr["Description"] == DBNull.Value ? null : (string)rdr["Description"];
                    account.AccountID = (int)rdr["AccountID"];
                    account.FirstName = (string)rdr["Firstname"];
                    account.LastName = (string)rdr["Lastname"];
                    account.Email = (string)rdr["Email"];
                    account.DisplayName = (string)rdr["Displayname"];
                }
                conn.Close();
                return account;
            }
        }
        }
    }
