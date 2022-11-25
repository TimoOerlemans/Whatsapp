using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataConnect.Models
{
    public class Channels_AccountViewModel
    {
        public List<ChannelViewModel> Channels { get; set; }

        public AccountViewModel Account { get; set; }
        public Channel channel { get; set; }

        public Channels_AccountViewModel (List<ChannelViewModel> channels, AccountViewModel account)
        {
            this.Channels = channels;
            this.Account = account;
        }        
    }
}
