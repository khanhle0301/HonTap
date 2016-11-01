using AutoMapper;
using HonTap.Model.Models;
using HonTap.Web.Models;

namespace HonTap.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();                  
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserGroup, UserGroupViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
        }
    }
}