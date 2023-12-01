using GiftInfoLibraryy.Models;

namespace GiftAPI.DTOs
{
    public class GiftInfoDto
    {
        public int GiftId { get; set; }

        public string GiftName { get; set; } = null!;

        public string Description { get; set; }

        public decimal GiftPrice { get; set; }

        public int? GiftAge { get; set; }

        public string GiftCategory { get; set; }

        public string GiftGender { get; set; }

        public string GiftUrl { get; set; }

      

        //user can have many gifts favourited:
      //  public  ICollection<UserInfoDto> UserInfos { get; set; } = new List<UserInfoDto>();

      //  public int? FavoriteUserId { get; set; }
      //  public UserInfoDto FavoriteUser { get; set; }

    }
}
