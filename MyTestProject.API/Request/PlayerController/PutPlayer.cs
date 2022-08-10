using MyTestProject.BLL.Entities;

namespace MyTestProject.API.Request.PlayerController
{
    public class PutPlayer
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = String.Empty;
       
    }
}
