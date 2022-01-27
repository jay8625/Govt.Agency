using System.ComponentModel.DataAnnotations;

namespace Govt.Agency.DAL.Model
{
    public class AgencyType
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Agency Name")]
        public string Name { get; set; }
    }
}
