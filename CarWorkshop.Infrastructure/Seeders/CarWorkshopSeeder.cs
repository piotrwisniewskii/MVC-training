using CarWorkshop.Domain.Entities;
using CarWorkshop.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbcontext;
        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbcontext.Database.CanConnectAsync())
            {
                if(!_dbcontext.CarWorkshops.Any())
                {
                    var mazdaAso = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Mazda Aso",
                        Description = "Autoryzowany serwis Mazda",
                        ContactDetails = new()
                        {
                            City = "Kraków",
                            Street = "Szewska 2",
                            PostalCode = "30-001",
                            PhoneNumber = "+48699222888"
                        }
                    };
                    mazdaAso.EncodeName();
                    _dbcontext.CarWorkshops.Add(mazdaAso);
                    await _dbcontext.SaveChangesAsync();
                }
            }
        }
    }
}
