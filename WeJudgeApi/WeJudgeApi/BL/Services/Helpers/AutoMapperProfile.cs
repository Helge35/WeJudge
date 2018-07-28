using AutoMapper;
using WeJudgeApi.BL.Dal.Entities;
using WeJudgeApi.BL.Models;

namespace WeJudgeApi.BL.Services.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
