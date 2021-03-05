using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "System is in Maintenance.";

        public static string CarAdded = "Car is added";
        public static string CarDeleted = "Car is deleted";
        public static string CarUpdated = "Car is updated";
        public static string CarInvalidName = "Car name word must greater than 2.";
        public static string CarsListed = "Cars are listed";
        public static string CarFounded = "Car is founded";

        public static string ColorAdded = "Color is added";
        public static string ColorDeleted = "Color is deleted";
        public static string ColorUpdated = "Color is updated";
        public static string ColorInvalidName = "Color name word must greater than 2.";
        public static string ColorListed = "Colors are listed";
        public static string ColorFounded = "Color is founded";

        public static string BrandAdded = "Brand is added";
        public static string BrandDeleted = "Brand is deleted";
        public static string BrandUpdated = "Brand is updated";
        public static string BrandInvalidName = "Brand name word must greater than 2.";
        public static string BrandListed = "Brands are listed";
        public static string BrandFounded = "Brand is founded";

        public static string UserAdded = "User is added";
        public static string UserDeleted = "User is deleted";
        public static string UserUpdated = "User is updated";
        public static string UserInvalidName = "User name word must greater than 2.";
        public static string UserListed = "Users are listed";
        public static string UserFounded = "User is founded";

        public static string CustomerAdded = "Customer is added";
        public static string CustomerDeleted = "Customer is deleted";
        public static string CustomerUpdated = "Customer is updated";
        public static string CutomerInvalidName = "Customer name word must greater than 2.";
        public static string CustomerListed = "Customers are listed";
        public static string CustomerFounded = "Customer is founded";

        public static string RentalCarAdded = "Car is rented";
        public static string RentalCarDeleted = "Car is returned.";
        public static string RentalCarUpdated = "Rental Car is updated";
        public static string RentalCarListed = "Rental Cars are listed";
        public static string RentalCarFounded = "Rental Car is founded";
        public static string CarNotAvaliable = "Car is not available.";

        public static string CarImageAdded = "Car Image is added.";
        public static string CarImageDeleted = "Car Image is deleted.";
        public static string CarImageUpdated = "Car Image is updated.";
        public static string CarImageListed= "Cars Images are listed.";
        public static string CarImageFounded = "Car Image is founded.";
        public static string CarImageCountOfCarError = "Car must have a maximum of 5 images.";
        public static string CarIdNotBelongAnyVehicle = "CarId does not belong to any car.";
        public static string AuthorizationDenied = "You are not authorized for this operation.";
        public static string UserAlreadyExists = "User is already exists.";
        public static string AccessTokenCreated = "Access Token is created.";
        public  static string UserNotFound = "User is not found";
        public static string PasswordError = "Password error.";
        public static string SuccessfulLogin = "Successful Login";
        public static string UserRegistered = "User registered";
        public static string DailyPriceOfCarNotLessThan = "The daily price of the car cannot be less than 500$.";
    }
}
