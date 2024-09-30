namespace Day6Demo.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        // CURD  Create , Read all , read By Id , Insert , Update , delete 
        T GetById(int? id);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(int? id);
    }
}
