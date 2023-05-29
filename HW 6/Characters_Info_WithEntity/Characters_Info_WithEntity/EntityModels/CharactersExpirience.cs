using System;
using System.Collections.Generic;

namespace Characters_Info_WithEntity.EntityModels;

public partial class CharactersExpirience
{
    public int Id { get; set; }

    public int? CharactersId { get; set; }

    public int? ExpirienceId { get; set; }

    public int? Expirience { get; set; }

    public virtual Character? Characters { get; set; }

    public virtual Expirience? ExpirienceNavigation { get; set; }
}
