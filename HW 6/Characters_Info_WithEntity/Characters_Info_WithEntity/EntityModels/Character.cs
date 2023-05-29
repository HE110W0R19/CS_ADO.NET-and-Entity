using System;
using System.Collections.Generic;

namespace Characters_Info_WithEntity.EntityModels;

public partial class Character
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CharacterClassId { get; set; }

    public virtual CharactersClass? CharacterClass { get; set; }

    public virtual ICollection<CharactersExpirience> CharactersExpiriences { get; set; } = new List<CharactersExpirience>();
}
