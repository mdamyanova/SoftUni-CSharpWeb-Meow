namespace Meow.Tests
{
    using Xunit;

    public class DemoTests
    {
        public DemoTests()
        {
            Tests.Initialize();
        }

        // With attribute Fact we declare a test method
        [Fact]
        public void DemoTest()
        {
            // Arrange
            var db = Tests.GetDatabase();

            // add some data to db

                // create cat for example 

                // new CatService for example
                
                // save changes

            // Act

            // test method here

            // Assert

            // using fluent assertions
        }
    }
}