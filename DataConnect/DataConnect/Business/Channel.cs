using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataConnect
{
    public class Channel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
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
