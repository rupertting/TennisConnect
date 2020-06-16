using System.ComponentModel.DataAnnotations;

namespace TennisConnect.Web.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}