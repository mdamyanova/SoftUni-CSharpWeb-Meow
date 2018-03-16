namespace Meow.Tests.Services.Cats
{
    using Data.Models;
    using Data.Models.Enums;
    using FluentAssertions;
    using Meow.Services.Cats.Implementations;
    using System;
    using Xunit;

    public class AdoptionCatServiceTests
    {
        [Fact]
        public void AddAdoptionCatWithAlreadyUsingUsernameShouldReturnFalse()
        {
            // Arrange
            var db = Tests.GetDatabase();

            var volunteer = new User
            {
                Email = "test@test.com",
                UserName = "Volunteer",
                Name = "Volunteer",
                Gender = Gender.Male,
                Birthdate = DateTime.UtcNow,
                Location = "Sofia",
                ProfilePhoto = null
            };

            var cat = new AdoptionCat
            {
                Name = "Anton",
                Age = 1,
                Image = null,
                Description = "Test Description",
                Gender = Gender.Male,
                OwnerId = volunteer.Id,
                Owner = volunteer,
                Location = "Sofia"
            };

            db.Add(volunteer);
            db.Add(cat);

            db.SaveChanges();

            var service = new AdoptionCatService(db);

            // Act
            var result = service.Add("Anton", null, 1, "Sofia", "Test Description", Gender.Male);

            // Assert
            result
                .Should()
                .BeFalse();
        }

        [Fact]
        public void AddAdoptionCatWithInvalidVolunteerCredentialsShouldReturnFalse()
        {
            // Arrange
            var db = Tests.GetDatabase();

            var volunteer = new User
            {
                Email = "test@test.com",
                UserName = "NonVolunteer",
                Name = "NonVolunteer",
                Gender = Gender.Male,
                Birthdate = DateTime.UtcNow,
                Location = "Sofia",
                ProfilePhoto = null
            };

            var cat = new AdoptionCat
            {
                Name = "Anton",
                Age = 1,
                Image = null,
                Description = "Test Description",
                Gender = Gender.Male,
                OwnerId = volunteer.Id,
                Owner = volunteer,
                Location = "Sofia"
            };

            db.Add(volunteer);
            db.Add(cat);

            db.SaveChanges();

            var service = new AdoptionCatService(db);

            // Act
            var result = service.Add("Test Cat", null, 1, "Sofia", "Test Description", Gender.Male);

            // Assert
            result
                .Should()
                .BeFalse();
        }
    }
}