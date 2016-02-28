using System;
using System.Windows.Forms;

namespace CastExtensions.OldExtensions
{
    public static class StringExtensions
    {
        public static string RemoveRichTextMarkup(this string inputString)
        {
            if (!inputString.TrimStart().StartsWith("{\\rtf1", StringComparison.Ordinal))
            {
                return inputString;
            }
            var rtb = new RichTextBox();
            try
            {
                rtb.Rtf = inputString;
            }
            catch (ArgumentException)
            {
                return inputString;
            }
            return rtb.Text;
        }

        public static string SafeTrim(this string inputString, char[] trimChar)
        {
            if (inputString == null)
            {
                return null;
            }

            return inputString.Trim(trimChar);
        }

        public static string SafeTrim(this string inputString)
        {
            if (inputString == null)
            {
                return null;
            }

            return inputString.Trim();
        }
    }
}
