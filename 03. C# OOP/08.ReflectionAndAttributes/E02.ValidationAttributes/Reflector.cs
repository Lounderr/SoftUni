using System;
using System.Reflection;

namespace ValidationAttributes
{
    // exercise extension
    internal static class Reflector
    {
        internal static string GetNumber(Person person)
        {
            var field = person.GetType().GetField("egn", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            if (field != null)
            {
                return field.GetValue(person).ToString();
            }

            return string.Empty;
        }
    }
}