using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuikStorProject.Application.Registration.Dto
{
    public class RegistrationCreator
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int ZipCode { get; set; }

    }
}
