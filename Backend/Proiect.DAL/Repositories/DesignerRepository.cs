﻿using Proiect.DAL.Entities;
using Proiect.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Repositories
{
    public class DesignerRepository : IDesignerRepository
    {
        private readonly AppDbContext _context;

        public DesignerRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task Create(Designer designer)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Designer designer)
        {
            throw new NotImplementedException();
        }

        public Task<List<Designer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Designer> GetById(int id)
        {
            var designer = await _context.Designers.FindAsync(id);
            return designer;
        }

        public Task Update(Designer designer)
        {
            throw new NotImplementedException();
        }
    }
}
