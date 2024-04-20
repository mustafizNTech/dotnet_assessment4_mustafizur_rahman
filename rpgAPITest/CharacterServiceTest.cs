using rpgAPI.Model;
using rpgAPI.Service;

namespace rpgAPITest;

public class CharacterServiceTest{

    [Fact]
    public void GetAllCharacterGivenValidRequestGetResult()
    {
        var cs = new CharacterService();
        var result = cs.GetAllCharacter();
        Assert.NotNull(result);
    }

    [Fact]
    public void AddCharacterGivenValidRequestGetResul()
    {
        var character = new Character(){
            Name = "Unit Test",
            Id = 4,
        };

        var cs = new CharacterService();

        var result = cs.AddCharacter(character);

        Assert.NotNull(result);
    }

    [Fact]
    public void GetCharacterByIdGivenValidRequestResult(){

        var cs = new CharacterService();
        var result = cs.GetCharacterById(0);
        Assert.NotNull(result);

    }

    [Fact]
    public void UpdateCharacterGivenValidRequestGetResult(){
        var character = new Character(){
            Name = "Character updated",
            Id = 0
        };

        var cs = new CharacterService();

        var result = cs.UpdateCharacter(character);

        Assert.NotNull(result);
        Assert.NotNull(result.Data.FirstOrDefault(x=>x.Name == "Character updated"));
    }
}