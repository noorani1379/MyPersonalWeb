using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalWeb.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string? Name { get; set; } 

        public string? Content { get; set; }
        
        public string? Email { get; set; }

        public string? DeviceContent { get; set; }

        // The default value
        public DateTime? Created { get; set; } = DateTime.Now;

    }
}
