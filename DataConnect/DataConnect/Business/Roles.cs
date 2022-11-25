using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataConnect.Business
{
    public enum Roles
    {
        User,  // in DB = 0
        Moderator, // in DB = 1
        Administrator // in DB = 2
    }
}
