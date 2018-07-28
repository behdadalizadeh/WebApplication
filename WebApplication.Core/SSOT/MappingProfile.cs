using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Core.DTO.Users;
using WebApplication.Core.Entities;
using WebApplication.Core.ViewModel.Users;

namespace WebApplication.Core.SSOT
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Users
            CreateMap<Users, UsersSummaryDTO>();
            CreateMap<Users, UsersCreateViewModel>();
            CreateMap<UsersCreateViewModel, Users>();
            CreateMap<Users, UsersEditViewModel>();
            CreateMap<UsersEditViewModel, Users>();
        }
    }
}