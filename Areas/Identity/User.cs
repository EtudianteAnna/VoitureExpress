using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VoitureExpress.Areas.Identity;
 

public class ApplicationUser : IdentityUser
{

    [Key]
    public new string? Id { get; set; }
    public string? NomUtilisateur { get; set; }
    public string? MotDePasse { get; set; }
    public bool EstAdministrateur { get; set; }
}
