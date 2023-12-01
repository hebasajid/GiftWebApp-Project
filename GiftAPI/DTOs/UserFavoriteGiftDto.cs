namespace GiftAPI.DTOs
{
    public class UserFavoriteGiftDto
    {
        public int UserFavoriteGiftId { get; set; }
        public int PGiftId { get; set; }
        public int GiftId { get; set; }

        public ParentGiftsDto Parent { get; set; }
        public List<GiftInfoDto> FavoritedGifts { get; set; }
    }
}
