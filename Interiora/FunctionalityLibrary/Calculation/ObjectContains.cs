using System.Linq;

namespace FunctionalityLibrary.Calculation
{
    public static class ObjectContains // поиск, если любое свойство преобразованное в строку у Объекта О начинается со строки С то функция вернет правду
    {
        public static bool String(object o, string s)
        {
            return o.GetType().GetProperties().Any(propotyInfo => propotyInfo.GetValue(o).ToString().StartsWith(s));
        }
    }
}