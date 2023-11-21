using System;
using System.Collections.Generic;

namespace GiftInfoLibrary.Models;

public partial class UserFavoriteGift
{
    public int UserFavoriteGiftId { get; set; }

    public int? UserId { get; set; }

    public int? GiftId { get; set; }

    public virtual GiftInfo? Gift { get; set; }

    public virtual UserInfo? User { get; set; }
}
