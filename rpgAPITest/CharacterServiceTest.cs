using rpgAPI.Model;
using rpgAPI.Service;

namespace rpgAPITest;

public class CharacterServiceTest{

    [Fact]
    public void GetAllCharacterGivenValidRequestGetResult()
    {
        // Arrange
        var cs = new CharacterService();

        // Act
        var result = cs.GetAllCharacter();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void AddCharacterGivenValidRequestGetResul()
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
    public void GetCharacterByIdGivenValidRequestResult(){

        // Arrange
        var cs = new CharacterService();

        // Act
        var result = cs.GetCharacterById(0);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]
    public void UpdateCharacterGivenValidRequestGetResult(){

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
        Assert.NotNull(result.Data.FirstOrDefault(x=>x.Name == "Character updated"));
    }
}