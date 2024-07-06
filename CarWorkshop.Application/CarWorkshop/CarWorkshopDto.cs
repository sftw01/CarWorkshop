using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDto
    {
        public string Name { get; set; } = default!;        // Name is required
        public string? Description { get; set; }            // Description is optional
        public string? About { get; set; }              //is not required - can be empty! ????

        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }

        public string? EncodedName { get; private set; } = default!;         //used for SEO purposes 

    }
}
