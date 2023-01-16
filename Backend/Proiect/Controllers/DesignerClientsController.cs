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
    [Route("api/designerClients")]
    [ApiController]

    public class DesignerClientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DesignerClientsController(AppDbContext context)
        {
            _context = context;
        }

        // Post
        [HttpPost]
        // [Authorize("Admin")]
        public async Task<IActionResult> CreateDesigner(DesignerClientPostModel model)
        {
            var designerClient = new DesignerClient()
            {
                Id = model.Id,
                DesignerId = model.DesignerId,
                ClientId = model.ClientId
            };

            await _context.DesignerClients.AddRangeAsync(designerClient);
            await _context.SaveChangesAsync();

            return Ok();
        }
       
        // Get-join  - afiseaza adresa designerilor care au numele introdus de noi
        [HttpGet("get-join/{nume}")]
        // [Authorize("Admin")]
        // [Authorize("Designer")]
        public async Task<IActionResult> GetDesignerAddressJoin([FromRoute] string nume)
        {
            var clients = await _context
                .DesignerClients
                .Include(x => x.Designer)
                .Where(x => x.Designer.Name == nume)
                .ToListAsync();

            return Ok(clients);
        }

        // Put - facem update la zipcode
        [HttpPut]
        [Authorize("Admin")]
        public async Task<IActionResult> Update([FromQuery] int id)
        {
            var client = await _context.DesignerClients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            _context.DesignerClients.Attach(client);
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var address2 = await _context.DesignerClients.FirstOrDefaultAsync(x => x.Id == id);
            return Ok();
        }

        // Delete - stergem adresele designerilor care au peste 40 de ani
        [HttpDelete]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteClient()
        {
            var clients = await _context
                 .DesignerClients
                 .Include(x => x.Designer)
                 .Where(x => x.Designer.Age > 40)
                 .ToListAsync();

            if ( clients == null)
                return NotFound("Designer with age > 40 not found");

            foreach (var client in clients)
            {
                _context.DesignerClients.Remove(client);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
