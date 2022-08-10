using AutoMapper;
using MyTestProject.API.Request.OSController;
using MyTestProject.BLL.Entities;

namespace MyTestProject.API.AutoMapper
{
    public class OSProfile:Profile
    {
        public OSProfile()
        {
            CreateMap<PostOS, OS>();
            CreateMap<PutOS, OS>(); 
        }
    }
}
