using System;
namespace GitFlow.Entities.Interfaces.IServices
{
    public interface IServices<T>
    {
        public void setUp();
        public Task<List<T>> GetAllAsync();
        
        public  T Create(T entity);
        /*       
                public  Task<T> Update(int EntityId, T entity);
                public  Task<T> Delete(int ID);
          */
    }
}
