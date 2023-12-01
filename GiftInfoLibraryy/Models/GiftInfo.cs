using System;
using System.Collections.Generic;

namespace GiftInfoLibraryy.Models;

public partial class GiftInfo
{
    public int GiftId { get; set; }

    public string GiftName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal GiftPrice { get; set; }

    public int? GiftAge { get; set; }

    public string? GiftCategory { get; set; }

    public string? GiftGender { get; set; }

    public string? GiftUrl { get; set; }

    public virtual ICollection<UserFavoriteGift> UserFavoriteGifts { get; set; } = new List<UserFavoriteGift>();
}
