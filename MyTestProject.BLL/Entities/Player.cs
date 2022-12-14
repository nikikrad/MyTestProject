namespace MyTestProject.BLL.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = String.Empty;
        public List<Game> Game { get; set; }
        public int? PCId { get; set; }
        public PC? PC { get; set; } 
    }
}
