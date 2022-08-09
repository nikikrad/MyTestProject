using AutoMapper;
using MyTestProject.API.Request.PlayerController;
using MyTestProject.BLL.Entities;

namespace MyTestProject.API.AutoMapper
{
    public class PlayerProfile:Profile 
    {
        public PlayerProfile()
        {
            CreateMap<PostPlayer, Player>();
            CreateMap<DeletePlayer, Player>();
        }
    }
}
