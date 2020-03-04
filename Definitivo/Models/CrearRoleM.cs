using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Definitivo.Models
{

    // AGREGAMOS UN NUEVO ROL DESDE EL MODEL CON EL ATRIBUTO NOMBRE, EL ID ES AUTO INCREMENTAL
    public class CrearRoleM
    {

        public CrearRoleM()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        public List<string> Users { get; set; }

        [Required(ErrorMessage = "Nombre de rol es requerido")]
        public string RoleName { get; set; }
    }
}
