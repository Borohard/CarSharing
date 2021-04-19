using System.Threading;
using System.Threading.Tasks;
using CarSharing.App.Interfaces;
using CarSharing.Domain.Users;
using MediatR;

namespace CarSharing.App.Users.Commands
{
    public class AddUserCommand : IRequest
    {
        public string FullName { get; set; }
        public string Login { get; set; }

        public class Handler : IRequestHandler<AddUserCommand>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICrudRepository<User> _usersRepository;

            public Handler(IUnitOfWork unitOfWork, IMediator mediator)
            {
                _unitOfWork = unitOfWork;
                _usersRepository = unitOfWork.Get<User>();
            }

            public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    Login = request.Login,
                    FullName = request.FullName
                };

                await _usersRepository.AddAsync(user);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
