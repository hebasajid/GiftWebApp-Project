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
using Microsoft.AspNetCore.JsonPatch;

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
        public async Task<ActionResult<IEnumerable<GiftInfoDto>>> GetGiftInfoes()
        {
            var giftInfos = await _giftInfoRepository.GetGiftInfoesAsync();
            var giftInfosDto = _mapper.Map<IEnumerable<GiftInfoDto>>(giftInfos);
            return Ok(giftInfosDto);
        }


        // GET: api/GiftInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GiftInfoDto>> GetGiftInfo(int id)
        {
            var giftInfo = await _giftInfoRepository.GetGiftByIdAsync(id);

            if (giftInfo == null)
            {
                return NotFound();
            }

            var giftInfoDto = _mapper.Map<GiftInfoDto>(giftInfo);
            return Ok(giftInfoDto);
        }


        // POST: api/GiftInfoes
        [HttpPost]
        public async Task<ActionResult<GiftInfoDto>> PostGiftInfo(GiftInfoDto giftInfoDto)
        {
            var giftInfo = _mapper.Map<GiftInfo>(giftInfoDto);
            await _giftInfoRepository.AddGiftAsync(giftInfo);

            return CreatedAtAction(nameof(GetGiftInfo), new { id = giftInfo.GiftId }, giftInfoDto);
        }


        // PUT: api/GiftInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiftInfo(int id, GiftInfoDto giftInfoDto)
        {
            if (id != giftInfoDto.GiftId)
            {
                return BadRequest();
            }

            var giftInfo = _mapper.Map<GiftInfo>(giftInfoDto);
            await _giftInfoRepository.UpdateGiftAsync(giftInfo);

            return NoContent();
        }

        // DELETE: api/GiftInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiftInfo(int id)
        {
            var giftInfo = await _giftInfoRepository.GetGiftByIdAsync(id);

            if (giftInfo == null)
            {
                return NotFound();
            }

            await _giftInfoRepository.DeleteGiftAsync(id);

            return NoContent();
        }

        // PATCH: api/GiftInfoes/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchGiftInfo(int id, [FromBody] JsonPatchDocument<GiftInfoDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var giftInfo = await _giftInfoRepository.GetGiftByIdAsync(id);
            if (giftInfo == null)
            {
                return NotFound();
            }

            var giftInfoDto = _mapper.Map<GiftInfoDto>(giftInfo);
            patchDoc.ApplyTo(giftInfoDto);


            if (!TryValidateModel(giftInfoDto))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(giftInfoDto, giftInfo);
            await _giftInfoRepository.UpdateGiftAsync(giftInfo);

            return NoContent();
        }


        //[HttpGet("{id}")]
        //public async Task<ActionResult<GiftInfoDto>> GetGiftById(int id)
        //{
        //    var gift = await _giftInfoRepository.GetGiftByIdAsync(id, includeUserInfo: true);
        //    if (gift == null)
        //    {
        //        return NotFound();
        //    }
        //    var giftDto = _mapper.Map<GiftInfoDto>(gift);
        //    return Ok(giftDto);
        //}

        //[HttpPost]
        //public async Task<ActionResult<GiftInfoDto>> CreateGift(GiftInfoDto giftDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var gift = _mapper.Map<GiftInfo>(giftDto);
        //    await _giftInfoRepository.AddGiftAsync(gift);
        //    await _giftInfoRepository.SaveAsync();

        //    return CreatedAtAction(nameof(GetGiftById), new { id = gift.GiftId }, _mapper.Map<GiftInfoDto>(gift));
        //}


        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateGift(int id, GiftInfoDto giftDto)
        //{
        //    if (id != giftDto.GiftId)
        //    {
        //        return BadRequest();
        //    }

        //    var existingGift = await _giftInfoRepository.GetGiftByIdAsync(id, includeUserInfo: false);
        //    if (existingGift == null)
        //    {
        //        return NotFound();
        //    }

        //    _mapper.Map(giftDto, existingGift);
        //    _giftInfoRepository.UpdateGiftAsync(existingGift);
        //    await _giftInfoRepository.SaveAsync();

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGift(int id)
        //{
        //    var giftExists = await _giftInfoRepository.GiftExistsAsync(id);
        //    if (!giftExists)
        //    {
        //        return NotFound(); // Return 404 if the gift doesn't exist
        //    }

        //    await _giftInfoRepository.DeleteGiftAsync(id);
        //    return NoContent(); // Return 204 (No Content) upon successful deletion
        //}



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
