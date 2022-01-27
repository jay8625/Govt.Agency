using System;
using System.ComponentModel.DataAnnotations;

namespace Govt.Agency.DAL.Model
{
    public class AgencyInfo
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Name { get; set; }

        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Email { get; set; }

        [Display(Name = "Office Phone")]
        public string OfficePhone { get; set; }

        [Display(Name = "24x7 Phone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Govt. Id")]
        public string GovtImage { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Broucher { get; set; }

        [Display(Name = "Aid Organization")]
        public bool AidOrganization { get; set; }

        [Display(Name = "Broucher Copy")]
        public bool BroucherCopy { get; set; }
        public string Comments { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime DateTime { get; set; }
    }
}
