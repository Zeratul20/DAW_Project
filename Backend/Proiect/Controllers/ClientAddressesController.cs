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
    [Route("api/[controller]")]
    [ApiController]

    public class ClientAddressesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientAddressesController(AppDbContext context)
        {
            _context = context;
        }

        // Post
        [HttpPost]
        // [Authorize("Admin")]
        public async Task<IActionResult> CreateClient(ClientAddressPostModel model)
        {
            if (string.IsNullOrEmpty(model.City))
            {
                return BadRequest("Invalid object. Model is null");
            }

            var clientAddress = new ClientAddress()
            {
                Id = model.Id,
                City = model.City,
                Zipcode = model.Zipcode,
                ClientId = model.ClientId
            };

            await _context.ClientAddresses.AddRangeAsync(clientAddress);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Get-join  - afiseaza adresa clientilor care au numele introdus de noi
        [HttpGet("get-join/{nume}")]
        // [Authorize("Admin")]
        public async Task<IActionResult> GetClientAddressJoin([FromRoute] string nume)
        {
            var addresses = await _context
                .ClientAddresses
                .Include(x => x.Client)
                .Where(x => x.Client.Name == nume)
                .ToListAsync();

            return Ok(addresses);
        }

        // Put - facem update la zipcode
        [HttpPut]
        [Authorize("Admin")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] int zipcode)
        {
            var address = await _context.ClientAddresses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            address.Zipcode = zipcode; // zipcode-ul introdus de noi
            _context.ClientAddresses.Attach(address);
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var address2 = await _context.ClientAddresses.FirstOrDefaultAsync(x => x.Id == id);
            return Ok();
        }

        // Delete - stergem adresa clientului al carui id este specificat
        [HttpDelete]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteAddress([FromQuery] int id)
        {
            var addresses = await _context
                 .ClientAddresses
                 .Include(x => x.Client)
                 .Where(x => x.Client.Id == id)
                 .ToListAsync();

            if (addresses == null)
            {
                return NotFound("Client with the specified id not found");
            }

            foreach (var ad in addresses)
            {
                _context.ClientAddresses.Remove(ad);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
