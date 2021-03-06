﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            var result = BusinessRun.Run(CheckCarUnitPrice(car));

            if (result == null)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            return new ErrorResult(Messages.DailyPriceOfCarNotLessThan);
            
        }

        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect]
        //[SecuredOperation("admin,user")]
        public IDataResult<List<Car>> GetAll()
        {
            //Thread.Sleep(5000);
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }
        //[SecuredOperation("admin")]
        public IDataResult<Car> GetCarsById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByBrandId(c => c.BrandId == brandId),Messages.CarsListed);
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsByColorId(c => c.ColorId == colorId), Messages.CarsListed);
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }

        [CacheAspect]
        //[SecuredOperation("admin")]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.CarFounded);
        }


        // Business Code

        
        private IResult CheckCarUnitPrice(Car car)
        {

            if(car.DailyPrice < 500)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetCarsByColorAndBrand(int brandId, int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId && c.BrandId == brandId);
            if(result!= null)
            {
                return new SuccessDataResult<List<Car>>(result, Messages.CarsListed);
            }
            return new ErrorDataResult<List<Car>>(Messages.CarNotFound);

        }

        public IDataResult<CarDetailDto>GetCarDetailsForFilter(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsForFilter(c => c.Id == carId));
        }
    }
}
