using rpgAPI.Helpers;
using rpgAPI.Model;
using rpgAPI.Service;

namespace rpgAPITest;

public class CharacterServiceTest{

    [Fact]
    public void GetAllCharacterWithValidRequestGetResult()
    {
        // Arrange
        var cs = new CharacterService();

        // Act
        var result = cs.GetAllCharacter();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void AddCharacterWithValidRequestGetResul()
    {

        // Arrange
        var character = new Character(){
            Name = "Unit Test",
            Id = 4,
        };

        var cs = new CharacterService();

        // Act
        var result = cs.AddCharacter(character);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void GetCharacterByIdWithValidRequestResult(){

        // Arrange
        var cs = new CharacterService();

        // Act
        var result = cs.GetCharacterById(0);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]
    public void GetCharacterByIdWithInvalidRequestGetResult()
    {
        //Arrange
        var characterService = new CharacterService();

        //Act
        var result = characterService.GetCharacterById(2);

        //Assert
        Assert.False(result.Success);
    }


    [Fact]
    public void AddCharacterWithValidRequestGetResult()
    {
        //Arrange
        var characterService = new CharacterService();
        var character = CharacterGenerator.GetValidCharacter(); // Helper method to generate a valid character.

        //Act
        var result = characterService.AddCharacter(character);

        //Assert
        Assert.True(result.Data?.Contains(character)); // Added null-conditional operator to safely access properties
        Assert.True(result.Success);
    }

    [Fact]
    public void UpdateCharacterWithValidRequestGetResult(){

        // Arrange
        var character = new Character(){
            Name = "Character updated",
            Id = 0
        };

        var cs = new CharacterService();

        // Act
        var result = cs.UpdateCharacter(character);


        // Assert
        Assert.NotNull(result);
    }

}

