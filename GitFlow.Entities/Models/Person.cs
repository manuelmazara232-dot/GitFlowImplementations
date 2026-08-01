#nullable disable
using System;
using System.Collections.Generic;

namespace GitFlow.Entities.Models;

public partial class Person
{
    public int Id { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string Dni { get; set; }

    public string Gender { get; set; }
}