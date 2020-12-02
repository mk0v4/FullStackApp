using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tasker.DAL.Entities;

namespace Tasker.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectEntity>().ReverseMap();
            CreateMap<ProjectTask, ProjectTaskEntity>().ReverseMap();
            CreateMap<TimeEntry, TimeEntryEntity>().ReverseMap();
        }
    }
}
