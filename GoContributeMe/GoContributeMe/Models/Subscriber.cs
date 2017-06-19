using System.ComponentModel.DataAnnotations;

namespace GoContributeMe.Models
{
    public class Subscriber
    {
        public int SubscriberId { get; set; }
        [Required]
        public string Email { get; set; }
    }
}