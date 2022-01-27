using System.ComponentModel.DataAnnotations;

namespace Govt.Agency.Services.ViewModel
{
    public class vmCity
    {
        public int Id { get; set; }

        [Display(Name = "City Name")]
        public string Name { get; set; }

        [Display(Name = "State Name")]
        public string StateName { get; set; }

        [Display(Name ="Country Name")]
        public string CountryName { get; set; }
    }
}
