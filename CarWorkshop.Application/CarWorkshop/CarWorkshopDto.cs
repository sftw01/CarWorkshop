using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDto
    {
        [Required]                                                  //name is required
        [StringLength(20, MinimumLength = 2)]                       //max length = 20, min length = 2
        public string Name { get; set; } = default!;

        [Required]
        public string? Description { get; set; }            // Description is required
        public string? About { get; set; }

        [StringLength(12, MinimumLength = 8)]               //phone number is not required, but when user insert then must be between 8-12 chars
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }

        public string? EncodedName { get; private set; } = default!;         //used for SEO purposes 

    }
}
