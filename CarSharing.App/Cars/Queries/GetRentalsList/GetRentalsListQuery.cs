using MediatR;

namespace CarSharing.App.Cars.Queries.GetRentalsList
{
    public class GetRentalsListQuery : IRequest<RentalDto[]>
    {
    }
}
