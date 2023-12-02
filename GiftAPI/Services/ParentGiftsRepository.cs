using GiftInfoLibraryy.Models;
using Microsoft.EntityFrameworkCore;

namespace GiftAPI.Services
{
    public class ParentsGiftsRepository : IParentsGiftsRepository
    {
        private GiftInfoDbContext _context;

        public ParentsGiftsRepository(GiftInfoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParentGift>> GetAllParentsGiftsAsync()
        {
            return await _context.ParentGifts.ToListAsync();
        }

        public async Task<ParentGift> GetParentsGiftByIdAsync(int pGiftId)
        {
            return await _context.ParentGifts.FirstOrDefaultAsync(p => p.PGiftId == pGiftId);
        }

        public async Task AddParentsGiftAsync(ParentGift parentsGift)
        {
            _context.ParentGifts.Add(parentsGift);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateParentsGiftAsync(ParentGift parentsGift)
        {
            _context.Entry(parentsGift).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteParentsGiftAsync(int pGiftId)
        {
            var parentsGift = await _context.ParentGifts.FindAsync(pGiftId);
            if (parentsGift != null)
            {
                _context.ParentGifts.Remove(parentsGift);
                await _context.SaveChangesAsync();
            }
        }

       

        


        //    public ParentsGiftsRepository(GiftInfoDbContext context)
        //    {
        //        _context = context;
        //    }

        //    public async Task<IEnumerable<ParentGift>> GetAllParentsGifts()
        //    {
        //        return await _context.ParentGifts.ToListAsync();
        //    }

        //    public async Task<ParentGift> GetParentsGiftById(int pGiftId)
        //    {
        //        return await _context.ParentGifts.FindAsync(pGiftId);
        //    }

        //    public async Task AddParentsGift(ParentGift parentsGift)
        //    {
        //        _context.ParentGifts.Add(parentsGift);
        //        await _context.SaveChangesAsync();
        //    }

        //    public async Task UpdateParentsGift(ParentGift parentsGift)
        //    {
        //        _context.Entry(parentsGift).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //    }

        //    public async Task DeleteParentsGift(int pGiftId)
        //    {
        //        var parentsGift = await _context.ParentGifts.FindAsync(pGiftId);
        //        if (parentsGift != null)
        //        {
        //            _context.ParentGifts.Remove(parentsGift);
        //            await _context.SaveChangesAsync();
        //        }
        //    }

        //    Task<ParentGift> IParentsGiftsRepository.GetAllParentsGifts()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

    }
}
