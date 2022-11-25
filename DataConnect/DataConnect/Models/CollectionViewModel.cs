using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataConnect.Models
{
    public class CollectionViewModel
    {
        public List<ChannelViewModel> channelvms { get; set; }
        public AccountViewModel uservm { get; set; }
    }
}
