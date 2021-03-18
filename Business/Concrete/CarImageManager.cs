using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using System.IO;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;
        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRun.Run(CheckIMageLimitExceeded(carImage.CarId),
                                        CarImageAddedDate(carImage),
                                        CheckCarId(carImage.CarId),
                                        CarImageAddFile(file,carImage));

            if (result != null)
            {
                return result;
            }
             _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);

        }

        [CacheRemoveAspect("ICarImageService.Get")]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult AddDefault(CarImage carImage)
        {
            var result = BusinessRun.Run(CheckIMageLimitExceeded(carImage.CarId),
                                        CarImageAddedDate(carImage),
                                        CarImageDeterminedDefault(carImage),
                                        CheckCarId(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRun.Run(CheckCarId(carImage.CarId),
                                         CarImageDeleteFile(carImage));

            if (result != null)
            {
                return result;
            }
 
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted); ;


        }

        [CacheAspect]
        //[SecuredOperation("admin,user")]
        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }


        [CacheAspect]
        //[SecuredOperation("admin")]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(cı => cı.Id == id), Messages.CarImageFounded);
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRun.Run(CheckIMageLimitExceeded(carImage.CarId),
                                        CarImageAddedDate(carImage),
                                        CarImageDeterminedDefault(carImage),
                                        CheckCarId(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        //[SecuredOperation("admin")]
        public IDataResult<List<CarImage>> GetByCarId(int carid)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(cı => cı.CarId == carid), Messages.CarImageListed);
        }



        //Business Codes
        private IResult CheckIMageLimitExceeded(int carid)
        {
            var result = _carImageDal.GetAll(cı => cı.CarId == carid).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageCountOfCarError);
            }
            return new SuccessResult();

        }
        private IResult CarImageAddedDate(CarImage carImage)
        {
            carImage.Date = DateTime.Now;
            return new SuccessResult();
        }

        private IResult CarImageDeterminedDefault(CarImage carImage)
        {
            if (carImage.ImagePath == null)
            {
                carImage.ImagePath = "default.jpg";
            }
            return new SuccessResult();
        }

        private IResult CheckCarId(int carId)
        {
            var result = _carService.GetAll().Data;
            foreach (var car in result)
            {
                if (car.Id == carId) return new SuccessResult();
            }
            return new ErrorResult(Messages.CarIdNotBelongAnyVehicle);

        }

        private IResult CarImageAddFile(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileSaveHelper.Add(file);
            return new SuccessResult();
        }

        private IResult CarImageDeleteFile(CarImage carImage)
        {
            FileSaveHelper.Delete(carImage.ImagePath);
            return new SuccessResult();
        }
        
        
    }
}
