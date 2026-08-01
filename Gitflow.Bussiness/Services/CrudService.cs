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
        public Person Create(Person person)
        {
            _DbSet.Add(person);
            _context.SaveChanges();
            return person;
        }
        public Person Delete(Person person) {
            _DbSet.Remove(person);
            _context.SaveChanges(true);
            return person;
        }
        public async Task<Person>Update(int ID, Person person)
        {
            Person Existing = await _DbSet.FindAsync(ID);
            if (Existing == null) { throw new KeyNotFoundException("Register not found."); }

            var primaryKeyName = _DbSet.Entry(Existing).Metadata.FindPrimaryKey()
                                ?.Properties.Select(p => p.Name).FirstOrDefault();

            var existingEntry = _DbSet.Entry(Existing);
            var newEntry = _DbSet.Entry(person);

            foreach (var property in existingEntry.Properties)
            {
                string propName = property.Metadata.Name;

                if (propName == primaryKeyName) continue;

                var newValue = newEntry.Property(propName).CurrentValue;

                
                    property.CurrentValue = newValue;
                    property.IsModified = true;
               
            }

            await _context.SaveChangesAsync();

            return Existing;
        }
    }
}
