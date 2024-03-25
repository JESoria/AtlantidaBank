using System;
using System.Collections.Generic;

namespace AtlantidaBankAPI.Models
{
    public partial class CStatusCrediCard
    {
        public CStatusCrediCard()
        {
            ECrediCards = new HashSet<ECrediCard>();
        }

        public int StatusCrediCardId { get; set; }
        public string StatusCrediCard { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<ECrediCard> ECrediCards { get; set; }
    }
}
