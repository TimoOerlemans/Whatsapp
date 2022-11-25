using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLayer
{
    public interface IChannelContainer
    {
        public bool AddChannel(ChannelDTO channel);
        public bool DeleteChannel(int id);
        public List<ChannelDTO> Allchannel();
        public bool EditChannel(ChannelDTO channel);
        public ChannelDTO GetChannelById(int ID);
    }
}
