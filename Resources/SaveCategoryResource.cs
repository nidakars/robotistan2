using System.ComponentModel.DataAnnotations;

namespace robotistan.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}