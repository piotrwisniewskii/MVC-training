using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _dbcontext;

        public CarWorkshopRepository(CarWorkshopDbContext dbcontext)
        {
           _dbcontext = dbcontext;
        }

        public Task Commit()
        {
            return _dbcontext.SaveChangesAsync();
        }

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            _dbcontext.Add(carWorkshop);
            await _dbcontext.SaveChangesAsync();
        }

 

        public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAllAsync()
        {
            return await _dbcontext.CarWorkshops.ToListAsync();
        }

        public async Task<Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName)
        {
            return await _dbcontext.CarWorkshops.FirstAsync(c => c.EncodedName == encodedName);
        }

        public async Task<Domain.Entities.CarWorkshop?> GetByName(string name) =>
            await _dbcontext.CarWorkshops.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());

    }

}

