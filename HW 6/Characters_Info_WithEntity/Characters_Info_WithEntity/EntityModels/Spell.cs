using System;
using System.Collections.Generic;

namespace Characters_Info_WithEntity.EntityModels;

public partial class Spell
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ExpirienceId { get; set; }

    public virtual ICollection<CharacterClassBuild> CharacterClassBuilds { get; set; } = new List<CharacterClassBuild>();

    public virtual Expirience? Expirience { get; set; }
}
