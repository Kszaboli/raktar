using System;
using System.Collections.Generic;

namespace WebApplication5.Models;

public partial class Termekek
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public int Dbszam { get; set; }
}
