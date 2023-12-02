using GiftInfoLibraryy.Models;

namespace GiftAPI.Services
{
    public interface IParentsGiftsRepository
    {

        Task<IEnumerable<ParentGift>> GetAllParentsGiftsAsync();
        Task<ParentGift> GetParentsGiftByIdAsync(int pGiftId);

        Task AddParentsGiftAsync(ParentGift parentsGift);
        Task UpdateParentsGiftAsync(ParentGift parentsGift);
        Task DeleteParentsGiftAsync(int pGiftId);

        //Task<ParentGift> GetAllParentsGifts();
        //Task<ParentGift> GetParentsGiftById(int pGiftId);

        //Task AddParentsGift(ParentGift parentsGift);
        //Task UpdateParentsGift(ParentGift parentsGift);
        //Task DeleteParentsGift(int pGiftId);
    }

}
