using System;
using System.Collections.Generic;

namespace Characters_Info_WithEntity.EntityModels;

public partial class CharacterClassBuild
{
    public int Id { get; set; }

    public int? CharacterClassId { get; set; }

    public int? SpellId { get; set; }

    public virtual CharactersClass? CharacterClass { get; set; }

    public virtual Spell? Spell { get; set; }
}
