using InterfaceLayer;

namespace LogicLayer
{
    public class Channel
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        
            public Channel(ChannelDTO channelDTO)
            {
            this.Id = channelDTO.Id;
            this.Name = channelDTO.Name;
            this.Description = channelDTO.Description;
            }
            public Channel(int id, string name, string description)
            {
                this.Id = id;
                this.Name = name;
                this.Description = description;
            }
            public Channel()
            {

            }

            public Channel(int id)
            {
                Id = id;
            }
    }
}
