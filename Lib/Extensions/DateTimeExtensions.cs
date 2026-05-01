using System.Globalization;

namespace Playground.Lib.Extensions
{
    public static class DateTimeExtensions
    {
        extension(DateTime value)
        {
            /// <summary>
            /// Converts the DateTime to a short date/time string (e.g., "1/1/2024 12:00 PM").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A short date/time formatted string.</returns>
            public string ToShortDateTimeString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.ToString("g", culture);
            }

            /// <summary>
            /// Converts the DateTime to a long date/time string (e.g., "1/1/2024 12:00:00 PM").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A long date/time formatted string.</returns>
            public string ToLongDateTimeString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.ToString("G", culture);
            }

            /// <summary>
            /// Converts the DateTime to a full date/short time string (e.g., "Monday, January 1, 2024 12:00 PM").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A full date/short time formatted string.</returns>
            public string ToShortDateTimeFullString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.ToString("f", culture);
            }

            /// <summary>
            /// Converts the DateTime to a full date/long time string (e.g., "Monday, January 1, 2024 12:00:00 PM").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A full date/long time formatted string.</returns>
            public string ToLongDateTimeFullString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.ToString("F", culture);
            }

            /// <summary>
            /// Converts the DateTime to a short date string (e.g., "1/1/2024").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A short date formatted string.</returns>
            public string ToShortDateString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.ToString("d", culture);
            }

            /// <summary>
            /// Converts the DateTime to a long date string (e.g., "Monday, January 1, 2024").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A long date formatted string.</returns>
            public string ToLongDateString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.ToString("D", culture);
            }

            /// <summary>
            /// Converts the DateTime to a short time string (e.g., "12:00 PM").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A short time formatted string.</returns>
            public string ToShortTimeString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.ToString("t", culture);
            }

            /// <summary>
            /// Converts the DateTime to a long time string (e.g., "12:00:00 PM").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A long time formatted string.</returns>
            public string ToLongTimeString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.ToString("T", culture);
            }

            /// <summary>
            /// Converts the DateTime to a month/day string (e.g., "January 1").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A month/day formatted string.</returns>
            public string ToMonthDayString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.ToString("M", culture);
            }

            /// <summary>
            /// Converts the DateTime to a year/month string (e.g., "January 2024").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A year/month formatted string.</returns>
            public string ToYearMonthString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.ToString("Y", culture);
            }
        }

        extension(DateTime? value)
        {
            /// <summary>
            /// Converts the nullable DateTime to a short date/time string (e.g., "1/1/2024 12:00 PM").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A short date/time formatted string, or "null" if the value is null.</returns>
            public string ToShortDateTimeString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.HasValue ? value.Value.ToString("g", culture) : "null";
            }

            /// <summary>
            /// Converts the nullable DateTime to a long date/time string (e.g., "1/1/2024 12:00:00 PM").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A long date/time formatted string, or "null" if the value is null.</returns>
            public string ToLongDateTimeString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.HasValue ? value.Value.ToString("G", culture) : "null";
            }

            /// <summary>
            /// Converts the nullable DateTime to a full date/short time string (e.g., "Monday, January 1, 2024 12:00 PM").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A full date/short time formatted string, or "null" if the value is null.</returns>
            public string ToShortDateTimeFullString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.HasValue ? value.Value.ToString("f", culture) : "null";
            }

            /// <summary>
            /// Converts the nullable DateTime to a full date/long time string (e.g., "Monday, January 1, 2024 12:00:00 PM").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A full date/long time formatted string, or "null" if the value is null.</returns>
            public string ToLongDateTimeFullString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.HasValue ? value.Value.ToString("F", culture) : "null";
            }

            /// <summary>
            /// Converts the nullable DateTime to a short date string (e.g., "1/1/2024").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A short date formatted string, or "null" if the value is null.</returns>
            public string ToShortDateString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.HasValue ? value.Value.ToString("d", culture) : "null";
            }

            /// <summary>
            /// Converts the nullable DateTime to a long date string (e.g., "Monday, January 1, 2024").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A long date formatted string, or "null" if the value is null.</returns>
            public string ToLongDateString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.HasValue ? value.Value.ToString("D", culture) : "null";
            }

            /// <summary>
            /// Converts the nullable DateTime to a short time string (e.g., "12:00 PM").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A short time formatted string, or "null" if the value is null.</returns>
            public string ToShortTimeString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.HasValue ? value.Value.ToString("t", culture) : "null";
            }

            /// <summary>
            /// Converts the nullable DateTime to a long time string (e.g., "12:00:00 PM").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A long time formatted string, or "null" if the value is null.</returns>
            public string ToLongTimeString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.HasValue ? value.Value.ToString("T", culture) : "null";
            }

            /// <summary>
            /// Converts the nullable DateTime to a month/day string (e.g., "January 1").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A month/day formatted string, or "null" if the value is null.</returns>
            public string ToMonthDayString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.HasValue ? value.Value.ToString("M", culture) : "null";
            }

            /// <summary>
            /// Converts the nullable DateTime to a year/month string (e.g., "January 2024").
            /// </summary>
            /// <param name="culture">The culture to use for formatting. Defaults to current culture.</param>
            /// <returns>A year/month formatted string, or "null" if the value is null.</returns>
            public string ToYearMonthString(CultureInfo? culture = null)
            {
                culture ??= CultureInfo.CurrentCulture;
                return value.HasValue ? value.Value.ToString("Y", culture) : "null";
            }
        }
    }
}
