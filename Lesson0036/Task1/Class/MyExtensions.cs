namespace Task1.Class
{
    internal static class MyExtensions
    {
        public static bool IsPositive(this int valueToCheck) => valueToCheck > 0;

        public static bool IsEven(this int valueToCheck) => valueToCheck % 2 == 0;

        public static bool IsGreater(this int valueToCheck, int value)
            => valueToCheck > value;

        public static bool ContainsSpace(this string valueToCheck)
            => valueToCheck.Contains(' ');

        public static string CreateEmail(this string fullName, string yearOfBirth, string domain) => $"{fullName}{yearOfBirth}@{domain}";

        public static T? FindAndReturnIfEqual<T>(this List<T> list, T searchForThis)
        {
            if(list.Contains(searchForThis))
            {
                return searchForThis;
            }
            return default;
        }

        public static List<T> EveryOtherValue<T>(this List<T> value)
        {
            List<T> list = [];
            for(int i = 0; i < value.Count; i++)
            {
                if(i % 2 == 0)
                    list.Add(value[i]);
            }
            return list;
        }
    }
}