using System;
using System.Collections.Generic;

namespace AtlantidaBankAPI.Models
{
    public partial class EUser
    {
        public EUser()
        {
            ECrediCardUsers = new HashSet<ECrediCardUser>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<ECrediCardUser> ECrediCardUsers { get; set; }
    }
}
