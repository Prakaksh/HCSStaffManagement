using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HCS.StaffManagement.Models
{
    public class NumberToWordConverter
    {
         private static string[] numbers = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
         private static string[] tens = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public static void ConvertToString(int number, StringBuilder builder)
        {
            const int MinimumRange = 0, MaximumRange = 1000000;
            if (MinimumRange > number || number > MaximumRange)
                throw new ArgumentOutOfRangeException("number", number,
                    string.Format("Only number between {0} and {1}", MinimumRange, MaximumRange));

            if (number == 0) { return; }

            if (number <= 19)
            {
                builder.Append(numbers[number]);
                return;
            }

            string digits = number.ToString();

            int firstDigit = (int)Char.GetNumericValue(digits[0]);

            if (number <= 99)
            {
                builder.Append(tens[firstDigit])
                       .Append(" ");

                number = number % 10;

                ConvertToString(number, builder);
                return;
            }

            if (number <= 999)
            {
                builder.Append(numbers[firstDigit])
                       .Append(" hundred ");

                number = number % 100;

                if (number > 0)
                {
                    builder.Append("and ");
                }

                ConvertToString(number, builder);
                return;
            }

            if (number <= 9999)
            {
                builder.Append(numbers[firstDigit])
                       .Append(" thousand ");

                number = number % 1000;

                if (number > 0 && number <= 99)
                {
                    builder.Append("and ");
                }

                ConvertToString(number, builder);
                return;
            }

            if (number <= 19999)
            {
                int firstPart = firstDigit * 10 + (int)Char.GetNumericValue(digits[1]);

                builder.Append(numbers[firstPart])
                       .Append(" thousand ");

                number = number % 1000;

                if (number > 0 && number <= 99)
                {
                    builder.Append("and ");
                }

                ConvertToString(number, builder);
                return;
            }

            if (number <= 99999)
            {
                int firstPart = firstDigit * 10 + (int)Char.GetNumericValue(digits[1]);

                ConvertToString(firstPart, builder);

                builder.Append(" thousand ");

                number = number % 1000;

                if (number > 0 && number <= 99)
                {
                    builder.Append("and ");
                }

                ConvertToString(number, builder);
                return;
            }

            if (number <= 999999)
            {
                int firstPart = firstDigit * 100 + (int)Char.GetNumericValue(digits[1]) * 10 + (int)Char.GetNumericValue(digits[2]);

                ConvertToString(firstPart, builder);

                builder.Append(" thousand ");

                number = number % (firstPart * 1000);

                if (number > 0 && number <= 99)
                {
                    builder.Append("and ");
                }

                ConvertToString(number, builder);
                return;
            }

            builder.Append("One million");
        }

    }
}