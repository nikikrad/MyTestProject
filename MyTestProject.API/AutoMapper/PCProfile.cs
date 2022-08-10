using AutoMapper;
using MyTestProject.API.Request.PCController;
using MyTestProject.BLL.Entities;

namespace MyTestProject.API.AutoMapper
{
    public class PCProfile : Profile
    {
        public PCProfile()
        {
            CreateMap<PostPC, PC>();
            CreateMap<PutPC, PC>();
        }
    }
}
