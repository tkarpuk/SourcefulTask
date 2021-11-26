namespace Users.WebApi.Common
{
    public static class ConvertStrToInt
    {
        public static int StrToIntDefault(this string inString, int defaultValue = 0)
        {
            return int.TryParse(inString, out int result) ? result : defaultValue;
        }
    }
}
