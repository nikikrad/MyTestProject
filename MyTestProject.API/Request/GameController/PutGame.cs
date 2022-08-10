namespace MyTestProject.API.Request.GameController
{
    public class PutGame
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public int? Price { get; set; }
    }
}
