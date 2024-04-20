using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using rpgAPI.Model;
using rpgAPI.Service; // You'll need to add this NuGet package for mocking

namespace rpgAPI.Controller.Tests
{
    public class CharacterControllerTests
    {
        [Fact]
        public void GetCharacter_ReturnsListOfCharacters()
        {
            // Arrange
            var returnList = new List<Character>(){
                    new Character(){
                    Name = "Alice",
                    Id = 2
                    },
                    new Character(){
                    Name = "Bob",
                    Id = 3
                    },
            };

            var serviceResponse = new ServiceResponse<List<Character>>()
            {
                Data = returnList
            };

            var mockService = new Mock<ICharacterService>();
            mockService.Setup(s => s.GetAllCharacter()).Returns(serviceResponse);
            var controller = new CharacterController(mockService.Object);

            // Act
            var result = controller.GetCharacter();
            var okResult = (ObjectResult)result.Result;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);

        }

        [Fact]
        public void GetId_ReturnsCharacterById()
        {
            // Arrange
            var returnObj =
                    new Character()
                    {
                        Name = "Mark Z.",
                        Id = 1
                    };

            var serviceResponse = new ServiceResponse<Character>()
            {
                Data = returnObj
            };
            var mockService = new Mock<ICharacterService>();
            mockService.Setup(s => s.GetCharacterById(1))
                .Returns(serviceResponse);
            var controller = new CharacterController(mockService.Object);

            // Act
            var result = controller.GetId(1);

            // Assert
            Assert.NotNull(result);

        }

        [Fact]
        public void GetId_ReturnsCharacterByIdWithFixture()
        {
            // Arrange
            var fixture = new Fixture();
            var serviceResponse = fixture.Create<ServiceResponse<Character>>();
            var mockService = new Mock<ICharacterService>();

            mockService.Setup(x => x.GetCharacterById(0)).Returns(serviceResponse);

            var charController = new CharacterController(mockService.Object);

            var result = charController.GetId(0);

            // Assert
            Assert.NotNull(result);

        }
    }
}
