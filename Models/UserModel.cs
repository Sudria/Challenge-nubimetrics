using Microsoft.EntityFrameworkCore;

namespace SudriaGonzalo.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
