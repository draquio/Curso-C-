﻿using System;
using System.Collections.Generic;

namespace IntroASP.Models;

public partial class Brand
{
    public int idBrand { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Beer> Beers { get; set; } = new List<Beer>();
}
