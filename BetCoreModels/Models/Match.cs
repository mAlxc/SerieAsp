using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BetCoreModels.Models
{
    [Table(name: "Match")]
    public class Match : ModelBase
    {
        [Display(Name = "Equipe 1")]
        [Required(ErrorMessage = "Equipe 1 obligatoire")]
        public string Team1 { get; set; }

        [Display(Name = "Equipe 2")]
        [Required(ErrorMessage = "Equipe 2 obligatoire")]
        public string Team2 { get; set; }

        [Display(Name = "Cote victoire équipe 1")]
        [Required(ErrorMessage = "Cote victoire équipe 1 obligatoire")]
        public decimal OddTeam1 { get; set; }

        [Display(Name = "Cote victoire équipe 2")]
        [Required(ErrorMessage = "Cote victoire équipe 2 obligatoire")]
        public decimal OddTeam2 { get; set; }

        [Display(Name = "Cote match nul")]
        [Required(ErrorMessage = "Cote match nul 1obligatoire")]
        public decimal OddDraw { get; set; }

    }
}
