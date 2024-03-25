using System.ComponentModel.DataAnnotations;

namespace AtlantidaBankAPI.Models.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CrediCardId { get; set; }

        public string token { get; set; }
    }
}
