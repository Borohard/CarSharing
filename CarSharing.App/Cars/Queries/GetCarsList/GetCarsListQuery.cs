using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarSharing.App.Interfaces;
using CarSharing.Domain.Cars;
using MediatR;

namespace CarSharing.App.Cars.Queries.GetCarsList
{
    public class GetCarsListQuery : IRequest<CarDto[]>
    {
        public string Name { get; set; }

        public class Handler : IRequestHandler<GetCarsListQuery, CarDto[]>
        {
            private readonly ICrudRepository<Car> _books;

            public Handler(IUnitOfWork unitOfWork)
            {
                _books = unitOfWork.Get<Car>();
            }

            public async Task<CarDto[]> Handle(GetCarsListQuery request, CancellationToken cancellationToken)
            {
                var cars = string.IsNullOrWhiteSpace(request.Name)
                    ? await _books.GetAllAsync()
                    : await _books.FilterAsync(b => b.Name == request.Name);

                var result = cars.Select(b => new CarDto
                {
                    Id = b.Id,
                    Name = b.Name
                });

                return result.ToArray();
            }
        }
    }
}
