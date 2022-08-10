namespace MyTestProject.API.Request.PCController
{
    public class PutPC
    {
        public int Id { get; set; }
        public string Processor { get; set; } = String.Empty;
        public string VideoCard { get; set; } = String.Empty;
    }
}
