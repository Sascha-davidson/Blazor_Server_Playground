using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Playground.Lib.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayValue(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name ?? value.ToString();
        }

        public static string GetDisplayColor(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<ColorAttribute>();

            return attribute?.Color ?? "#000000";
        }

        [AttributeUsage(AttributeTargets.Field)]
        public class ColorAttribute : Attribute
        {
            public string Color { get; }

            public ColorAttribute(string color)
            {
                Color = color;
            }
        }
    }
}
