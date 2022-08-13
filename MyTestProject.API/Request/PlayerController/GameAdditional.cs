using System.ComponentModel.DataAnnotations;

namespace MyTestProject.API.Request.PlayerController
{
    public class GameAdditional
    {
        [Required]
        public int Id { get; set; }
    }
}
