using System;
using System.Collections.Generic;

namespace GiftInfoLibrary.Models;

public partial class UserInfo
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string UserPass { get; set; } = null!;

    public virtual ICollection<UserFavoriteGift> UserFavoriteGifts { get; set; } = new List<UserFavoriteGift>();
}
