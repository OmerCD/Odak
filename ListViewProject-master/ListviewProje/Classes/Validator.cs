using System.Text.RegularExpressions;

namespace ListviewProje.Classes
{
    public static class Validator
    {
        public static bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
    }
}
