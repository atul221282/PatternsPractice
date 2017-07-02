using Autofac.Repository.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Repository.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class AutomapperProfileConfiguration : Profile
    {
        public AutomapperProfileConfiguration()
        {
            CreateMap<User, UserModel>();
        }
    }
}
