namespace Meow.Tests
{
    using AutoMapper;
    using Data;
    using Data.Models;
    using Meow.Data.Models.Enums;
    using Meow.Web.Infrastructure.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class Tests
    {
        private static bool testsInitialize = false;

        public static void Initialize()
        {
            if (!testsInitialize)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
                testsInitialize = true;
            }
        }

        public static MeowDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<MeowDbContext>()
             .UseInMemoryDatabase("MeowDbTest")
             .Options;

            return new MeowDbContext(dbOptions);
        }
    }
}