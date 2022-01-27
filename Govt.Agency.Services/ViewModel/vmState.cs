using System.ComponentModel.DataAnnotations;

namespace Govt.Agency.Services.ViewModel
{
    public class vmState
    {
        public int Id { get; set; }

        [Display(Name = "State Name")]
        public string Name { get; set; }

        [Display(Name="Country Name")]
        public string CountryName { get; set; }
    }
}
