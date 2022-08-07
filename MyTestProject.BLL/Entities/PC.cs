namespace MyTestProject.BLL.Entities
{
    public class PC
    {
        public int Id { get; set; }
        public string Processor { get; set; } = String.Empty;
        public string VideoCard { get; set; } = String.Empty;
        public Player Player { get; set; }

    }
}
