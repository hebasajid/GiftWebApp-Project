using System;
using System.Collections.Generic;

namespace GiftInfoLibraryy.Models;

public partial class ParentGift
{
    public int PGiftId { get; set; }

    public string GiftName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal GiftPrice { get; set; }

    public string? GiftCategory { get; set; }

    public virtual ICollection<UserFavoriteGift> UserFavoriteGifts { get; set; } = new List<UserFavoriteGift>();
}
