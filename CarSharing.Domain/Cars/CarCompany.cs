using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Domain.Cars
{
    public class CarCompany
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
    }
}
