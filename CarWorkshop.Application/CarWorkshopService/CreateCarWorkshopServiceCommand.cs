using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService
{
    public class CreateCarWorkshopServiceCommand : CarWorkshopServiceDto, IRequest
    {
        public string CarWorkshopEncodedName { get; set; } = default!;
    }
}
