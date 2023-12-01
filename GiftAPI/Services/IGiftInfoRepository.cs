using GiftInfoLibrary.Models;

namespace GiftAPI.Services
{
    public interface IGiftInfoRepository
    {

        // Methods for searching(filtering) gifts
        
        Task<List<GiftInfo>> SearchGiftsByCategoryAsync(string category);

        Task<List<GiftInfo>> SearchGiftsByAgeAsync(int age);

        Task<List<GiftInfo>> SearchGiftsByGenderAsync(string gender);

        Task<List<GiftInfo>> SearchGiftsByPriceRangeAsync(decimal minPrice, decimal maxPrice);

        Task<List<GiftInfo>> SearchGiftsByGiftNameAsync(string giftName);


        // Methods for managing user's favorite gifts
        Task<bool> AddToParentFavoriteAsync(int pGiftId, int giftId);

        Task<bool> DeleteFromParentFavoriteAsync(int pGiftId, int giftId);

        Task<bool> UpdateParentFavoriteAsync(int pGiftId, List<int> updatedGiftIds);

        // CRUD operations for GiftInfo table
        Task<GiftInfo> GetGiftByIdAsync(int giftId);

        //Task<bool> AddGiftAsync(GiftInfo gift);

        //Task<bool> UpdateGiftAsync(GiftInfo gift);

        //Task<bool> DeleteGiftAsync(int giftId);

        // Method to get the list of gifts favorited by a user
        Task<List<GiftInfo>> GetFavoritedGiftsByParentAsync(int pGiftId);

        Task<bool> SaveAsync();

        //getting list of all gifts
        Task<IEnumerable<GiftInfo>> GetAllGiftsAsync();


        //Task<IEnumerable<GiftInfo>> SearchGiftsAsync(string category, string name, int? age, string gender, decimal? price);

        //Task<bool> AddGiftToFavoritesAsync(int userId, int giftId);

        //Task<List<GiftInfo>> GetGiftsForUserAsync(int userId);

        //Task<bool> RemoveGiftFromFavoritesAsync(int userId, int giftId);

        //Task<IEnumerable<GiftInfo>> GetFavoriteGiftsAsync(int userId);

        //Task<bool> SaveAsync();

        Task AddGiftAsync(GiftInfo gift);

        Task UpdateGiftAsync(GiftInfo gift);

        Task DeleteGiftAsync(int giftId);
        //Task<bool> GiftExistsAsync(int giftId);

        Task<IEnumerable<GiftInfo>> GetGiftInfoesAsync();
        //Task<GiftInfo> GetGiftByIdAsync(int giftId, bool includeUserInfo);


    }
}
