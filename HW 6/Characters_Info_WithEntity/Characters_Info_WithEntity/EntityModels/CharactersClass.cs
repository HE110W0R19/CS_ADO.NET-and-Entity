using System;
using System.Collections.Generic;

namespace Characters_Info_WithEntity.EntityModels;

public partial class CharactersClass
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<CharacterClassBuild> CharacterClassBuilds { get; set; } = new List<CharacterClassBuild>();

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
