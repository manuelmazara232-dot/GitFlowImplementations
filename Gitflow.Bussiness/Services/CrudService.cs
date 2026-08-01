using Gitflow.DataAcces.context;
using GitFlow.Entities.Models;
using GitFlow.Entities.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Gitflow.DataAcces.ConFiles;

namespace Gitflow.Bussiness.Services
{
    public class CrudService : IServices<Person>
    {
        private readonly GitFlowContext _context;
        private readonly DbSet<Person> _DbSet;
        public CrudService(GitFlowContext context)
        {
            _context = context;
            _DbSet = context.Set<Person>();
        }
        public void setUp()
        {
            var setup = new DBsetup();
            setup.setup();
        }
        public async Task<List<Person>> GetAllAsync() {
            List<Person> People = new List<Person>();
            People = await _DbSet.ToListAsync();
            return People;
        }
    }
}
