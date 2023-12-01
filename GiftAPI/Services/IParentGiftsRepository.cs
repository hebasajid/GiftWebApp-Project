using GiftInfoLibraryy.Models;

namespace GiftAPI.Services
{
    public interface IParentsGiftsRepository
    {
        Task<ParentGift> GetAllParentsGifts();
        Task<ParentGift> GetParentsGiftById(int pGiftId);
        Task AddParentsGift(ParentGift parentsGift);
        Task UpdateParentsGift(ParentGift parentsGift);
        Task DeleteParentsGift(int pGiftId);
    }

}
