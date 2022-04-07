using System.ComponentModel.DataAnnotations;

namespace DojoSurveyWithValidations.Models
{
    public class Survey
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        
        [Required]
        public string Campus { get; set; }
        
        [Required]
        [Display(Name ="Favorite Language")]
        public string FavoriteLanguage { get; set; }
        
        [MaxLength(20)]
        public string Comment { get; set; }
    }
}