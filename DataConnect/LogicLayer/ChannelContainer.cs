
using System.Collections.Generic;
using InterfaceLayer;

namespace LogicLayer
{
    public class ChannelContainer
    {
        IChannelContainer IChannelContainer;
        public bool AddChannel(Channel channel)
        {
            ChannelDTO channelDTO = new ChannelDTO();
            channelDTO.Description = channel.Description;
            channelDTO.Id = channel.Id;
            channelDTO.Name = channel.Name;
            return IChannelContainer.AddChannel(channelDTO);
        }
        public bool DeleteChannel(int id)
        {
            return IChannelContainer.DeleteChannel(id);
        }
        public List<Channel> Allchannel()
        {
            List<ChannelDTO> ChannelTemp = IChannelContainer.Allchannel();
            List<Channel> channels = new List<Channel>();
            foreach (ChannelDTO channelDTO in ChannelTemp)
            {
                channels.Add(new Channel(channelDTO));
            }
            return (channels);
        }
        public bool EditChannel(Channel channel)
        {
            ChannelDTO channelDTO = new ChannelDTO();
            channelDTO.Description = channel.Description;
            channelDTO.Id = channel.Id;
            channelDTO.Name = channel.Name;
            return IChannelContainer.EditChannel(channelDTO);
        }
        public Channel GetChannelById(int ID)
        {
            Channel channel = new Channel(IChannelContainer.GetChannelById(ID));
            return channel;
        }
    }
}
