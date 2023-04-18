

using System.Text.RegularExpressions;

namespace UserSample.Domain.Service.Helpers
{
    public static class MaskHelper
    {

        public static string MaskDate(this string value)
        {
            string result = Regex.Replace(value, @"(.+?)/(.+?)/", "##/##/");
            return result;
        }

        public static string MaskName(this string value)
        {
            if (string.IsNullOrEmpty(value) && value.Length > 2)
                return "**";

            return value.Substring(0, 2) + "*****";
        }

        public static string MaskTcknNumber(this string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid TCKN Number");
            Regex regex = new Regex("^[a-z0-9A-Z]{7}");
            return regex.Replace(value, "*******");
        }
    }
}
