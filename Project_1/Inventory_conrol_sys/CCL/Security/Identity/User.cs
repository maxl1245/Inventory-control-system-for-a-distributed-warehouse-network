using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string name, int systeamId, string userType)
        {
            UserId = userId;
            Name = name;
            SysteamID = systeamId;
            UserType = userType;
        }
        public int UserId { get; }
        public string Name { get; }
        public int SysteamID { get; }
        protected string UserType { get; }
    }
}
