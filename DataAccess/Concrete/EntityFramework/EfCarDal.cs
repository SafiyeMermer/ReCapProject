

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentDatabaseContext context = new RentDatabaseContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join cı in context.CarImages
                             on c.Id equals cı.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 ImagePath=cı.ImagePath,
                                 Date = cı.Date

                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetailsForFilter(Expression<Func<Car, bool>> filter = null)
        {
            using (RentDatabaseContext context = new RentDatabaseContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join cı in context.CarImages
                             on c.Id equals cı.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 ImagePath = cı.ImagePath,
                                 Date = cı.Date

                             };
                return result.FirstOrDefault();
            }
        }

        public List<CarDetailDto> GetCarsByBrandId(Expression<Func<Car, bool>> filter = null)
        {
            using (RentDatabaseContext context = new RentDatabaseContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join cı in context.CarImages
                             on c.Id equals cı.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 ImagePath = cı.ImagePath,
                                 Date = cı.Date

                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByColorId(Expression<Func<Car, bool>> filter = null)
        {
            using (RentDatabaseContext context = new RentDatabaseContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join cı in context.CarImages
                             on c.Id equals cı.CarId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 BrandId = b.Id,
                                 ColorId = co.Id,
                                 ImagePath = cı.ImagePath,
                                 Date = cı.Date

                             };
                return result.ToList();
            }

        }
    }
}
