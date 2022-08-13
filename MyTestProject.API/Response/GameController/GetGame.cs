namespace MyTestProject.API.Response.GameController
{
    public class GetGame
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public int? Price { get; set; }
        public int? CountOfPlayers { get; set; } 
    }
}
