using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Tasker.Model;
using Tasker.Model.Common;
using Tasker.Repository.Common;
using Tasker.Service.Common;
using Xunit;

namespace Tasker.Service.Tests
{
    public class ProjectTaskServiceTest
    {

        private readonly Mock<IProjectRepository> _projectRepositoryMoq;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _config;

        public ProjectTaskServiceTest()
        {
            _projectRepositoryMoq = new Mock<IProjectRepository>();
            _config = new MapperConfiguration(cfg => cfg.AddMaps(new[] {
                "Tasker.Model"
            }));
            _mapper = new Mapper(_config);
        }

        [Fact]
        public async Task Get_EntitytNotFound_ThrowsException()
        {
            // Arrange
            IProject project = _mapper.Map<IProject>(null);
            _projectRepositoryMoq.Setup(x => x.Get(It.IsAny<long>())).ReturnsAsync(project);
            ProjectService ps = new ProjectService(_projectRepositoryMoq.Object);
            // Act
            Func<Task> result = async () => await ps.Get(It.IsAny<long>());
            // Assert
            result.Should().Throw<Exception>().WithMessage("Entity not found!");
        }
    }
}
