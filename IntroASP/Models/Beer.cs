using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroASP.Models;

public partial class Beer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idBeer { get; set; }

    public string? Name { get; set; }

    [ForeignKey("Brand")]
    public int? idBrand { get; set; }

    public virtual Brand? IdBrandNavigation { get; set; }
}
