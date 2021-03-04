using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(c => c.CarId == rental.CarId);
            if(result == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalCarAdded);

            }
            else
            {
                var resultdate = _rentalDal.Get(c => c.ReturnDate > rental.RentDate);
                if (/*rental.ReturnDate == new DateTime(0001,01,1) || */ 
                    resultdate != null ) return new ErrorResult(Messages.CarNotAvaliable);
                else
                {
                    _rentalDal.Add(rental);
                    return new SuccessResult(Messages.RentalCarAdded);
                }
            }
            
        }


        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalCarDeleted);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalCarUpdated);
        }


        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalCarListed);
        }

 
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id),Messages.RentalCarFounded);
        }

        public IDataResult<List<RentalDetailDto>> GetRentCarDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalCarDetails(), Messages.RentalCarListed);
        }

       
    }
}
