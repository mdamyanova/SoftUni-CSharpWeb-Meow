namespace Meow.Tests.Services.Cats
{
    using Data.Models;
    using Data.Models.Enums;
    using FluentAssertions;
    using Meow.Services.Cats.Implementations;
    using System;
    using Xunit;

    public class HomeCatServiceTests
    {
        [Fact]
        public void AddHomeCatWithAlreadyUsingUsernameShouldReturnFalse()
        {
            // Arrange
            var db = Tests.GetDatabase();

            var user = new User
            {
                Email = "test@test.com",
                UserName = "User",
                Name = "User",
                Gender = Gender.Male,
                Birthdate = DateTime.UtcNow,
                Location = "Sofia",
                ProfilePhoto = null
            };

            var cat = new HomeCat
            {
                Name = "Test",
                Age = 1,
                Image = null,
                Description = "Test Description",
                Gender = Gender.Male,
                OwnerId = user.Id,
                Owner = user
            };

            db.Add(user);
            db.Add(cat);

            db.SaveChanges();

            var service = new HomeCatService(db);

            // Act
            var result = service.Add("Test", null, 1, "Test Description", Gender.Male, user.Id);

            // Assert
            result
                .Should()
                .BeFalse();
        }
    }
}