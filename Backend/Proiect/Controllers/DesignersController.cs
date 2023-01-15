using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.DAL;
using Proiect.DAL.Entities;
using Proiect.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DesignersController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateDesigner(DesignerPostModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                return BadRequest("Invalid object. Model is null");
            }

            var designer = new Designer()
            {
                Id = model.Id,
                Name = model.Name,
                Age = model.Age,
                Gender = model.Gender
            };

            await _context.Designers.AddRangeAsync(designer);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Get All
        [HttpGet("")]
        public async Task<IActionResult> GetAllDesigner()
        {
            var designers = await _context.Designers.Include(x => x.DesignerAddress).Include(x => x.DesignerClients).ToListAsync();

            return Ok(designers);
        }

        // Get by id
        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetDesigner([FromRoute] int id)
        {
            var designer = await _context.Designers.Where(x => x.Id == id).FirstOrDefaultAsync();

            return Ok(designer);
        }

        // Put - facem update la numele unui designer
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] string name)
        {
            var designer = await _context.Designers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            designer.Name = name; // numele introdus de noi

            _context.Entry(designer).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var designerV2 = await _context.Designers.FirstOrDefaultAsync(x => x.Id == id);

            return Ok();
        }

        //Delete - stergem un designer dupa id-ul introdus de noi 
        [HttpDelete("")]
        public async Task<IActionResult> DeleteDesigner(int id)
        {
            var designer = await _context.Designers.FirstOrDefaultAsync(x => x.Id == id);

            if (designer == null)
            {
                return NotFound($"Designer with Id = {id} not found");
            }

            _context.Designers.Remove(designer);

            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
