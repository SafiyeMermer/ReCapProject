using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDetailDto> GetCarDetailsForFilter(int carId);
        IDataResult<List<Car>> GetCarsByColorAndBrand(int brandId, int colorId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
    }
}
