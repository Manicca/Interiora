using System.Linq;

namespace FunctionalityLibrary.Calculation
{
    public static class ObjectContains
    {
        public static bool String(object o, string s)
        {
            return o.GetType().GetProperties().Any(propotyInfo => propotyInfo.GetValue(o).ToString().StartsWith(s));
        }
    }
}