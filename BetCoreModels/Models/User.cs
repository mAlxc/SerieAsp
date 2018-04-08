using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Validators;

namespace BetCoreModels.Models
{
    //[Table("Utilisateurs")]
    [Table(name: "Users")]
    public class User : ModelBase
    {
        //[Column("Name", TypeName = "nvarchar(50) latin")]
        [Display(Name ="name", ResourceType = typeof (Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName ="required_name", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        [StringLength(50, ErrorMessage = "Le nom doit contenir {1} caractères maximum.")]
        //[Column("Nom", Order = 3, TypeName = "")]
        public string Name { get; set; }

        [Display(Name = "firstname", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        public string Firstname { get; set; }

        
        [Display(Name = "Adresse mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                           ErrorMessage = "Le format du mail est incorrect.")]
        public string Mail { get; set; }


        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [MajorAttribute(18, ErrorMessage = "La personne doit avoir plus de 18 ans.")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        [StringLength(120, MinimumLength = 6, ErrorMessage = "Le mot de passe doit contenir entre {1} et {2} caractères.")]
        public string Password { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La confirmation n'est pas identique")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public int Status { get; set; }
    }
}
