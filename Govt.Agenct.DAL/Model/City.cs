using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Govt.Agency.DAL.Model
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter City")]
        [Display(Name ="City Name")]
        public string Name { get; set; }
        public int? StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; }
    }
}
