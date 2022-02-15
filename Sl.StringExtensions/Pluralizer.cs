using System;
using System.Globalization;
using System.Linq;

namespace Sl.StringExtensions
{
    public static class Pluralizer
    {
        private static readonly char[] kalinSesliHarfler = { 'a', 'ı', 'o', 'u', };
        private static readonly char[] inceSesliHarfler = { 'e', 'i', 'ö', 'ü', 'â', 'ê', 'î', 'ô', 'û' };


        public static string Pluralize(this string Source) => Pluralize(Source, Defaults.DefaultCulture);

        public static string Pluralize(this string Source, CultureInfo cultureInfo)
        {
            switch (cultureInfo.TwoLetterISOLanguageName)
            {
                case "tr":
                    return Source.PluralizeTr();
                case "en":
                    return Source.PluralizeEn();
                default:
                    throw new Exception("Unsupported NumSpell Culture. Currently supported cultures: tr, en");
            }
        }

        private static string PluralizeTr(this string Source)
        {
            for (int i = Source.Length - 1; i >= 0; i--)
            {
                if (inceSesliHarfler.Contains(Source[i]))
                    return Source + "ler";
                else
                {
                    if (i != 0)
                    {
                        if (inceSesliHarfler.Contains(Source[i - 1]))
                            return Source + "ler";
                    }
                    return Source + "lar";
                }
            }

            return Source + "ler";
        }

        private static string PluralizeEn(this string Source)
        {
            if (Source.EndsWith("s"))
            {
                return Source + "es";
            }
            else if (Source.EndsWith("y"))
            {
                return Source.Substring(0, Source.Length - 1) + "ies";
            }
            else if (Source.EndsWith("ex"))
            {
                return Source.Substring(0, Source.Length - 2) + "ices";
            }
            else
            {
                return Source + "s";
            }
        }
    }
}
