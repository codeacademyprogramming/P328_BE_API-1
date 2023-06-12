using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string No { get; set; }
    }
}
