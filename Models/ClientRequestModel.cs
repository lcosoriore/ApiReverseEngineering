using System.ComponentModel.DataAnnotations;

namespace ApiReverseEngineering.Models
{
    public class ClientRequestModel
    {
        public string Name { get; set; }
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
