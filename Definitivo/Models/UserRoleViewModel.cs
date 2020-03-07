using System.ComponentModel.DataAnnotations;

namespace Definitivo.Models
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public bool IsSelected { get; set; }
    }
}
