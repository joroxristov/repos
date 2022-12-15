using KursovaRabota.Models;

namespace KursovaRabota.Repositories.Abstractions
{
    public interface ICarsRepository
    {
        void Add(Car car);

        Car Get(int CarId);

        IQueryable<Car> GetAll();

        void Update(Car car);

        void Delete(int CarId);
    }
}
