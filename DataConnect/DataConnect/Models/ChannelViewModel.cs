using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataConnect.Business;

namespace DataConnect.Models
{

    public class ChannelViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        public string Description { get; set; }
        public string Acces { get; set; }

        public ChannelViewModel(Channel channel)
        {
            Id = channel.Id;
            Name = channel.Name;
            Description = channel.Description;
        }
        public ChannelViewModel()
        {

        }
    }
}
