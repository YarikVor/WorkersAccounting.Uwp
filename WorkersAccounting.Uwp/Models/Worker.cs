using System;
using System.Collections.Generic;

namespace WorkersAccounting.Entities;

public class Worker
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime BirthDay { get; set; }
    public int HourTimeWorking { get; set; }
    public string? Description { get; set; }
}

public class WorkerList: List<Worker>
{

}