using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        public string QuoteText { get; set; }

    }
}
