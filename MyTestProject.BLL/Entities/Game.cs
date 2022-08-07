namespace MyTestProject.BLL.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public int? Price { get; set; }
        public List<Player> Players { get; set; }
    }
}
