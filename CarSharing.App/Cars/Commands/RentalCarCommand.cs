using System;
using System.Threading;
using System.Threading.Tasks;
using CarSharing.Domain.Orders;
using CarSharing.App.Interfaces;
using MediatR;

namespace CarSharing.App.Cars.Commands
{
    public class RentalCarCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public DateTime StartTime { get; set; }

        public class Handler : IRequestHandler<RentalCarCommand>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICrudRepository<Rental> _rentals;

            public Handler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
                _rentals = unitOfWork.Get<Rental>();
            }

            public async Task<Unit> Handle(RentalCarCommand request, CancellationToken cancellationToken)
            {
                
                var rental = new Rental
                {
                    CarId = request.CarId,
                    UserId = request.UserId,
                    CarTakenDate = request.StartTime,
                    RentalStatus = RentalStatus.InUse
                };

                await _rentals.AddAsync(rental);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }


    }
}
