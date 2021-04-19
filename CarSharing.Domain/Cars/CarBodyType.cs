using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Domain.Cars
{
    public class CarBodyType
    {
        public Guid BodyTypeId { get; set; }
        public BodyType Genre { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}
