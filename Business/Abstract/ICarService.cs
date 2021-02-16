using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : ICrudServices<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarDetailsService();
        IDataResult<CarDetailDto> GetCarDetailsByIdService(int id);
    }

}
