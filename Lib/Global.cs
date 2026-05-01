using System.ComponentModel.DataAnnotations;

namespace Playground.Lib
{
    public static class Global
    {
        public static string FirstName { get; set; } = "Sascha";
        public static string LastName { get; set; } = "Davidson";
        public static string FullName { get; set; } = $"{FirstName} {LastName}";

        //Phone number
        [Display(Name = "06-1148-0403")]
        public static string Phone { get; set; } = "0611480403";
        public static string FormattedPhone => FormatPhone(Phone);

        private static string FormatPhone(string phone)
        {
            if (!string.IsNullOrWhiteSpace(phone) && phone.Length == 10)
                return $"{phone[..2]} - {phone[2..6]} - {phone[6..]}";
            return phone; // Fallback if length is unexpected
        }
        public static string PhoneLink { get; set; } = $"tel: {Phone}";
        //E-mail adres
        public static string Mail { get; set; } = "saschadavidson1@gmail.com";
        public static string MailLink { get; set; } = $"mailto: {Mail}";

        //DeBug
#if DEBUG
        public static bool IsDebug => true;
        #else
            public static bool IsDebug => false;
        #endif

    }
}
