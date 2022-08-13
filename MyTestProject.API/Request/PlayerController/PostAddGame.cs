using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyTestProject.API.Request.PlayerController
{
    public class PostAddGame
    {
        [Required]
        [JsonPropertyName("player_id")]
        public int PlayerId { get; set; }
        [JsonPropertyName("games")]
        public List<GameAdditional> GameAdditionals { get; set; } 
    }
}
