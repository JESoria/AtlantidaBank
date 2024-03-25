using System;
using System.Collections.Generic;

namespace AtlantidaBankAPI.Models
{
    public partial class ECrediCardUser
    {
        public int CrediCardUserId { get; set; }
        public int UserId { get; set; }
        public int CrediCardId { get; set; }
        public bool Active { get; set; }

        public virtual ECrediCard CrediCard { get; set; } = null!;
        public virtual EUser User { get; set; } = null!;
    }
}
