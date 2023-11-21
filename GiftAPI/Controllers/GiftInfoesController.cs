using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftInfoLibrary.Models;
using AutoMapper;
using GiftAPI.Services;
using GiftAPI.DTOs;

namespace GiftAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftInfoesController : ControllerBase
    {
        private readonly IGiftInfoRepository _giftInfoRepository;
        private readonly IMapper _mapper;

        public GiftInfoesController(IGiftInfoRepository giftInfoRepository, IMapper mapper)
        {
            _giftInfoRepository = giftInfoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiftInfoDto>>> GetGifts()
        {
            var gifts = await _giftInfoRepository.GetGiftInfoesAsync();
            var giftDtos = _mapper.Map<IEnumerable<GiftInfoDto>>(gifts);
            return Ok(giftDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GiftInfoDto>> GetGiftById(int id)
        {
            var gift = await _giftInfoRepository.GetGiftByIdAsync(id, includeUserInfo: true);
            if (gift == null)
            {
                return NotFound();
            }
            var giftDto = _mapper.Map<GiftInfoDto>(gift);
            return Ok(giftDto);
        }

        [HttpPost]
        public async Task<ActionResult<GiftInfoDto>> CreateGift(GiftInfoDto giftDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var gift = _mapper.Map<GiftInfo>(giftDto);
            await _giftInfoRepository.AddGiftAsync(gift);
            await _giftInfoRepository.SaveAsync();

            return CreatedAtAction(nameof(GetGiftById), new { id = gift.GiftId }, _mapper.Map<GiftInfoDto>(gift));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGift(int id, GiftInfoDto giftDto)
        {
            if (id != giftDto.GiftId)
            {
                return BadRequest();
            }

            var existingGift = await _giftInfoRepository.GetGiftByIdAsync(id, includeUserInfo: false);
            if (existingGift == null)
            {
                return NotFound();
            }

            _mapper.Map(giftDto, existingGift);
            _giftInfoRepository.UpdateGiftAsync(existingGift);
            await _giftInfoRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGift(int id)
        {
            var giftExists = await _giftInfoRepository.GiftExistsAsync(id);
            if (!giftExists)
            {
                return NotFound(); // Return 404 if the gift doesn't exist
            }

            await _giftInfoRepository.DeleteGiftAsync(id);
            return NoContent(); // Return 204 (No Content) upon successful deletion
        }



        //  private readonly GiftInfoDbContext _context;

        //    public GiftInfoesController(GiftInfoDbContext context)
        //    {
        //        _context = context;
        //    }

        //    // GET: api/GiftInfoes
        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<GiftInfo>>> GetGiftInfos()
        //    {
        //      if (_context.GiftInfos == null)
        //      {
        //          return NotFound();
        //      }
        //        return await _context.GiftInfos.ToListAsync();
        //    }

        //    // GET: api/GiftInfoes/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<GiftInfo>> GetGiftInfo(int id)
        //    {
        //      if (_context.GiftInfos == null)
        //      {
        //          return NotFound();
        //      }
        //        var giftInfo = await _context.GiftInfos.FindAsync(id);

        //        if (giftInfo == null)
        //        {
        //            return NotFound();
        //        }

        //        return giftInfo;
        //    }

        //    // PUT: api/GiftInfoes/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutGiftInfo(int id, GiftInfo giftInfo)
        //    {
        //        if (id != giftInfo.GiftId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(giftInfo).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GiftInfoExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/GiftInfoes
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<GiftInfo>> PostGiftInfo(GiftInfo giftInfo)
        //    {
        //      if (_context.GiftInfos == null)
        //      {
        //          return Problem("Entity set 'GiftInfoDbContext.GiftInfos'  is null.");
        //      }
        //        _context.GiftInfos.Add(giftInfo);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetGiftInfo", new { id = giftInfo.GiftId }, giftInfo);
        //    }

        //    // DELETE: api/GiftInfoes/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteGiftInfo(int id)
        //    {
        //        if (_context.GiftInfos == null)
        //        {
        //            return NotFound();
        //        }
        //        var giftInfo = await _context.GiftInfos.FindAsync(id);
        //        if (giftInfo == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.GiftInfos.Remove(giftInfo);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool GiftInfoExists(int id)
        //    {
        //        return (_context.GiftInfos?.Any(e => e.GiftId == id)).GetValueOrDefault();
        //    }
        //}
    }
}
