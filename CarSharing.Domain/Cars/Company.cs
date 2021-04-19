using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Domain.Cars
{
    public class Company : BaseEntity
    {
        public string FullName { get; set; }
        public ICollection<CarCompany> AuthoredBooks { get; set; }
    }
}
