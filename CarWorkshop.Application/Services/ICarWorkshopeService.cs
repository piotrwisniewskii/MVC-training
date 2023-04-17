using CarWorkshop.Application.CarWorkshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Services
{
    public interface ICarWorkshopeService
    {
        Task Create(CarWorkshopDto carWorkshop);
        Task<IEnumerable<CarWorkshopDto>> GetAllAsync();
    }
}
