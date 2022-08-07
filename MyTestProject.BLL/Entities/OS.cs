namespace MyTestProject.BLL.Entities
{
    public class OS
    {
        public int Id { get; set; }
        public string NameOS { get; set; } = String.Empty;
        public List<PC> PC { get; set; }
    }
}
