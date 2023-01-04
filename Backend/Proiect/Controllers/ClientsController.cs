using Microsoft.AspNetCore.Authorization;
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
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        // Post - adaugam un client nou
        [HttpPost("api/[controller]")]
        [Authorize("Admin")]
        public async Task<IActionResult> CreateDesigner(ClientPostModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                return BadRequest("Invalid object. Model is null");
            }

            var client = new Client()
            {
                Name = model.Name,
                Phone = model.Phone
            };

            await _context.Clients.AddRangeAsync(client);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Get All
        [HttpGet("api/[controller]")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _context.Clients.OrderBy(x => x.Name).ToListAsync();

            return Ok(clients);
        }

        // Get by id
        [HttpGet("api/[controller]/byId/{id}")]
        public async Task<IActionResult> GetClients([FromRoute] int id) // id ul este al unui designer !!!!
        {

            var clients = from c in _context.Clients
                          join a in _context.DesignerClients on c.Id equals a.ClientId
                          join b in _context.Designers on a.DesignerId equals b.Id
                          where (c.Id == a.ClientId) && (a.DesignerId == b.Id) && (id == b.Id)
                          select new { c.Id, c.Name, c.Phone };


            return Ok(clients);
        }

      

        // Put - facem update la numarul de telefon al unui client identificat dupa id
        [HttpPut("api/[controller]")] 
        [Authorize("Admin")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] string phone)
        { 
            var client = await _context.Clients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            client.Phone = phone; // nr de telefon introdus de noi

            _context.Entry(client).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var client2 = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

            return Ok();
        }


        // Delete - stergem clientii cu un nume dat ca parametru
        [HttpDelete("api/[controller]")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if (client == null)
            {
                return NotFound($"Client with Id = {id} not found");
            }

            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
