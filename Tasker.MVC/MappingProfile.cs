using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Tasker.Model.Common;
using Tasker.WebAPI.Models;

namespace Tasker.WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProjectView, IProject>().ReverseMap();
            CreateMap<ProjectTaskView, IProjectTask>().ReverseMap();
            CreateMap<TimeEntryView, ITimeEntry>().ReverseMap();
        }
    }
}