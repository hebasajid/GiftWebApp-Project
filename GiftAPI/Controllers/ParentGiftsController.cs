using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GiftInfoLibraryy.Models;
using AutoMapper;
using GiftAPI.DTOs;
using GiftAPI.Services;
using Microsoft.AspNetCore.JsonPatch;

namespace GiftAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentGiftsController : ControllerBase
    {
        private readonly IParentsGiftsRepository _parentsGiftsRepository;
        private readonly IMapper _mapper;

        public ParentGiftsController(IParentsGiftsRepository parentsGiftsRepository, IMapper mapper)
        {
            _parentsGiftsRepository = parentsGiftsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParentGiftsDto>>> GetAllParentsGifts()
        {
            var parentGifts = await _parentsGiftsRepository.GetAllParentsGiftsAsync();
            var parentGiftsDto = _mapper.Map<IEnumerable<ParentGiftsDto>>(parentGifts);
            return Ok(parentGiftsDto);
        }

        


        [HttpGet("{id}")]
        public async Task<ActionResult<ParentGiftsDto>> GetParentsGiftById(int id)
        {
            var parentGift = await _parentsGiftsRepository.GetParentsGiftByIdAsync(id);

            if (parentGift == null)
            {
                return NotFound();
            }

            var parentGiftDto = _mapper.Map<ParentGiftsDto>(parentGift);
            return Ok(parentGiftDto);
        }

        [HttpPost]
        public async Task<ActionResult<ParentGiftsDto>> AddParentsGift(ParentGiftsDto parentGiftCreateDto)
        {
            var parentGift = _mapper.Map<ParentGift>(parentGiftCreateDto);
            await _parentsGiftsRepository.AddParentsGiftAsync(parentGift);

            return CreatedAtAction(nameof(GetParentsGiftById), new { id = parentGift.PGiftId }, _mapper.Map<ParentGiftsDto>(parentGift));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParentsGift(int id, ParentGiftsDto parentGiftUpdateDto)
        {
            var parentGift = await _parentsGiftsRepository.GetParentsGiftByIdAsync(id);

            if (parentGift == null)
            {
                return NotFound();
            }

            _mapper.Map(parentGiftUpdateDto, parentGift);
            await _parentsGiftsRepository.UpdateParentsGiftAsync(parentGift);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParentsGift(int id)
        {
            var parentGift = await _parentsGiftsRepository.GetParentsGiftByIdAsync(id);

            if (parentGift == null)
            {
                return NotFound();
            }

            await _parentsGiftsRepository.DeleteParentsGiftAsync(id);
            return NoContent();
        }

        // PATCH: api/parentgifts/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchParentGift(int id, [FromBody] JsonPatchDocument<ParentGiftsDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var parentGift = await _parentsGiftsRepository.GetParentsGiftByIdAsync(id);
            if (parentGift == null)
            {
                return NotFound();
            }

            var parentGiftToPatch = _mapper.Map<ParentGiftsDto>(parentGift);
            patchDoc.ApplyTo(parentGiftToPatch, ModelState);

            if (!TryValidateModel(parentGiftToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(parentGiftToPatch, parentGift);
            await _parentsGiftsRepository.UpdateParentsGiftAsync(parentGift);

            return NoContent();
        }


        //[HttpGet]
        //public async Task<IActionResult> GetAllParentsGifts()
        //{
        //    try
        //    {
        //        var parentsGifts = await _parentsGiftsRepository.GetAllParentsGifts();
        //        var parentsGiftsDto = _mapper.Map<IEnumerable<ParentGiftsDto>>(parentsGifts);
        //        return Ok(parentsGiftsDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetParentsGiftById(int id)
        //{
        //    try
        //    {
        //        var parentsGift = await _parentsGiftsRepository.GetParentsGiftById(id);
        //        if (parentsGift == null)
        //            return NotFound();

        //        var parentsGiftDto = _mapper.Map<ParentGiftsDto>(parentsGift);
        //        return Ok(parentsGiftDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddParentsGift([FromBody] ParentGiftsDto parentsGiftDto)
        //{
        //    try
        //    {
        //        if (parentsGiftDto == null)
        //            return BadRequest("ParentGift object is null");

        //        var parentsGift = _mapper.Map<ParentGift>(parentsGiftDto);
        //        await _parentsGiftsRepository.AddParentsGift(parentsGift);

        //        var createdGiftDto = _mapper.Map<ParentGiftsDto>(parentsGift);
        //        return CreatedAtAction(nameof(GetParentsGiftById), new { id = createdGiftDto.PGiftId }, createdGiftDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateParentsGift(int id, [FromBody] ParentGiftsDto parentsGiftDto)
        //{
        //    try
        //    {
        //        var existingParentsGift = await _parentsGiftsRepository.GetParentsGiftById(id);
        //        if (existingParentsGift == null)
        //            return NotFound();

        //        _mapper.Map(parentsGiftDto, existingParentsGift);
        //        await _parentsGiftsRepository.UpdateParentsGift(existingParentsGift);

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteParentsGift(int id)
        //{
        //    try
        //    {
        //        var existingParentsGift = await _parentsGiftsRepository.GetParentsGiftById(id);
        //        if (existingParentsGift == null)
        //            return NotFound();

        //        await _parentsGiftsRepository.DeleteParentsGift(id);

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}


        //    private readonly GiftInfoDbContext _context;

        //    public ParentGiftsController(GiftInfoDbContext context)
        //    {
        //        _context = context;
        //    }

        //    // GET: api/ParentGifts
        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<ParentGift>>> GetParentGifts()
        //    {
        //      if (_context.ParentGifts == null)
        //      {
        //          return NotFound();
        //      }
        //        return await _context.ParentGifts.ToListAsync();
        //    }

        //    // GET: api/ParentGifts/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<ParentGift>> GetParentGift(int id)
        //    {
        //      if (_context.ParentGifts == null)
        //      {
        //          return NotFound();
        //      }
        //        var parentGift = await _context.ParentGifts.FindAsync(id);

        //        if (parentGift == null)
        //        {
        //            return NotFound();
        //        }

        //        return parentGift;
        //    }

        //    // PUT: api/ParentGifts/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutParentGift(int id, ParentGift parentGift)
        //    {
        //        if (id != parentGift.PGiftId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(parentGift).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ParentGiftExists(id))
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

        //    // POST: api/ParentGifts
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<ParentGift>> PostParentGift(ParentGift parentGift)
        //    {
        //      if (_context.ParentGifts == null)
        //      {
        //          return Problem("Entity set 'GiftInfoDbContext.ParentGifts'  is null.");
        //      }
        //        _context.ParentGifts.Add(parentGift);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetParentGift", new { id = parentGift.PGiftId }, parentGift);
        //    }

        //    // DELETE: api/ParentGifts/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteParentGift(int id)
        //    {
        //        if (_context.ParentGifts == null)
        //        {
        //            return NotFound();
        //        }
        //        var parentGift = await _context.ParentGifts.FindAsync(id);
        //        if (parentGift == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.ParentGifts.Remove(parentGift);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool ParentGiftExists(int id)
        //    {
        //        return (_context.ParentGifts?.Any(e => e.PGiftId == id)).GetValueOrDefault();
        //    }
        //}
    }
}
