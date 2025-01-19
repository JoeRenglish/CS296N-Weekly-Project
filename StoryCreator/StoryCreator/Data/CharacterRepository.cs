using StoryCreator.Models;
using Microsoft.EntityFrameworkCore;

namespace StoryCreator.Data;

public class CharacterRepository : ICharacterRepository
{
    private ApplicationDbContext _context;

    public CharacterRepository(ApplicationDbContext appDbContext)
    {
        _context = appDbContext;
    }
    
    public List<Character> GetCharacters()
    {
        var characters = _context.Characters
            .Include(character => character.Story)
            .ToList();
        return characters;
    }

    public Character GetCharacterById(int id)
    {
        var character = _context.Characters
            .Include(character => character.Story)
            .SingleOrDefault(character => character.CharacterId == id);
        return character;
    }

    public int StoreCharacter(Character model)
    {
        model.Date = DateOnly.FromDateTime(DateTime.Today);
        _context.Characters.Add(model);
        return _context.SaveChanges();
    }
}