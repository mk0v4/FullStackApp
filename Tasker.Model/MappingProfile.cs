using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tasker.DAL.Entities;
using Tasker.Model.Common;

namespace Tasker.Model
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IProject, ProjectEntity>().ReverseMap();
            CreateMap<IProjectTask, ProjectTaskEntity>().ReverseMap();
            CreateMap<ITimeEntry, TimeEntryEntity>().ReverseMap();
        }
    }
}
