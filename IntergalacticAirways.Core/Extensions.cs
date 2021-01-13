using System;
using System.Collections.Generic;
using System.Linq;

namespace IntergalacticAirways.Core
{
    public static class Extensions
    {
        public static decimal? ToDecimal(this string str) => decimal.TryParse(str, out decimal temp) ? temp : (decimal?)null;
        public static long? ToLong(this string str) => long.TryParse(str, out long temp) ? temp : (long?)null;
        public static int? ToInt(this string str) => int.TryParse(str, out int temp) ? temp : (int?)null;
        public static DateTime? ToDateTime(this string str) => DateTime.TryParse(str, out DateTime temp) ? temp : (DateTime?)null;

        public static bool HasItem<T>(this List<T> list) => list != null && list.Any();
    }
}
