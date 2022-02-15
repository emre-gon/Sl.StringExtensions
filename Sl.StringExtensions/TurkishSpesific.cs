using System;
using System.Collections.Generic;
using System.Text;

namespace Sl.StringExtensions
{
    public static class TurkishSpesific
    {
        public static string ReplaceTurkishCharacters(this string Source)
        {
            foreach (var key in TurkishCharactersDict.Keys)
            {
                Source = Source.Replace(key, TurkishCharactersDict[key]);
            }

            return Source;
        }

        private static readonly Dictionary<char, char> TurkishCharactersDict = new Dictionary<char, char>()
        {
            {'ç','c'}, {'Ç','C'},
            {'ğ','g'}, {'Ğ','G'},
            {'ı','i'}, {'İ','I'},
            {'ö','o'}, {'Ö','O'},
            {'ş','s'}, {'Ş','S'},
            {'ü','u'}, {'Ü','U'}
        };
    }
}
