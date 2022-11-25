using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataConnect.Business;
using System.Data.SqlClient;
using System.Data;

namespace DataConnect
{
    public class ChannelDAL
    {  
        public bool AddChannel(string connection, Channel channel)
        {
            string queryString = "INSERT INTO Channel(Name, Description) VALUES (@Na, @De);";
            using (SqlConnection conn
                = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Na", channel.Name);
                cmd.Parameters.AddWithValue("@De", channel.Description);
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeleteChannel(string connection,int id)
        {
            string queryString = "DELETE FROM CHANNEL WHERE ChannelID = @ChannelID";
            using (SqlConnection conn
                = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@ChannelID", id);
                cmd.ExecuteNonQuery();
            }
                return true;
        }

        public List<Channel> Allchannel(string connection)
        {
            List<Channel> channels = new List<Channel>();

            string queryString = "SELECT * FROM Channel;";
            using (SqlConnection conn =
                new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Channel channel = new Channel((int)rdr["ChannelID"], (string)rdr["Name"], (string)rdr["Description"]);
                    channels.Add(channel);
                }
            }
            return channels;
        }

        public bool EditChannel(string connection, Channel channel)
        {
            try
            {


                string queryString = "UPDATE Channel SET Name = @Na, Description = @De WHERE ChannelID = @Id";
                using (SqlConnection conn =
                   new SqlConnection(connection))
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
        public Channel GetChannelById(int ID)
        {
            string queryString = "SELECT * FROM Channel WHERE ChannelID = @ChannelID";
            using (SqlConnection conn = new SqlConnection("Server=mssql.fhict.local;Database=dbi459002_datacon;User Id=dbi459002_datacon;Password=#Tijdelijkwachtwoord;"))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@ChannelID", ID);

                SqlDataReader dataReader;
                dataReader = cmd.ExecuteReader();
                Channel channel = new Channel();

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
