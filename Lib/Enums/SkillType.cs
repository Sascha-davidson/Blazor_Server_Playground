using System.ComponentModel.DataAnnotations;
using static Playground.Lib.Enums.EnumExtensions;

namespace Playground.Lib.Enums
{
    public enum SkillType
    {
        [Display(Name = "HTML"), Color("#e34c26")]         // HTML orange
        Html = 0,

        [Display(Name = "CSS"), Color("#264de4")]          // CSS blue
        Css = 1,

        [Display(Name = "Java Script"), Color("#f0db4f")]  // JavaScript yellow
        Javascript = 2,

        [Display(Name = "C#"), Color("#9B4F96")]           // C# green
        CSharp = 3,

        [Display(Name = "Figma"), Color("#F24E1E")]           // C# green
        Figma = 4,
    }

}
