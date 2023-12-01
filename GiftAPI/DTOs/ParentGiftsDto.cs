using GiftInfoLibrary.Models;

namespace GiftAPI.DTOs
{
    public class ParentGiftsDto
    {
        public int PGiftId { get; set; }

        public string GiftName { get; set; } = null!;

        public string Description { get; set; }

        public decimal GiftPrice { get; set; }

        public string GiftCategory { get; set; }



    }
}
