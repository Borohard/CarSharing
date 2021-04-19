using System;
using CarSharing.Domain.Cars;
using CarSharing.Domain.Users;

namespace CarSharing.Domain.Orders
{
    public class Rental : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid CarId { get; set; }
        public Car Car { get; set; }

        public DateTime CarTakenDate { get; set; }
        public DateTime? Returned { get; set; }

        public RentalStatus RentalStatus { get; set; }
    }
}
