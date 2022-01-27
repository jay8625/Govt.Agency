using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Govt.Agency.Services.ViewModel
{
    public class vmAgencyCreate
    {
        [Required(ErrorMessage = "Please Enter Address")]
        [MaxLength(50)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [MaxLength(50)]
        [Display(Name = "Agency Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Pincode")]
        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [MaxLength(25)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Phone no")]
        [Display(Name = "Office Phone")]
        public string OfficePhone { get; set; }

        [Required(ErrorMessage = "Please Enter Phone no")]
        [Display(Name = "24X7 phone no.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Govt. Id")]
        public IFormFile GovtImage { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Broucher { get; set; }
        public bool AidOrganization { get; set; }
        public bool BroucherCopy { get; set; }
        public string Comments { get; set; }
        public DateTime DateTime { get; set; }
    }
}
