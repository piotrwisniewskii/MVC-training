using CarWorkshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Services
{
    public class CarWorkshopeService : ICarWorkshopeService
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;

        public CarWorkshopeService(ICarWorkshopRepository carWorkshopRepository)
        {
            _carWorkshopRepository = carWorkshopRepository;
        }
        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            carWorkshop.EncodeName();

            await _carWorkshopRepository.Create(carWorkshop);
        }
    }
}
