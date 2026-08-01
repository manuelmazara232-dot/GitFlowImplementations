using GitFlow.Entities.Models;
using System;
namespace GitFlow.Entities.Interfaces.IServices
{
    public interface IServices<T>
    {
        public void setUp();
        public Task<List<T>> GetAllAsync();
        
        public  T Create(T entity);
        public Person Delete(Person person);
        public Task<Person> Update(int ID, Person person);
    
    }
}
