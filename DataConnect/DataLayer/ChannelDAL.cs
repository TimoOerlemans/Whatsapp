using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataConnect
{
    public class ChannelDAL : IChannelContainer
    {

        static string ConnectionString = "Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;";
        public SqlConnection conn = new SqlConnection(ConnectionString);
        public bool AddChannel(ChannelDTO channel)
        {
            string queryString = "INSERT INTO Channel(Name, Description) VALUES (@Na, @De);";
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Na", channel.Name);
                cmd.Parameters.AddWithValue("@De", channel.Description);
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeleteChannel(int id)
        {
            string queryString = "DELETE FROM CHANNEL WHERE ChannelID = @ChannelID";
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@ChannelID", id);
                cmd.ExecuteNonQuery();
            }
                return true;
        }

        public List<ChannelDTO> Allchannel()
        {
            List<ChannelDTO> channels = new List<ChannelDTO>();

            string queryString = "SELECT * FROM Channel;";
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ChannelDTO channel = new ChannelDTO();
                    channel.Id = (int)rdr["ChannelID"];
                    channel.Name = (string)rdr["Name"];
                    channel.Description = (string)rdr["Description"];
                    channels.Add(channel);
                }
            }
            return channels;
        }

        public bool EditChannel(ChannelDTO channel)
        {
            try
            {
                string queryString = "UPDATE Channel SET Name = @Na, Description = @De WHERE ChannelID = @Id";
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand(queryString, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Na", channel.Name);
                    cmd.Parameters.AddWithValue("@De", channel.Description);
                    cmd.Parameters.AddWithValue("Id", channel.Id);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ChannelDTO GetChannelById(int ID)
        {
            string queryString = "SELECT * FROM Channel WHERE ChannelID = @ChannelID";
            using (SqlConnection conn = new SqlConnection("Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;"))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@ChannelID", ID);

                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();
                ChannelDTO channel = new ChannelDTO();

                while (dataReader.Read())
                {
                    channel.Id = (int)dataReader["ChannelID"];
                    channel.Name = (string)dataReader["Name"];
                    channel.Description = (string)dataReader["Description"];
                }
                return channel;
            }
        }
    }
}
