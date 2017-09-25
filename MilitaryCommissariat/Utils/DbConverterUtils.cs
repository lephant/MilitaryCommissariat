using System;

namespace MilitaryCommissariat.Utils
{
    public static class DbConverterUtils
    {
        public static string ConvertString(object source)
        {
            if (Convert.IsDBNull(source))
            {
                return "";
            }
            return (string) source;
        }

        public static DateTime ConvertDateTime(object source)
        {
            if (Convert.IsDBNull(source))
            {
                return new DateTime();
            }
            return (DateTime) source;
        }

        public static long ConvertLong(object source)
        {
            if (Convert.IsDBNull(source))
            {
                return 0;
            }
            return (long) source;
        }
    }
}