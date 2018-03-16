namespace Meow.Tests.Web.Controllers
{
    using Data.Models;
    using FluentAssertions;
    using Meow.Services.Cats.Contracts;
    using Meow.Services.Cats.Models;
    using Meow.Web.Areas.Cats.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Linq;
    using Xunit;

    public class HomeCatsControllerTests
    {
        [Fact]
        public void AllHomeCatsShouldBeOnlyForAuthorizedUsers()
        {
            // Arrange
            var method = typeof(HomeCatsController)
                .GetMethod(nameof(HomeCatsController.All));

            // Act
            var attributes = method.GetCustomAttributes(true);

            // Assert
            attributes
                .Should()
                .Match(attr => attr.Any(a => a.GetType() == typeof(AuthorizeAttribute)));
        }

        [Fact]
        public void DetailsHomeCatShouldReturnNotFoundWithInvalidId()
        {
            // Arrange
            var userManager = this.GetUserManagerMock();
            var homeCats = this.GetIHomeCatServiceMock();

            var controller = new HomeCatsController(homeCats.Object, userManager.Object);

            // Act 
            var result = controller.Details(999);

            // Arrange
            result
                .Should()
                .BeOfType<NotFoundResult>();
        }

        [Fact]
        public void DetailsHomeCatShouldReturnViewWithCorrectModelWithValidHomeCat()
        {
            // Arrange
            var userManager = this.GetUserManagerMock();
            var homeCats = this.GetIHomeCatServiceMock();
            homeCats
                .Setup(c => c.ById(It.IsAny<int>()))
                .Returns(new HomeCatServiceModel() { Id = 1 });

            var controller = new HomeCatsController(homeCats.Object, userManager.Object);
          
            // Act 
            var result = controller.Details(555);

            // Arrange
            result
                .Should()
                .BeOfType<ViewResult>()
                .Subject
                .Model
                .Should()
                .BeOfType<HomeCatServiceModel>();
        }

        private Mock<UserManager<User>> GetUserManagerMock()
            => new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);

        private Mock<IHomeCatService> GetIHomeCatServiceMock()
             => new Mock<IHomeCatService>();
    }
}