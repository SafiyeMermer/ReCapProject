using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandal;

        public BrandManager(IBrandDal brandal)
        {
            _brandal = brandal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandal.Add(brand);
            return new SuccessResult(brand.BrandName + " " + Messages.BrandAdded);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandal.Update(brand);
            return new SuccessResult(brand.BrandName + "  " + Messages.BrandUpdated);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Brand brand)
        {
            _brandal.Delete(brand);
            return new SuccessResult(brand.BrandName + " " +Messages.BrandDeleted);
        }


        [SecuredOperation("admin,user")]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandal.GetAll(),Messages.BrandListed);
        }

        [SecuredOperation("admin")]
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandal.Get(b => b.Id == id),Messages.BrandFounded);
        }

        
    }
}
