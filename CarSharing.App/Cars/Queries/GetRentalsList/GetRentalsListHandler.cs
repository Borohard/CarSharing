using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarSharing.App.Interfaces;
using CarSharing.Domain.Orders;
using MediatR;

namespace CarSharing.App.Cars.Queries.GetRentalsList
{
    public class GetRentalsListHandler : IRequestHandler<GetRentalsListQuery, RentalDto[]>
    {
        private readonly ICrudRepository<Rental> _rentals;

        public GetRentalsListHandler(IUnitOfWork unitOfWork)
        {
            _rentals = unitOfWork.Get<Rental>();
        }

        public async Task<RentalDto[]> Handle(GetRentalsListQuery request, CancellationToken cancellationToken)
        {
            var rentals = await _rentals.GetAllAsync();

            var result = rentals.Select(o => new RentalDto
            {
                UserId = o.UserId,
                CarId = o.CarId,
                CarTakenDate = o.CarTakenDate,
                RentalStatus = o.RentalStatus,
                Returned = o.Returned
            }).ToArray();

            return result;
        }
    }
}
