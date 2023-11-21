using GiftInfoLibrary.Models;

namespace GiftAPI.DTOs
{
    public class UserInfoDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string UserPass { get; set; } = null!;

        public int? FavoriteGiftId { get; set; }


        //user can have multiple favourited gitfs:
        public ICollection<GiftInfoDto> FavoriteGifts { get; set; } = new List<GiftInfoDto>();

      
      //  public GiftInfoDto FavoriteGift { get; set; }
       // public ICollection<GiftInfoDto> FavoriteGifts { get; set; }

    }
}
