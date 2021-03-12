using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentDatabaseContext>, IRentalDal
    {

        public List<RentalDetailDto> GetRentalCarDetails()
        {
            using (RentDatabaseContext context = new RentDatabaseContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cs in context.Customers
                             on r.CustomerId equals cs.Id
                             join u in context.Users
                             on cs.UserId equals u.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CarId = c.Id,
                                 CustomerId = cs.Id,
                                 CarName = c.CarName,
                                 CompanyName = cs.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 BrandName = b.BrandName
                                 



                             };
                return result.ToList();
                              

    }
        }
    }

        
}
