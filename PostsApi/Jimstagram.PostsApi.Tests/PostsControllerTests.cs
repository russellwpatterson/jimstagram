using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Jimstagram.PostsApi.Controllers;
using Jimstagram.PostsApi.Repositories;
using Jimstagram.PostsApi.Models;
using Moq;

namespace Jimstagram.PostsApi.Tests
{
    public class PostsControllerTests
    {
        private readonly IPostsRepository _repository;

        public PostsControllerTests()
        {
            var repoMock = new Mock<IPostsRepository>();
            repoMock.Setup(p => p.List()).Returns(Task.FromResult(new List<Post>()));
            _repository = repoMock.Object;
        }

        [Fact]
        public void List_NoPosts_ReturnsEmptyList()
        {
            // Arrange
            var controller = new PostsController(_repository);

            // Act
            var actionResult = controller.List().Result;

            // Assert
            var okActionResult = actionResult as OkObjectResult;
            Assert.NotNull(okActionResult);

            var listedItems = okActionResult.Value as List<Post>;
            Assert.NotNull(listedItems);

            Assert.True(listedItems.Count == 0);
        }
    }
}
