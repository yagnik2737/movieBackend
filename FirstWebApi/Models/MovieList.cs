using System;
using System.Collections.Generic;

namespace FirstWebApi.Models;

public partial class MovieList
{
    public int Id { get; set; }

    public string? Movie { get; set; }

    public string? Category { get; set; }

    public DateTime? Releaseyear { get; set; }
}
