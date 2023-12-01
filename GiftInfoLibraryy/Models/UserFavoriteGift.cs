using System;
using System.Collections.Generic;

namespace GiftInfoLibraryy.Models;

public partial class UserFavoriteGift
{
    public int UserFavoriteGiftId { get; set; }

    public int? PGiftId { get; set; }

    public int? GiftId { get; set; }

    public virtual GiftInfo? Gift { get; set; }

    public virtual ParentGift? PGift { get; set; }
}
