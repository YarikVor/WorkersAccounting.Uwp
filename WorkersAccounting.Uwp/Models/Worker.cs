using System;
using Windows.Media.SpeechSynthesis;
using WorkersAccounting.Uwp.Models;

namespace WorkersAccounting.Entities;

public class Worker
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime BirthDay { get; set; }
    public int HourTimeWorking { get; set; }
    public string? Description { get; set; }
    public Gender Gender { get; set; } = Gender.Other;
}
