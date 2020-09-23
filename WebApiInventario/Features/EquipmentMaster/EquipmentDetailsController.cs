using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiInventario.Features.Models;

namespace WebApiInventario.Features.EquipmentMaster
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentDetailsController : ControllerBase
    {
        private readonly Context _context;

        public EquipmentDetailsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDetail>>> GetDetails()
        {
            return await _context.Details.Include(q => q.Equipments).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEquipmentDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipmentDetail = await _context.Details.FindAsync(id);

            if (equipmentDetail == null)
            {
                return NotFound();
            }

            return Ok(equipmentDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipmentDetail([FromRoute] int id, [FromBody] EquipmentDetail equipmentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipmentDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipmentDetail).State = EntityState.Modified;

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostEquipmentDetail([FromBody] EquipmentDetail equipmentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Details.Add(equipmentDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipmentDetail", new { id = equipmentDetail.Id }, equipmentDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipmentDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipmentDetail = await _context.Details.FindAsync(id);
            if (equipmentDetail == null)
            {
                return NotFound();
            }

            _context.Details.Remove(equipmentDetail);
            await _context.SaveChangesAsync();

            return Ok(equipmentDetail);
        }

        private bool EquipmentDetailExists(int id)
        {
            return _context.Details.Any(e => e.Id == id);
        }
    }
}