using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkersAccounting.Uwp.Models;

public static class GenderMethods
{
    private static Gender[] _enumTypes = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToArray();
    public static IEnumerable<Gender> GetEnumTypes => _enumTypes;
}