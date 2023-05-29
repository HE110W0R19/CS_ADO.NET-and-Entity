using System;
using System.Collections.Generic;

namespace Characters_Info_WithEntity.EntityModels;

public partial class Expirience
{
    public int Id { get; set; }

    public int? CurrentLevel { get; set; }

    public int? NextLevelExpirience { get; set; }

    public virtual ICollection<CharactersExpirience> CharactersExpiriences { get; set; } = new List<CharactersExpirience>();

    public virtual ICollection<Spell> Spells { get; set; } = new List<Spell>();
}
