using rpgAPI.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgAPI.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class CharacterGenerator
    {

        public static Character GetValidCharacter()
        {
            return new Character
            {
                CharacterClass = RPGClass.Knight,
                Name = "Gollum",
                Id = 3,
                Defense = 1,
                HitPoint = 2,
                Intelligence = 3,
            };
        }

        public static List<Character> GetValidCharacterList() { 
            
            return new List<Character>() { GetValidCharacter() };
        
        }

    }
}
