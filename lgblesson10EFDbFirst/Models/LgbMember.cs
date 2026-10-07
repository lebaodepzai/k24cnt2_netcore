using System;
using System.Collections.Generic;

namespace LgbLesson10EFDbFirst.Models;

public partial class LgbMember
{
    public long Id { get; set; }

    public string? LgbUserName { get; set; }

    public string? LgbPassword { get; set; }

    public string? LgbFullName { get; set; }

    public string? LgbEmail { get; set; }

    public string? LgbPhone { get; set; }

    public bool? LgbStatus { get; set; }
}
