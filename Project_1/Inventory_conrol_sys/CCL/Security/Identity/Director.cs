using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Director
       : User
    {
        public Director(int userId, string name, int systeamId)
            : base(userId, name, systeamId, nameof(Director))
        {
        }
    }
}
