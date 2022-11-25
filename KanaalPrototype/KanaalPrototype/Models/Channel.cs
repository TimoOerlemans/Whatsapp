using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaalPrototype
{
    public class Channel
    {
        public List<Channel> channels { get; set; }
        public string Name { get; set; }
        public int ChannelID { get; set; }
        public Channel(string name, int channelId)
        {
            Name = name;
            ChannelID = channelId;
            channels = new List<Channel>();
        }
        public void MakeChannel(string Name)
        {
            int ChannelID = 0; 
            channels.Add(new Channel(Name, ChannelID));

        }
    }
}
