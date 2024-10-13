using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTier.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? FullName 
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public int? Age 
        {
            get 
            {
                if (DateOfBirth.HasValue)
                {
                    return DateTime.Now.Year - DateOfBirth.Value.Year;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
