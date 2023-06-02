using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ApiAuth.Model
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string email { get; set; }
    }
}
