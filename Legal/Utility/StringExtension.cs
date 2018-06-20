using System;
using System.Collections.Generic;
using System.Text;

namespace Legal.Utility
{
    public static class StringExtension
    {
        public static bool InProperties(this string value, Type obj)
        {
            if (value == null) { return false; }
            foreach (var prop in obj.GetProperties())
            {
                if (value.ToUpper().Equals(prop.Name.ToUpper()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
