using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace B2B.Utilities.Extensions
{
    public static class IntExtension
    {
        public static bool IsValidId(this int value)
        {
            return value > 0;
        }

        public static bool IsValidNullableId(this int? value)
        {
            return value is null or > 0;
        }

        public static bool IsValidId(this int? value)
        {
            return value.HasValue && value.Value.IsValidId();
        }

        public static bool IsDigit(this string value)
        {
            var regex = new Regex(@"^[ 0-9]*$");
            return regex.IsMatch(value);
        }
    }
}
