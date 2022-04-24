using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuikStorProject.Application.Registration.Dto
{
    public class RegistrationFull
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SchoolName { get; set; }
        public string PhoneNumber { get; set; }
        public int ZipCode { get; set; }
        public Guid SecretKey { get; set; }

    }
}
