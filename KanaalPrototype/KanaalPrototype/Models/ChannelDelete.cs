using KanaalPrototype;
using System;
using System.Collections.Generic;

namespace ChannelDelete
{
    class ChannelDelete
    {
        public List<ChannelDelete> channels { get; set; }
        public int Id { get;  set; }
        public string Name { get; set; }
        public string Acces { get; set; }

        public ChannelDelete(int id, string name, string acces)
        {
            channels = new List<ChannelDelete>();
            Id = id;
            Name = name;
            Acces = acces;
        }

        public void channelsDelete(int id, string name, string acces)
        {
            channels.Remove(new ChannelDelete(id, name, acces));
        }
        /*
        public void ChannelDelete(int ChannelId)
        {
            string table = "Channels";

            using (SqlConnection con = new SqlConnection(Global.connectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM " + table + " WHERE 'ChannelId' " = ChannelId, con))
                {
                    command.ExecuteNonQuery();
                }
                con.Close();
            }

        }
        */
    }
}