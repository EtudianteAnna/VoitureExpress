﻿using System.ComponentModel.DataAnnotations;

namespace VoitureExpress.Areas.Identity;
 

public class IdentityUser
{

    [Key]
    public int Id { get; set; }
    public string? NomUtilisateur { get; set; }
    public string? MotDePasse { get; set; }
    public bool EstAdministrateur { get; set; }
}
