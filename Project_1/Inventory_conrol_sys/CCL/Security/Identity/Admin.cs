﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Admin
        : User
    {
        public Admin(int userId, string name, int systeamId)
            : base(userId, name, systeamId, nameof(Admin))
        {
        }
    }
}
