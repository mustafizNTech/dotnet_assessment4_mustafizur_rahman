using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using rpgAPI.Helpers;
using rpgAPI.Model;
using rpgAPI.Service; // You'll need to add this NuGet package for mocking

namespace rpgAPI.Controller.Tests
{
    public class CharacterControllerTests
    {
        [Fact]
        public void GetCharacterReturnsListOfCharacters()
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
        public void GetIdReturnsCharacterById()
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
        public void GetIdReturnsCharacterByIdWithFixture()
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

        [Fact]
        public void GetCharacterWithValidRequestGetSucessResponse()
        {
            //Arrange
            var serviceResponse = new ServiceResponse<List<Character>>()
            {
                Data = CharacterGenerator.GetValidCharacterList(),
                Success = true,
                Message = "Ok"
            };

            var mockCharacterService = new Mock<ICharacterService>();
            mockCharacterService.Setup(s => s.GetAllCharacter()).Returns(serviceResponse);

            var characterController = new CharacterController(mockCharacterService.Object);

            //Act
            var result = characterController.GetCharacter();

            //Assert
            var okResult = result.Result as OkObjectResult;
            var response = okResult!.Value as ServiceResponse<List<Character>>;
            Assert.NotNull(okResult);
            Assert.Equal(1, response?.Data?.Count);
        }

        [Fact]
        public void GetCharacterByIdWithValidRequestGetSucessResponse()
        {
            //Arrange
            var character = CharacterGenerator.GetValidCharacter();
            var serviceResponse = new ServiceResponse<Character>()
            {
                Data = character,
                Success = true,
                Message = "Ok"
            };

            var mockCharacterService = new Mock<ICharacterService>();
            mockCharacterService.Setup(s => s.GetCharacterById(character.Id)).Returns(serviceResponse);

            var characterController = new CharacterController(mockCharacterService.Object);

            //Act
            var result = characterController.GetId(character.Id);

            //Assert
            var okResult = result.Result as OkObjectResult;
            var response = okResult!.Value as ServiceResponse<Character>;
            Assert.NotNull(okResult);
            Assert.Equal(character, response?.Data);
        }

        [Fact]
        public void GetCharacterByIdWithInvalidRequestReturnsNotFound()
        {
            //Arrange
            var character = CharacterGenerator.GetValidCharacter();
            var serviceResponse = new ServiceResponse<Character>()
            {
                Data = character,
                Success = false,
                Message = "No character found"
            };

            var mockCharacterService = new Mock<ICharacterService>();
            mockCharacterService.Setup(s => s.GetCharacterById(character.Id)).Returns(serviceResponse);

            var characterController = new CharacterController(mockCharacterService.Object);

            //Act
            var result = characterController.GetId(character.Id);

            //Assert
            // var okResult = result.Result as NotFoundObjectResult;
            var okResult = (ObjectResult)result.Result;
            var response = okResult!.Value as ServiceResponse<Character>;
            Assert.NotNull(okResult);
            Assert.Equal("No character found", response?.Message);
        }

        [Fact]
        public void AddCharacterWithValidRequestGetSucessResponse()
        {
            //Arrange
            var character = CharacterGenerator.GetValidCharacter();
            var serviceResponse = new ServiceResponse<List<Character>>()
            {
                Data = CharacterGenerator.GetValidCharacterList(),
                Success = true,
                Message = "Ok"
            };

            var mockCharacterService = new Mock<ICharacterService>();
            mockCharacterService.Setup(s => s.AddCharacter(character)).Returns(serviceResponse);

            var characterController = new CharacterController(mockCharacterService.Object);

            //Act
            var result = characterController.PostCharacter(character);

            //Assert
            var okResult = (ObjectResult)result.Result;
            var response = okResult!.Value as ServiceResponse<List<Character>>;
            Assert.NotNull(okResult);
            Assert.Equal(1, response?.Data?.Count);
        }


    }
}
