using System.ComponentModel.DataAnnotations;

namespace webvision.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}