﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using Tasker.Service.Models;

namespace Tasker.Service.Service.Interface
{
    public interface IProjectService
    {
        Task<int> Create(Project project);
        Task<Project> Get(long id);
        Task<int> Delete(long id);
        Task<Project> Update(Project project);
        Task<IPagedList<Project>> Filter(string property, object value, int? pageNumber, int pageSize, string sortBy, string sortDirection);
    }
}