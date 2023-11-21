using GiftAPI.Services;
using GiftInfoLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace GiftInfoAPI.Services
{
    public class GiftInfoRepository : IGiftInfoRepository
    {
        private GiftInfoDbContext _context;

        public GiftInfoRepository(GiftInfoDbContext context)
        {

            _context = context;
        }

        public async Task AddGiftAsync(GiftInfo gift)
        {
            await _context.GiftInfos.AddAsync(gift);
        }

        public async Task UpdateGiftAsync(GiftInfo gift)
        {
            _context.Entry(gift).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGiftAsync(int giftId)
        {
            var giftToDelete = await _context.GiftInfos.FindAsync(giftId);

            if (giftToDelete != null)
            {
                _context.GiftInfos.Remove(giftToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GiftInfo>> GetGiftInfoesAsync()
        {
            return await _context.GiftInfos.ToListAsync();
        }

        public async Task<IEnumerable<GiftInfo>> GetAllGiftsAsync()
        {
            return await _context.GiftInfos.ToListAsync();
        }

        public async Task<GiftInfo> GetGiftByIdAsync(int giftId)
        {
            var gift = await _context.GiftInfos.FindAsync(giftId);
            return gift;
        }







        public async Task<bool> GiftExistsAsync(int giftId)
        {
            return await _context.GiftInfos.AnyAsync<GiftInfo>(g => g.GiftId == giftId);
        }


        public async Task<bool> AddToUserFavoriteAsync(int userId, int giftId)
        {
            // checking if the user and gift exist in the database
            var user = await _context.UserInfos.FindAsync(userId);
            var gift = await _context.GiftInfos.FindAsync(giftId);

            if (user != null && gift != null)
            {
               
                // Check if the user already has the gift in favorites
                var isAlreadyFavorite = await _context.UserFavoriteGifts
                    .AnyAsync(ufg => ufg.UserId == userId && ufg.GiftId == giftId);

                if (!isAlreadyFavorite)
                {
                    // If the gift is not already a favorite add it to the users favorites
                    var userFavoriteGift = new UserFavoriteGift
                    {
                        UserId = userId,
                        GiftId = giftId
                    };

                    _context.UserFavoriteGifts.Add(userFavoriteGift);
                    await _context.SaveChangesAsync();
                    return true; //  success
                }
                else
                {
                    // The gift is already a favorite for this user
                  
                    return false; // Return false indicating that the gift is already a favorite
                }
            }

            return false; // Return false if user or gift is not found
        }


        public async Task<bool> DeleteFromUserFavoriteAsync(int userId, int giftId)
        {
            // Check if the user and gift exist in the database
            var user = await _context.UserInfos.FindAsync(userId);
            var gift = await _context.GiftInfos.FindAsync(giftId);

            if (user != null && gift != null)
            {
                // Check if the gift is in the user's favorites
                var userFavoriteGift = await _context.UserFavoriteGifts
                    .FirstOrDefaultAsync(ufg => ufg.UserId == userId && ufg.GiftId == giftId);

                if (userFavoriteGift != null)
                {
                    // If the user has favorited the gift, remove it from favorites
                    _context.UserFavoriteGifts.Remove(userFavoriteGift);
                    await _context.SaveChangesAsync();
                    return true; // Return true for success
                }
                else
                {
                    // The gift is not in the user's favorites
                   
                    return false; // Return false indicating that the gift was not in favorites
                }
            }

            return false; // Return false if user or gift is not found
        }

        public async Task<bool> UpdateUserFavoriteAsync(int userId, List<int> updatedGiftIds)
        {
            // Check if the user exists in the database
            var user = await _context.UserInfos.FindAsync(userId);

            if (user != null)
            {
                // Clear existing favorite gifts for the user
                var userFavorites = _context.UserFavoriteGifts.Where(ufg => ufg.UserId == userId);
                _context.UserFavoriteGifts.RemoveRange(userFavorites);

                // Add updated gifts as user's favorites
                foreach (var giftId in updatedGiftIds)
                {
                    // Check if the gift exists in the database
                    var gift = await _context.GiftInfos.FindAsync(giftId);

                    if (gift != null)
                    {
                        var userFavoriteGift = new UserFavoriteGift
                        {
                            UserId = userId,
                            GiftId = giftId
                        };

                        _context.UserFavoriteGifts.Add(userFavoriteGift);
                    }
                    else
                    {
                        // Handle case where the gift doesn't exist
                        
                    }
                }

                await _context.SaveChangesAsync();
                return true; // Return true for success
            }

            return false; // Return false if user is not found
        }

        public async Task<List<GiftInfo>> GetFavoritedGiftsByUserAsync(int userId)
        {
            var favoritedGifts = await _context.UserFavoriteGifts
                .Where(ufg => ufg.UserId == userId)
                .Select(ufg => ufg.GiftId)
                .ToListAsync();

            var gifts = await _context.GiftInfos
                .Where(g => favoritedGifts.Contains(g.GiftId))
                .ToListAsync();

            return gifts;
        }














        public async Task<IEnumerable<GiftInfo>> SearchGiftsAsync(string category, string name, int? age, string gender, decimal? price)
        {
            var query = _context.GiftInfos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(g => g.GiftCategory == category);

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(g => g.GiftName.Contains(name));

            if (age.HasValue)
                query = query.Where(g => g.GiftAge == age);

            if (!string.IsNullOrWhiteSpace(gender))
                query = query.Where(g => g.GiftGender == gender);

            if (price.HasValue)
                query = query.Where(g => g.GiftPrice == price);

            return await query.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }




        //filtering gifts:

        public async Task<List<GiftInfo>> SearchGiftsByCategoryAsync(string category)
        {
            return await _context.GiftInfos
                .Where(g => g.GiftName == category)
                .ToListAsync();
        }

        public async Task<List<GiftInfo>> SearchGiftsByAgeAsync(int age)
        {
            return await _context.GiftInfos
                .Where(g => g.GiftAge <= age && g.GiftAge >= age)
                .ToListAsync();
        }

        public async Task<List<GiftInfo>> SearchGiftsByGenderAsync(string gender)
        {
            return await _context.GiftInfos
                .Where(g => g.GiftGender == gender || g.GiftGender == "Unisex")
                .ToListAsync();
        }

        public async Task<List<GiftInfo>> SearchGiftsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _context.GiftInfos
                .Where(g => g.GiftPrice >= minPrice && g.GiftPrice <= maxPrice)
                .ToListAsync();
        }

        public async Task<List<GiftInfo>> SearchGiftsByGiftNameAsync(string giftName)
        {
            return await _context.GiftInfos
                .Where(g => g.GiftName.Contains(giftName))
                .ToListAsync();
        }

        //Task<bool> IGiftInfoRepository.AddGiftAsync(GiftInfo gift)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<bool> IGiftInfoRepository.UpdateGiftAsync(GiftInfo gift)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<bool> IGiftInfoRepository.DeleteGiftAsync(int giftId)
        //{
        //    throw new NotImplementedException();
        //}

    }
}