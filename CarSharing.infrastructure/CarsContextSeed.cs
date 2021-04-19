using Microsoft.EntityFrameworkCore;
using CarSharing.Domain.Cars;
using CarSharing.Domain.Orders;
using CarSharing.Domain.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSharing.infrastructure
{
    public class BooksContextSeed
    {
        private readonly CarsContext _context;

        public BooksContextSeed(CarsContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync()
        {
            if (await _context.Cars.AnyAsync())
            {
                return;
            }

            var books = new List<Car>()
            {
                new Car()
                {
                    Company = "Тестовый автор 1",
                    BodyType = "Жанр 1",
                    Name = "Имя 1"
                },
                new Car()
                {
                    Company = "Тестовый автор 1",
                    BodyType = "Жанр 1",
                    Name = "Имя 1"
                },
                new Car()
                {
                    Company = "Тестовый автор 1",
                    BodyType = "Жанр 1",
                    Name = "Имя 1"
                },
            };

            var users = new List<User>()
            {
                new User
                {
                    FullName = "Иван Петров",
                    Login = "petrov"
                },
                new User
                {
                    FullName = "Вася Петров",
                    Login = "vasya"
                },
            };

            await _context.Cars.AddRangeAsync(books);
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }
    }
}
