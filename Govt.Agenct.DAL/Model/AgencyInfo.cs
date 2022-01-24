using System;
using System.ComponentModel.DataAnnotations;

namespace Govt.Agenct.DAL.Model
{
    public class AgencyInfo
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string OfficePhone { get; set; } 
        public string PhoneNumber { get; set; }
        public string GovtImage { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Broucher { get; set; }
        public bool AidOrganization { get; set; }
        public bool BroucherCopy { get; set; }
        public string Comments { get; set; }
        public string DocumentAttachment { get; set; }
        public DateTime DateTime { get; set; }
    }
}
