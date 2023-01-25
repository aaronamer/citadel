using System.ComponentModel.DataAnnotations;

namespace Citadel.Models
{
    public class NameModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = null!;
    }
}
