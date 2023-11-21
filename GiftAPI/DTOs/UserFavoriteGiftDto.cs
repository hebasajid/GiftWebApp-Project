namespace GiftAPI.DTOs
{
    public class UserFavoriteGiftDto
    {
        public int UserFavoriteGiftId { get; set; }
        public int UserId { get; set; }
        public int GiftId { get; set; }

        public UserInfoDto User { get; set; }
        public List<GiftInfoDto> FavoritedGifts { get; set; }
    }
}
