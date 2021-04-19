using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Domain.Cars
{
    public class Car : BaseEntity
    {
        public string Name { get; set; }
        
        public string Company { get; set; }
        public string BodyType { get; set; }
    }
}
