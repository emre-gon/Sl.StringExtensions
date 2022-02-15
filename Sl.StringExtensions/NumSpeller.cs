using System;
using System.Globalization;

namespace Sl.StringExtensions
{
    public static class NumSpeller
    {
        public static string NumSpell(this int Number) => NumSpell((long)Number, Defaults.DefaultCulture);

        public static string NumSpell(this int Number, CultureInfo cultureInfo) => NumSpell((long)Number, cultureInfo);

        public static string NumSpell(this long Number) => NumSpell(Number, Defaults.DefaultCulture);
        public static string NumSpell(this long Number, CultureInfo cultureInfo)
        {
            switch (cultureInfo.TwoLetterISOLanguageName)
            {
                case "tr":
                    return Number.SpellTr();
                case "en":
                    return Number.SpellEn();
                default:
                    throw new Exception("Unsupported NumSpell Culture. Currently supported cultures: tr, en");
            }
        }



        #region tr
        private static readonly string[] sayilar = { "sıfır", "bir", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz" };
        private static readonly string[] onluklar = { "", "on", "yirmi", "otuz", "kırk", "elli", "altmış", "yetmiş", "seksen", "doksan" };
        private static readonly string[] birimler = { "yüz", "bin", "milyon", "milyar", "trilyon", "katrilyon", "ketilyon" };        
        private static string SpellTr(this long Source)
        {
            string ToBeReturned = "";
            if (Source < 0)
            {
                ToBeReturned += "eksi ";
                Source = Math.Abs(Source);
            }
            else if (Source == 0)
                return sayilar[0];

            string str = Source.ToString();


            for (int i = 0; i < str.Length; i++)
            {
                int num = (int)Char.GetNumericValue(str[i]);

                int mod = (str.Length - i - 1) % 3;
                if (mod == 0)
                {
                    int currentBirim = (str.Length - i) / 3;

                    if (num != 0)
                    {
                        if (!(currentBirim == 1 && num == 1 && str.Length == 4))
                            ToBeReturned += sayilar[num];
                    }

                    if (currentBirim != 0)
                        ToBeReturned += birimler[currentBirim];

                }
                else if (mod == 1)
                {
                    ToBeReturned += onluklar[num];
                }
                else
                {
                    if (num > 1)
                        ToBeReturned += sayilar[num];

                    if (num != 0)
                        ToBeReturned += birimler[0];

                }

            }

            return ToBeReturned.TrimEveryThing();
        }
        #endregion

        #region eng
        private static readonly string[] unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static readonly string[] tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static string SpellEn(this long number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + SpellEn(Math.Abs(number));

            string words = "";


            if ((number / 1000000000) > 0)
            {
                words += SpellEn(number / 1000000000) + " billion ";
                number %= 1000000000;
            }


            if ((number / 1000000) > 0)
            {
                words += SpellEn(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += SpellEn(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += SpellEn(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";


                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        #endregion

    }
}
