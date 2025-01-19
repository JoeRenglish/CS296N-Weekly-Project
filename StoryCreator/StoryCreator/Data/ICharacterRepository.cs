using StoryCreator.Models;

namespace StoryCreator.Data;

public interface ICharacterRepository
{
    public List<Character> GetCharacters();
    public Character GetCharacterById(int id);
    public int StoreCharacter(Character model);
}