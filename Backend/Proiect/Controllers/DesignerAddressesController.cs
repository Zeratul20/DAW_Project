using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect.DAL;
using Proiect.DAL.Entities;
using Proiect.DAL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Controllers
{
    [Route("api/designerAddresses")]
    [ApiController]

    public class DesignerAddressesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DesignerAddressesController(AppDbContext context)
        {
            _context = context;
        }

        // Post
        [HttpPost]
        // [Authorize("Admin")]
        public async Task<IActionResult> CreateDesigner(DesignerAddressPostModel model)
        {
            if (string.IsNullOrEmpty(model.City))
            {
                return BadRequest("Invalid object. Model is null");
            }

            var designerAddress = new DesignerAddress()
            {
                Id = model.Id,
                City = model.City,
                Zipcode = model.Zipcode,
                DesignerId = model.DesignerId
            };

            await _context.DesignerAddresses.AddRangeAsync(designerAddress);
            await _context.SaveChangesAsync();

            return Ok();
        }
       
        // Get-join  - afiseaza adresa designerilor care au numele introdus de noi
        [HttpGet("get-join/{nume}")]
        // [Authorize("Admin")]
        // [Authorize("Designer")]
        public async Task<IActionResult> GetDesignerAddressJoin([FromRoute] string nume)
        {
            var addresses = await _context
                .DesignerAddresses
                .Include(x => x.Designer)
                .Where(x => x.Designer.Name == nume)
                .ToListAsync();

            return Ok(addresses);
        }

        // Put - facem update la zipcode
        [HttpPut]
        [Authorize("Admin")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] int zipcode)
        {
            var address = await _context.DesignerAddresses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            address.Zipcode = zipcode; // zipcode-ul introdus de noi 
            _context.DesignerAddresses.Attach(address);
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var address2 = await _context.DesignerAddresses.FirstOrDefaultAsync(x => x.Id == id);
            return Ok();
        }

        // Delete - stergem adresele designerilor care au peste 40 de ani
        [HttpDelete]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteAddress()
        {
            var addresses = await _context
                 .DesignerAddresses
                 .Include(x => x.Designer)
                 .Where(x => x.Designer.Age > 40)
                 .ToListAsync();

            if ( addresses == null)
            {
                return NotFound("Designer with age > 40 not found");
            }

            foreach (var ad in addresses)
            {
                _context.DesignerAddresses.Remove(ad);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
