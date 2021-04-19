using System;
using CarSharing.Domain.Orders;

namespace CarSharing.App.Cars.Queries.GetRentalsList
{
    public class RentalDto
    {
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public DateTime CarTakenDate { get; set; }
        public DateTime? Returned { get; set; }
        public RentalStatus RentalStatus { get; set; }
    }
}
