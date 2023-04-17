using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistance;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _dbcontext;

        public CarWorkshopRepository(CarWorkshopDbContext dbcontext)
        {
           _dbcontext = dbcontext;
        }
        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            _dbcontext.Add(carWorkshop);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
