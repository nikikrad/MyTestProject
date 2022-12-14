using AutoMapper;
using MyTestProject.API.Request.GameController;
using MyTestProject.API.Response.GameController;
using MyTestProject.BLL.Entities;

namespace MyTestProject.API.AutoMapper
{
    public class GameProfile: Profile
    {
        public GameProfile()
        {
            CreateMap<PostGame, Game>();
            CreateMap<PutGame, Game>();
            CreateMap<Game, GetGame>();
        }
    }
}
