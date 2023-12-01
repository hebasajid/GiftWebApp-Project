using System;
using System.Collections.Generic;

namespace GiftInfoLibrary.Models;

public partial class ParentGifts
{
    public int PGiftId { get; set; }

    public string GiftName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal GiftPrice { get; set; }

    public string? GiftCategory { get; set; }

    public virtual ICollection<UserFavoriteGift> UserFavoriteGifts { get; set; } = new List<UserFavoriteGift>();
}
