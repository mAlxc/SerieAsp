using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BetCoreModels.Models
{
    [Table(name: "Series")]
    public class Serie : ModelBase
    {

        [Display(Name = "name_serie", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        [StringLength(50, ErrorMessage = "Le nom de la série doit contenir {1} caractères maximum.")]
        public string Name_serie { get; set; }

        [Display(Name = "description", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        [StringLength(1024, ErrorMessage = "La description de la série doit contenir {1} caractères maximum.")]
        public string Description { get; set; }

        [Display(Name = "photo_serie", ResourceType = typeof(Languages.Resources.Resource))]
        public string Photo_serie { get; set; }
    }
}