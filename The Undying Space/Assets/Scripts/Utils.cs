using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Assets.Scripts
{
    public static class Utils
    {
        public static string GetDescription(this Enum value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                ?? value.ToString();
        }

        public static string Text(this float numero) => string.Format("{0:N0}", numero);
    }
}
