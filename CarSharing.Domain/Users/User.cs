using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Domain.Users
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Login { get; set; }
    }
}
