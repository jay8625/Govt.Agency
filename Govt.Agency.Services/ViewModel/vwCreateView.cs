using System;
using System.ComponentModel.DataAnnotations;

namespace Govt.Agency.Services
{
    public class vwCreateView
    {
        //Primary key
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }
    }
}
