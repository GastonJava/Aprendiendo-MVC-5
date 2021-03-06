﻿namespace Definitivo.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class UsuarioModelCustom : IdentityUser
    {
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Ingresar mas de 3 caracteres")]
        [Required]
        [Display(Name = "Nombre Usuario")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Apellido Usuario")]
        public string ApellidoUsuario { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public override string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(10)]
        [Display(Name = "Contraseña")]
        public override string PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }
    }
}
