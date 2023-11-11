using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class CandidatSearchModel
{
    [Display(Name = "Nom")]
    public string Nom { get; set; }

    [Display(Name = "Prénom")]
    public string Prenom { get; set; }

    [Display(Name = "Email")]
    public string Email { get; set; }

    [Display(Name = "Téléphone")]
    public string Telephone { get; set; }
}
