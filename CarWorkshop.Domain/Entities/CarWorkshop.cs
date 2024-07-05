using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Entities
{
    public class CarWorkshop
    {
        public int Id { get; set; }        

        public string Name { get; set; } = default!;        // Name is required
        public string? Description { get; set; }            // Description is optional
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public CarWorkshopContactDetails ContactDetails { get; set; } = default!;       //

        public string About { get; set; }

        public string EncodedName { get; private set; } = default!;         //used for SEO purposes 

        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");    //method to encode the name for SEO purposes

    }
}
