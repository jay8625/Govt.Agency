using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Govt.Agency.DAL.Model
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Country")]
        [Display(Name ="Country Name")]
        public string Name { get; set; }
        public ICollection<State> State { get; set; }
    }
}
